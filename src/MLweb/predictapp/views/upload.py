from django.shortcuts import render
from predictapp.services import ml_service


def upload_csv(request):
    """Nhận file CSV từ người dùng và lưu vào data/a.csv."""
    if request.method == "POST":
        file = request.FILES.get("csvfile")
        if file:
            ml_service.save_uploaded_data(file)
            return render(request, "predictapp/upload.html",
                          {"msg": "Tải lên thành công!"})
        return render(request, "predictapp/upload.html",
                      {"msg": "Vui lòng chọn file CSV trước khi upload."})

    return render(request, "predictapp/upload.html")
