using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using System.IO;
using System;

namespace intent
{
    [Activity(Label = "привет, друг")]
    public class NewActivity : AppCompatActivity
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3");

        TextView name;
        V7Toolbar my_toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {


                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.NewActivity);

                name = FindViewById<TextView>(Resource.Id.name);
                my_toolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
                SetSupportActionBar(my_toolbar);


                var intent = Intent;
                string result = intent.GetStringExtra("InOut");
                char[] sReverse = result.ToCharArray();
                Array.Reverse(sReverse);
                result = new string(sReverse);
                name.Text = result;
            }

            catch (Exception)
            {

            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                case Resource.Id.toBD:
                    var intent = new Intent(this, typeof(DataList));
                    StartActivity(intent);
                    return true;

                case Resource.Id.toNewItem:
                    intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    return true;


                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        
    }
}