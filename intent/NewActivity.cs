
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace intent
{
    [Activity(Label = "NewActivity")]
    public class NewActivity : AppCompatActivity
    {
        TextView text;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewActivity);

            text = FindViewById<TextView>(Resource.Id.text);

            var intent = Intent;
            string result = intent.GetStringExtra("InOut");
            text.Text = "HELLO " + result;
        }
    }
}