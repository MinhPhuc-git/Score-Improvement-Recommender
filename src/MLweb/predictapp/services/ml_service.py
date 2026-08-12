"""
ml_service.py
─────────────
Service layer cho toàn bộ Machine Learning logic.
Tách biệt hoàn toàn khỏi Django views để dễ test và bảo trì.
"""

import joblib
import pandas as pd
import numpy as np
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split
from django.conf import settings

# ─── Đường dẫn tập trung (lấy từ settings) ────────────────────────────────────
DATA_CSV   = settings.DATA_DIR  / "a_converted.csv"   # Dataset chính đã xử lý
UPLOAD_CSV = settings.DATA_DIR  / "a.csv"              # File upload từ người dùng
MODEL_PATH = settings.MODEL_DIR / "ml_model.joblib"    # Model đã được train
# ──────────────────────────────────────────────────────────────────────────────


def load_data() -> pd.DataFrame:
    """Đọc dataset chính và trả về DataFrame."""
    return pd.read_csv(DATA_CSV)


def get_columns() -> list[str]:
    """Trả về danh sách tên các cột trong dataset."""
    return load_data().columns.tolist()


def save_uploaded_data(file) -> None:
    """Lưu file CSV do người dùng upload vào thư mục data/."""
    df = pd.read_csv(file)
    df.to_csv(UPLOAD_CSV, index=False)


def train(select_features: list[str], select_target: list[str]) -> None:
    """
    Train model Linear Regression với các feature và target được chọn.
    Lưu model đã train vào models_trained/ml_model.joblib.
    """
    df = load_data()

    X = df[select_features]
    Y = df[select_target]

    X_train, X_test, Y_train, Y_test = train_test_split(
        X, Y, test_size=0.2, random_state=42
    )

    model = LinearRegression()
    model.fit(X_train, Y_train)
    joblib.dump(model, MODEL_PATH)


def predict(features: list[str], values: list[float]) -> int:
    """
    Load model đã train và dự đoán kết quả dựa trên giá trị đầu vào.
    Trả về kết quả làm tròn (int), tối thiểu là 0.
    """
    model  = joblib.load(MODEL_PATH)
    result = model.predict([values])[0]
    kq     = int(round(float(result.ravel()[0])))
    return max(kq, 0)
