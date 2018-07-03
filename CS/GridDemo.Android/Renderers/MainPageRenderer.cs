using Xamarin.Forms.Platform.Android;
using Android.Views;
using Xamarin.Forms;
using Android.Content;

[assembly: ExportRenderer(typeof(DevExpress.GridDemo.MainPage), typeof(DevExpress.GridDemo.Android.MainPageRenderer))]
namespace DevExpress.GridDemo.Android {
    public class MainPageRenderer : MasterDetailRenderer {
        public MainPageRenderer(Context context) : base(context) { }

        public override bool OnInterceptTouchEvent(MotionEvent ev) {
            bool result = base.OnInterceptTouchEvent(ev);
            if (Element == null)
                return result;

            if (Device.Idiom == TargetIdiom.Tablet && IsInLandscape())
                result = false;
            
            return result;
        }

        internal bool IsInLandscape() {
            return global::Android.App.Application.Context.Resources.Configuration.Orientation == global::Android.Content.Res.Orientation.Landscape;
        }
    }
}
