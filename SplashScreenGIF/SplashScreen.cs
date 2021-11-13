using System.IO;
using System.Timers;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

using AndroidX.AppCompat.App;

using Felipecsl.GifImageViewLibrary;

namespace SplashScreenGIF
{
    [Activity(Label = "SplashScreen", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class SplashScreen : AppCompatActivity
    {
        private GifImageView gifImageView;
        private ProgressBar progressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);

            gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            Stream input = Assets.Open("splash_screen.gif");
            byte[] bytes = ConvertFileToByteArray(input);
            gifImageView.SetBytes(bytes);
            gifImageView.StartAnimation();

            var timer = new Timer();
            timer.Interval = 3000;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StartActivity(new Intent(this, typeof(MainActivity)));
        }

        private byte[] ConvertFileToByteArray(Stream input)
        {
            byte[] buffer = new byte[16*1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}