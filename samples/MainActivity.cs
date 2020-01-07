using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

using Com.Worldpay.Access.Checkout;
using Com.Worldpay.Access.Checkout.Api;
using Com.Worldpay.Access.Checkout.Views;

namespace SampleApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private PANLayout _panView;
        private CardCVVText _cardCVVText;
        private CardExpiryTextLayout _cardExpiryText;
        private Button _submit;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Do();
        }

        private void Do()
        {
            _panView = FindViewById<PANLayout>(Resource.Id.panView);
            _cardCVVText = FindViewById<CardCVVText>(Resource.Id.cardCVVText);
            _cardExpiryText = FindViewById<CardExpiryTextLayout>(Resource.Id.cardExpiryText);
            _submit = FindViewById<Button>(Resource.Id.submit_button);

            var sessionResponseListener = new YourSessionResponseListener();

            var accessCheckoutClient = AccessCheckoutClient.Init(
                "https://try.access.worldpay.com/", // Base API URL
                "",// Your merchant ID
                sessionResponseListener, // SessionResponseListener
                this, // Context
                this // LifecycleOwner
                );

            _submit.Click += (s, e) =>
            {
                var pan = _panView.InsertedText;
                int month = _cardExpiryText.Month;
                int year = _cardExpiryText.Year;
                var cvv = _cardCVVText.InsertedText;

                accessCheckoutClient.GenerateSessionState(pan, month, year, cvv);
            };
        }
    }

    /// <summary>
    /// The <see cref="ISessionResponseListener"/> will receive an update once the session state has been generated.
    /// The listener will also be notified of any errors that could have occurred during the request.
    /// </summary>
    class YourSessionResponseListener : Java.Lang.Object, ISessionResponseListener
    {
        /// <summary>
        /// Method for being notified when the request for the session state starts.
        /// </summary>
        public void OnRequestStarted()
        {

        }

        /// <summary>
        /// Method for being notified when the session state is available, or an error has occurred when trying to generate one
        /// </summary>
        /// <param name="sessionState">(Optional) when the session has been created successfully</param>
        /// <param name="error">
        ///     (Optional) a subclass of <see cref="AccessCheckoutException"/>
        ///     when there has been an error generating the session state
        /// </param>
        public void OnRequestFinished(string sessionState, AccessCheckoutException error)
        {

        }
    }
}

