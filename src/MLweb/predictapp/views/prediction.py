from django.shortcuts import render
from predictapp.services import ml_service


def predict_view(request):
    """
    Nhận giá trị các feature từ form POST,
    gọi ml_service.predict() và trả về kết quả dự đoán.
    """
    features    = request.session.get("features", [])
    target_list = request.session.get("target", [])
    target      = target_list[0] if target_list else None

    if request.method == "POST":
        values = []

        for f in features:
            v = request.POST.get(f)
            if v is None or v == "":
                return render(request, "predictapp/predict.html", {
                    "error":    f"Feature '{f}' không được để trống!",
                    "target":   target,
                    "features": features,
                })
            values.append(float(v))

        result = ml_service.predict(features, values)

        return render(request, "predictapp/predict.html", {
            "result":   result,
            "target":   target,
            "features": features,
        })

    return render(request, "predictapp/predict.html", {
        "features": features,
        "target":   target,
    })
