using Android.Support.V4.App;

using Java.Lang;

namespace PageSlidingTab
{
    class MyAdapter : FragmentPagerAdapter
    {
        int tabCount = 3;

        public MyAdapter(FragmentManager fm) : base(fm)
        {

        }

        public override int Count => tabCount;

        public override Fragment GetItem(int position)
        {
            return ContentFragment.NewIstance(position);
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return position switch
            {
                0 => new String("Android"),
                1 => new String("IOS"),
                _ => new String("Android")
            };
        }
    }
}