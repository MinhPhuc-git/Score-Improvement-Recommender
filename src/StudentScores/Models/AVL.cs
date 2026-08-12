using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public class AVL
    {
        #region Attributes
        public NodeAVL Root;
        private Comparer<Student> comparer;
        #endregion

        // Khởi tạo cây, comparer xác định cách thức duyệt dựa trên ID, Alphabet,...
        public AVL(Comparer<Student> comparer)
        {
            this.comparer = comparer ?? Comparer<Student>.Default;
            Root = null;
        }
        // So sánh 2 đối tượng sau khi xác định trường dữ liệu để add vào cây
        private int CompareObject(Student a, Student b) => comparer.Compare(a, b);

        #region Height Function
        public int GetHeight(NodeAVL h)
        {
            return h == null ? 0 : h.Height;
        }

        public int UpdateHeight(NodeAVL h)
        {
            return 1 + Math.Max(GetHeight(h.Left), GetHeight(h.Right));
        }
        #endregion

        #region Rotate Methods
        public NodeAVL RotateLeft(NodeAVL h)
        {
            if (h == null || h.Right == null) return h;

            NodeAVL nodeRight = h.Right;
            NodeAVL nodeRightLeft = nodeRight.Left;

            nodeRight.Left = h;
            h.Right = nodeRightLeft;

            h.Height = UpdateHeight(h);
            nodeRight.Height = UpdateHeight(nodeRight);

            return nodeRight;
        }
        public NodeAVL RotateRight(NodeAVL h)
        {
            if (h == null || h.Left == null) return h;

            NodeAVL nodeLeft = h.Left;
            NodeAVL nodeLeftRight = nodeLeft.Right;

            nodeLeft.Right = h;
            h.Left = nodeLeftRight;

            h.Height = UpdateHeight(h);
            nodeLeft.Height = UpdateHeight(nodeLeft);

            return nodeLeft;
        }
        public NodeAVL RotateRightLeft(NodeAVL h)
        {
            h.Right = RotateRight(h.Right);
            return RotateLeft(h);
        }

        public NodeAVL RotateLeftRight(NodeAVL h)
        {
            h.Left = RotateLeft(h.Left);
            return RotateRight(h);
        }
        #endregion
        private NodeAVL Add(NodeAVL h, Student x)
        {
            if (h == null)
                return h = new NodeAVL(x);
            int cmp = CompareObject(x, h.Value);
            if (cmp < 0)
                h.Left = Add(h.Left, x);
            else if (cmp > 0)
                h.Right = Add(h.Right, x);
            else if (cmp == 0)
            {
                h.NodeStudent.AddLast(x);
                return h;
            }
            h.Height = UpdateHeight(h);
            int balance = GetHeight(h.Left) - GetHeight(h.Right);

            // T-T
            if (balance > 1 && CompareObject(x, h.Left.Value) < 0)
                h = RotateRight(h);
            // T-P
            if (balance > 1 && CompareObject(x, h.Left.Value) > 0)
                h = RotateLeftRight(h);
            // P-P
            if (balance < -1 && CompareObject(x, h.Right.Value) > 0)
                h = RotateLeft(h);
            // P-T
            if (balance < -1 && CompareObject(x, h.Right.Value) < 0)
                h = RotateRightLeft(h);
            return h;

        }
        private bool FindX(NodeAVL root, Student x)
        {
            if (root == null)
                return false;
            int cmp = CompareObject(x, root.Value);
            if (cmp == 0) return true;
            if (cmp > 0) return FindX(root.Right, x);
            return FindX(root.Left, x);

        }

        public NodeAVL MaxNode(NodeAVL root)
        {
            if (root == null || root.Right == null)
                return root;
            return MaxNode(root.Right);
        }

        private (NodeAVL, bool) DeleteX(NodeAVL root, Student x, Comparer<Student> comparer)
        {
            if (root == null)
                return (null, false);

            bool deleted = false;
            int cmp = comparer.Compare(x, root.Value);

            if (cmp > 0)
            {
                (root.Right, deleted) = DeleteX(root.Right, x, comparer);
            }
            else if (cmp < 0)
            {
                (root.Left, deleted) = DeleteX(root.Left, x, comparer);
            }
            else
            {
                deleted = true;

                // Nếu NodeStudent còn học sinh khác, lấy học sinh đầu tiên
                if (root.NodeStudent != null && root.NodeStudent.Count > 0)
                {
                    root.Value = root.NodeStudent.First.Value;
                    root.NodeStudent.RemoveFirst();
                    return (root, true);
                }

                if (root.Left == null)
                    return (root.Right, true);
                else if (root.Right == null)
                    return (root.Left, true);
                else
                {
                    NodeAVL maxLeft = MaxNode(root.Left);
                    root.Value = maxLeft.Value;
                    root.NodeStudent = maxLeft.NodeStudent;
                    (root.Left, _) = DeleteX(root.Left, maxLeft.Value, comparer);
                }
            }

            // Cân bằng AVL
            root.Height = UpdateHeight(root);
            int balance = GetHeight(root.Left) - GetHeight(root.Right);
            if (balance > 1 && GetHeight(root.Left.Left) >= GetHeight(root.Left.Right))
                root = RotateRight(root);
            if (balance > 1 && GetHeight(root.Left.Left) < GetHeight(root.Left.Right))
                root = RotateLeftRight(root);
            if (balance < -1 && GetHeight(root.Right.Right) >= GetHeight(root.Right.Left))
                root = RotateLeft(root);
            if (balance < -1 && GetHeight(root.Right.Right) < GetHeight(root.Right.Left))
                root = RotateRightLeft(root);

            return (root, deleted);
        }

        public bool Delete(Student x, Comparer<Student> comparer)
        {
            bool deleted;
            (Root, deleted) = DeleteX(Root, x, comparer);
            return deleted;
        }

        //private NodeAVL DeleteX(NodeAVL root, Student x, Comparer<Student> comparer)
        //{
        //    if (root == null)
        //        return null;

        //    int cmp = comparer.Compare(x, root.Value);

        //    if (cmp > 0)
        //        root.Right = DeleteX(root.Right, x, comparer);
        //    else if (cmp < 0)
        //        root.Left = DeleteX(root.Left, x, comparer);
        //    else
        //    {
        //        // Nếu NodeStudent còn học sinh khác, lấy học sinh đầu tiên làm root.Value
        //        if (root.NodeStudent != null && root.NodeStudent.Count > 0)
        //        {
        //            root.Value = root.NodeStudent.First.Value;
        //            root.NodeStudent.RemoveFirst();
        //            return root;
        //        }

        //        // Nếu không còn học sinh trong NodeStudent
        //        if (root.Left == null)
        //            return root.Right;
        //        else if (root.Right == null)
        //            return root.Left;
        //        else
        //        {
        //            NodeAVL maxLeft = MaxNode(root.Left);
        //            root.Value = maxLeft.Value;

        //            // Chuyển luôn danh sách NodeStudent từ maxLeft sang root
        //            root.NodeStudent = maxLeft.NodeStudent;

        //            root.Left = DeleteX(root.Left, maxLeft.Value, comparer);
        //        }
        //    }

        //    // Cập nhật chiều cao và cân bằng lại
        //    root.Height = UpdateHeight(root);
        //    int balance = GetHeight(root.Left) - GetHeight(root.Right);

        //    if (balance > 1 && GetHeight(root.Left.Left) >= GetHeight(root.Left.Right))
        //        return RotateRight(root);

        //    if (balance > 1 && GetHeight(root.Left.Left) < GetHeight(root.Left.Right))
        //        return RotateLeftRight(root);

        //    if (balance < -1 && GetHeight(root.Right.Right) >= GetHeight(root.Right.Left))
        //        return RotateLeft(root);

        //    if (balance < -1 && GetHeight(root.Right.Right) < GetHeight(root.Right.Left))
        //        return RotateRightLeft(root);

        //    return root;
        //}
        //public NodeAVL Delete(Student x,Comparer<Student> comparer)
        //{
        //    Root = DeleteX(Root, x, comparer);
        //    return Root;
        //}
        public bool Find(NodeAVL root, Student x, Comparer<Student> comparer)
        {
            this.comparer = comparer;
            if (FindX(root, x) == true)
                return true;
            return false;
        }

        public void XuatTang(NodeAVL root, int k, int currentLevel, List<Student> students)
        {
            if (root == null) return;

            XuatTang(root.Left, k, currentLevel + 1, students);

            if (currentLevel == k)
            {
                students.Add(root.Value);
                return;
            }
            XuatTang(root.Right, k, currentLevel + 1, students);
        }

        public int CountHeight(NodeAVL root) => GetHeight(root);
        public void AddStudent(Student a, Comparer<Student> comparer)
        {
            this.comparer = comparer;
            Root = Add(Root, a);
        }
        public int CayCon(NodeAVL root)
        {
            if (root == null) return 0;

            if (root.Left != null && root.Right == null) return 1;

            return CayCon(root.Left) + CayCon(root.Right);
        }

        public NodeAVL AddNode(NodeAVL tree, Student student)
        {
            if (tree == null) return null;
            int cmp = CompareObject(student, tree.Value);
            if (cmp > 0)
                tree.Right = AddNode(tree.Right, student);
            if (cmp < 0)
                tree.Left = AddNode(tree.Left, student);
            else
            {
                if (tree.NodeStudent == null)
                    tree.NodeStudent = new LinkedList<Student>();
                tree.NodeStudent.AddLast(student);
            }
            return tree;
        }
        public void Leaf(NodeAVL root, List<Student> temp)
        {
            if (root == null) return;
            if (root.Left == null && root.Right == null)
            {
                temp.Add(root.Value);
                return;
            }
            Leaf(root.Left, temp);
            Leaf(root.Right, temp);
        }
        public void InOrder(NodeAVL root, List<Student> list)
        {
            if (root == null) return;
            InOrder(root.Left, list);
            list.Add(root.Value);
            InOrder(root.Right, list);
        }
        public void PreOrder(NodeAVL root, List<Student> list)
        {
            if (root == null) return;
            list.Add(root.Value);
            InOrder(root.Left, list);
            InOrder(root.Right, list);
        }
        public void PostOrder(NodeAVL root, List<Student> list)
        {
            if (root == null) return;
            PostOrder(root.Right, list);
            list.Add(root.Value);
            PostOrder(root.Left, list);
        }

        public void InOrder_FULL(NodeAVL root, List<Student> list)
        {
            if (root == null) return;
            InOrder_FULL(root.Left, list);
            list.Add(root.Value);
            foreach (Student student in root.NodeStudent)
                list.Add(student);
            InOrder_FULL(root.Right, list);
        }
        public void PreOrder_FULL(NodeAVL root, List<Student> list)
        {
            if (root == null) return;
            list.Add(root.Value);
            foreach (Student student in root.NodeStudent)
                list.Add(student);
            PreOrder_FULL(root.Left, list);
            PreOrder_FULL(root.Right, list);
        }
        public void PostOrder_FULL(NodeAVL root, List<Student> list)
        {
            if (root == null) return;
            PostOrder_FULL(root.Right, list);
            list.Add(root.Value);
            foreach (Student student in root.NodeStudent)
                list.Add(student);
            PostOrder_FULL(root.Left, list);
        }
        public int CountOneChild(NodeAVL root)
        {
            if (root == null) return 0;

            int count = 0;

            bool hasLeft = root.Left != null;
            bool hasRight = root.Right != null;

            if ((hasLeft && !hasRight) || (!hasLeft && hasRight))
                count = 1;

            return count + CountOneChild(root.Left) + CountOneChild(root.Right);
        }

        public int CountTwoChildren(NodeAVL root)
        {
            if (root == null) return 0;

            int count = 0;

            if (root.Left != null && root.Right != null)
                count = 1;

            return count + CountTwoChildren(root.Left) + CountTwoChildren(root.Right);
        }
        public void GetOneChildNodes(NodeAVL root, List<Student> list)
        {
            if (root == null) return;

            bool hasLeft = root.Left != null;
            bool hasRight = root.Right != null;

            // Node có đúng 1 con
            if ((hasLeft && !hasRight) || (!hasLeft && hasRight))
            {
                list.Add(root.Value);

                // Thêm tất cả phần tử trùng khóa trong LinkedList của node đó (nếu có)
                foreach (var s in root.NodeStudent)
                    list.Add(s);
            }

            GetOneChildNodes(root.Left, list);
            GetOneChildNodes(root.Right, list);
        }

        public void GetTwoChildNodes(NodeAVL root, List<Student> list)
        {
            if (root == null) return;

            bool hasLeft = root.Left != null;
            bool hasRight = root.Right != null;

            // Node có đúng 2 con
            if (hasLeft && hasRight)
            {
                list.Add(root.Value);

                // Thêm toàn bộ học sinh trùng khóa
                foreach (var s in root.NodeStudent)
                    list.Add(s);
            }

            // Đệ quy qua hai nhánh
            GetTwoChildNodes(root.Left, list);
            GetTwoChildNodes(root.Right, list);
        }


    }
}