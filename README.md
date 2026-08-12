# Đồ Án Tin Học

## Giới Thiệu

Đồ án nghiên cứu và xây dựng hệ thống quản lý điểm sinh viên kết hợp với dự đoán kết quả học tập bằng Machine Learning.

## Cấu Trúc Dự Án

```
Đồ Án Tin Học/
├── docs/              # Tài liệu đặc tả, phân tích thiết kế
├── reports/           # Báo cáo đồ án (.docx, .pdf)
├── src/
│   ├── StudentScores/ # Ứng dụng C# WinForms quản lý điểm sinh viên
│   └── MLweb/         # Ứng dụng Django dự đoán kết quả học tập (ML)
└── README.md
```

## Các Thành Phần

### 📊 StudentScores (C# WinForms)
- Ứng dụng quản lý điểm sinh viên trên desktop
- Cấu trúc dữ liệu AVL Tree để tìm kiếm tối ưu
- Chức năng: thêm, sửa, xóa, thống kê, xuất dữ liệu

### 🤖 MLweb (Django + Machine Learning)
- Web app dự đoán kết quả học tập của sinh viên
- Mô hình ML được train từ dữ liệu điểm sinh viên
- Giao diện web cho phép nhập thông tin và nhận dự đoán
---
> Repository: Score-Improvement-Recommender
