from django.shortcuts import render, redirect
from predictapp.services import ml_service


def train_model(request):
    """
    Hiển thị form chọn features/target và train model
    khi nhận POST request. Sau khi train, redirect sang predict.
    """
    if request.method == "POST":
        select_features = request.POST.getlist("features")
        select_target   = request.POST.getlist("target")

        if not select_features or not select_target:
            return render(request, "predictapp/train_model.html", {
                "result": "Vui lòng chọn ít nhất 1 feature và 1 target để train."
            })

        ml_service.train(select_features, select_target)

        request.session["features"] = select_features
        request.session["target"]   = select_target
        return redirect("predict")

    return render(request, "predictapp/train_model.html")
