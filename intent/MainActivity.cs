using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;

namespace intent
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText editText;
        Button button1;

                     
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            editText = FindViewById<EditText>(Resource.Id.editText);
            button1 = FindViewById<Button>(Resource.Id.button1);

            

            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(NewActivity));
            intent.PutExtra("InOut", editText.Text);
            StartActivity(intent);
        }
    }
}