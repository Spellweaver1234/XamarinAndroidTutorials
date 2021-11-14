using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

namespace PageSlidingTab
{
    public class ContentFragment : Fragment
    {
        private int position;

        public static ContentFragment NewIstance(int position)
        {
            var f = new ContentFragment();
            var b = new Bundle();
            b.PutInt("position", position);
            f.Arguments = b;

            return f;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            position = Arguments.GetInt("position");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var root = inflater.Inflate(Resource.Layout.fragment, container, false);
            var text = root.FindViewById<TextView>(Resource.Id.textView);

            if (position==0)
            {
                text.Text = "Page Android";
            }
            else if (position==1)
            {
                text.Text = "Page IOS";
            }
            else
            {
                text.Text = "Page UWP";
            }

            ViewCompat.SetElevation(root, 50);

            return root;
        }
    }
}