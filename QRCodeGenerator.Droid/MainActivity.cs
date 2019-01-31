using Android.App;
using Android.Widget;
using Android.OS;
using System;
using ZXing.Mobile;
using Android.Graphics;

namespace QRCodeGenerator.Droid
{
    [Activity(Label = "QRCodeGenerator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private EditText editTextTextToCode;
        private Button buttonGenerateCode;
        private ImageView imageViewQrCode;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            SetViews();
        }

        private void SetViews()
        {
            editTextTextToCode = (EditText)FindViewById(Resource.Id.editText_textToCode);
            buttonGenerateCode = (Button)FindViewById(Resource.Id.button_generateCode);
            imageViewQrCode = (ImageView)FindViewById(Resource.Id.imageView_qrCode);

            buttonGenerateCode.Click += ButtonGenerateCode_Click;
        }

        private void ButtonGenerateCode_Click(object sender, EventArgs e)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Height = 600,
                Width = 600,
                Margin = 1
            };

            Bitmap qrBitmap =  barcodeWriter.Write(editTextTextToCode.Text);
            imageViewQrCode.SetImageBitmap(qrBitmap);
        }

    }
}

