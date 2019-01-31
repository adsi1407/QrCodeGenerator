using Foundation;
using UIKit;

namespace QRCodeGenerator.Touch
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var mainController = new MainViewController();
            Window.RootViewController = new UINavigationController(mainController);
            Window.MakeKeyAndVisible();
            return true;
        }
    }
}

