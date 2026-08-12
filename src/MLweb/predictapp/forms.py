from django import forms


class SimpleCSVUploadForm(forms.Form):
    # Dùng FileField để người dùng chọn file
    csv_file = forms.FileField(
        label='Chọn File CSV của bạn',
        help_text='Tập tin phải là định dạng CSV.'
    )