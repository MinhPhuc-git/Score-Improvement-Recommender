from django.urls import path
from predictapp import views

urlpatterns = [
    path("",             views.index,        name="home"),
    path("dataset/",     views.view_dataset, name="dataset"),
    path("predict/",     views.predict_view, name="predict"),
    path("upload/",      views.upload_csv,   name="upload"),
    path("train_model/", views.train_model,  name="train"),
]
