using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;

using Java.Lang;

namespace PageSlidingTabStrip
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public class MyAdapter : FragmentPagerAdapter
        {
            int tabCount = 3; 

            public MyAdapter(AndroidX.Fragment.App.FragmentManager fm):base(fm)
            {

            }

            public override int Count => tabCount;

            public override AndroidX.Fragment.App.Fragment GetItem(int position)
            {
                throw new System.NotImplementedException();
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return position switch
                {
                    0 => new String("Android"),
                    1 => new String("IOS"),
                    _ => new String("Android"),
                };
            }
        }
    }
}