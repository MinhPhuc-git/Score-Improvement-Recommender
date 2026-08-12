from django.shortcuts import render


def index(request):
    """Trang chủ — hiển thị menu điều hướng."""
    return render(request, "predictapp/index.html")
