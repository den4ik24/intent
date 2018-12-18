using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using SQLite;
using System.IO;
using System.Linq;

namespace intent
{
    [Activity(Label = "привет Друг")]
    public class NewActivity : AppCompatActivity
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3");

        TextView name;
        V7Toolbar my_toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewActivity);

            name = FindViewById<TextView>(Resource.Id.name);
            my_toolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(my_toolbar);

            var intent = Intent;
            string result = intent.GetStringExtra("InOut");
            name.Text = result;
            Res();
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

        public void Res()
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<DataBase>();
            DataBase dataBase = new DataBase(name.Text);
            db.Insert(dataBase);
            var table = db.Table<DataBase>();

        }
    }
}