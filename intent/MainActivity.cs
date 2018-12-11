using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using Android.Views;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System.IO;

namespace intent
{
    [Activity(Label = "Ввод данных", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText text;
        Button button1;
        V7Toolbar my_toolbar;

        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            text = FindViewById<EditText>(Resource.Id.editText);
            button1 = FindViewById<Button>(Resource.Id.button1);
            my_toolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(my_toolbar);


            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(NewActivity));
            intent.PutExtra("InOut", text.Text);
            StartActivity(intent);
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
                case Resource.Id.toBD:
                    var intent = new Intent(this, typeof(DataList));
                    StartActivity(intent);
                    return true;


                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}