from .home       import index
from .dataset    import view_dataset
from .prediction import predict_view
from .training   import train_model
from .upload     import upload_csv

__all__ = [
    "index",
    "view_dataset",
    "predict_view",
    "train_model",
    "upload_csv",
]
