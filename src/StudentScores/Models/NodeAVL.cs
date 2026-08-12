using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public class NodeAVL
    {
        #region Attributes
        private Student val;
        private NodeAVL left;
        private NodeAVL right;
        LinkedList<Student> nodeStudent;
        private int height;
        #endregion

        #region Property
        public Student Value { get { return val; } set { val = value; } }

        public NodeAVL Left { get { return this.left; } set { this.left = value; } }

        public NodeAVL Right { get { return this.right; } set { this.right = value; } }

        public int Height { get { return this.height; } set { this.height = value; } }
        public LinkedList<Student> NodeStudent {  get { return this.nodeStudent; } set { this.nodeStudent = value; } }
        #endregion

        #region Constructor
        public NodeAVL(Student x)
        {
            this.val = x;
            this.height = 1;
            this.left = null;
            this.right = null;
            this.NodeStudent = new LinkedList<Student>();
        }
        #endregion
    }
}
