using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using Android.Views;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System.IO;
using SQLite;
using System;

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

            //text.Text = "";
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

         

            var intent = new Intent(this, typeof(NewActivity));
            intent.PutExtra("InOut", text.Text);

            StartActivity(intent);
            
            Res();

            text.Text = "";
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
                    Toast.MakeText(this, "Вас отправлено в базу данных", ToastLength.Long).Show();
                    var intent = new Intent(this, typeof(DataList));
                    StartActivity(intent);
                    return true;

                case Resource.Id.toHelloItem:
                    Toast.MakeText(this, "Вас переместили в экран приветствия", ToastLength.Long).Show();
                    intent = new Intent(this, typeof(NewActivity));
                    StartActivity(intent);
                    return true;

                case Resource.Id.toNewItem:
                    Toast.MakeText(this, "Вы находитесь в начале вашего пути", ToastLength.Short).Show();
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
            DataBase dataBase = new DataBase(text.Text);
            db.Insert(dataBase);
            var table = db.Table<DataBase>();

        }
    }
}