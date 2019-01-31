using System;
using CoreGraphics;
using UIKit;
using ZXing.Mobile;

namespace QRCodeGenerator.Touch
{
    public class MainViewController: UIViewController
    {
        private UITextField textFieldTextToCode;
        private UIButton buttonGenerateCode;
        private UIImageView imageViewQrCode;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Title = "QrCodeGenerator";
            SetupViews();
        }

        private void SetupViews()
        {
            textFieldTextToCode = new UITextField();
            textFieldTextToCode.Frame = new CGRect(10, 100, 300, 44);
            textFieldTextToCode.BackgroundColor = UIColor.LightGray;

            View.AddSubview(textFieldTextToCode);

            buttonGenerateCode = UIButton.FromType(UIButtonType.System);
            buttonGenerateCode.Frame = new CGRect(10, 180, 300, 44);
            buttonGenerateCode.SetTitle("Generate", UIControlState.Normal);
            buttonGenerateCode.TouchUpInside += ButtonGenerateCode_TouchUpInside;;
            View.AddSubview(buttonGenerateCode);

            imageViewQrCode = new UIImageView();
            imageViewQrCode.Frame = new CGRect(10, 240, 60, 60);
            View.AddSubview(imageViewQrCode);
        }

        private void ButtonGenerateCode_TouchUpInside(object sender, EventArgs e)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Margin = 1
            };

            UIImage qrImage = barcodeWriter.Write(textFieldTextToCode.Text);
            imageViewQrCode.Image = qrImage;
        }

    }
}
