from django.shortcuts import render
from predictapp.services import ml_service


def view_dataset(request):
    """Hiển thị toàn bộ dataset dưới dạng bảng HTML."""
    df         = ml_service.load_data()
    html_table = df.to_html(classes="table table-striped", index=False)
    return render(request, "predictapp/dataset.html", {"table": html_table})
