﻿using System;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Widget.AdapterView;
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
        //string result;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DataList);

            my_toolbar = FindViewById<V7Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(my_toolbar);

            infoBase = FindViewById<ListView>(Resource.Id.infoBase);
            infoBase.ItemClick += InfoBase_ItemClick;


            //var intent = Intent; 
            //result = intent.GetStringExtra("InOut");

            var db = new SQLite.SQLiteConnection(dbPath);
            var table = db.Table<DataBase>();

            ArrayAdapter<DataBase> adapter = new ArrayAdapter<DataBase>(this, Android.Resource.Layout.SimpleListItem1, table.ToList());
            infoBase.Adapter = adapter;
            

        }

        private void InfoBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(NewActivity));
            intent.PutExtra("InOut", infoBase.GetItemAtPosition(e.Position).ToString());
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


                case Android.Resource.Id.Home:
                    Finish();
                    return true;


                case Resource.Id.toBD:
                    Toast.MakeText(this, "Вы находитесь в базе данных", ToastLength.Short).Show();
                    var intent = new Intent(this, typeof(DataList));
                    StartActivity(intent);
                    return true;

                case Resource.Id.toHelloItem:
                    Toast.MakeText(this, "Вас переместили в экран приветствия", ToastLength.Long).Show();
                    intent = new Intent(this, typeof(NewActivity));
                    StartActivity(intent);
                    return true;

                case Resource.Id.toNewItem:
                    Toast.MakeText(this, "Вас отправили на начальный экран", ToastLength.Long).Show();
                    intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}