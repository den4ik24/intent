using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace intent
{
    [Activity(Label = "База Друзей")]
    public class DataList : AppCompatActivity
    {
        
        string dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "dataBase.db3");

        V7Toolbar my_toolbar;
        ListView infoBase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DataList);

            my_toolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(my_toolbar);

            infoBase = FindViewById<ListView>(Resource.Id.infoBase);
            //infoBase.ItemClick += InfoBase_ItemClick;

            var intent = Intent;
            string result = intent.GetStringExtra("InOut");

            var db = new SQLite.SQLiteConnection(dbPath);
            var table = db.Table<DataBase>();

            ArrayAdapter<DataBase> adapter = new ArrayAdapter<DataBase>(this, Android.Resource.Layout.SimpleListItem1, table.ToList());
            infoBase.Adapter = adapter;

        }

        //private void InfoBase_ItemClick(object sender, System.EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(NewActivity));
        //    intent.PutExtra("InOut",   );
        //    StartActivity(intent); 
        //}

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

   
                case Resource.Id.toNewItem:
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    return true;



                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}