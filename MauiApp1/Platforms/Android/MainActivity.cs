using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Views;
using AndroidX.Core.App;
using Firebase;
using Firebase.Messaging;
using MauiApp1.Services;
using Microsoft.Maui.Storage;
using Plugin.Fingerprint;


namespace MauiApp1
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation |
                                     ConfigChanges.UiMode | ConfigChanges.ScreenLayout |
                                     ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);





            #region "TOKEN"

            // Register the Firebase token retriever service to handle the retrieval and storage of the Firebase Cloud Messaging token.
            DependencyService.Register<FirebaseTokenRetriever>();

            // Get the application context. This is used to initialize FirebaseApp.
            var context = Android.App.Application.Context;

            // Check if FirebaseApp is initialized. If not, then initialize it.
            // FirebaseApp is required to use any of the Firebase services.
            if (FirebaseApp.GetApps(this).Count == 0) // if no FirebaseApp is available
            {
                // Initialize FirebaseApp here
                var app = Firebase.FirebaseApp.InitializeApp(Android.App.Application.Context);

                if (app == null)
                {
                    // If the app is null, then build a FirebaseOptions object with the necessary parameters 
                    // and use it to initialize the FirebaseApp.
                    var options = new FirebaseOptions.Builder()
                        .SetApplicationId("1:384379970342:android:b79d966635d0bd6c6d17e7") // Set your own app id here
                        .SetApiKey("AIzaSyBaMyM8atgYpFg5joO6GaE9P0_X5Ew3MXg") // Set your own api key here
                        .SetProjectId("dnademo-e28c0")
                        .Build();

                    app = Firebase.FirebaseApp.InitializeApp(Android.App.Application.Context, options);
                }
            }

            // Attempt to retrieve the FCM token.
            try
            {
                // Get the FCM token
                var tokenResult = FirebaseMessaging.Instance.GetToken();
                string fcmToken = (string)tokenResult;

                // Save the FCM token for later use
                var tokenRetriever = DependencyService.Get<IFirebaseTokenRetriever>();
                tokenRetriever.SaveToken(fcmToken);

                // Log the FCM token for debugging purposes
                Log.Debug("MainActivity", $"FCM registration token: {fcmToken}");
            }
            catch (Exception e)
            {
                // Log a warning if fetching the FCM token fails
                Log.Warn("MainActivity", "Fetching FCM registration token failed", e);
            }

            #endregion

            #region "Chanel"

            // Android 8.0 (API level 26) introduced notification channels, which are essentially categories that users 
            // can customize to change the behavior of notifications coming from those channels.
            // In this region, we are creating a notification channel for our app notifications.
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                // Define the notification channel
                var name = "App Notifications";
                var description = "Notifications for new Track Log";
                var importance = NotificationImportance.High; // For chat messages, high importance makes sense
                var channel = new NotificationChannel("Any_Name_CHANNEL", name, importance)
                {
                    Description = description
                };

                // Enable lights for the notification
                channel.EnableLights(true);
                // If the device supports it, set the light color
                channel.LightColor = Android.Graphics.Color.Red;
                // Enable vibration for the notification
                channel.EnableVibration(true);
                // Set the vibration pattern.
                channel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 100 });
                // Show badge on app icon
                channel.SetShowBadge(true);

                // Create the notification channel
                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }

            #endregion

            // Check if notifications are enabled
            // If not, then show a dialog to the user asking them to enable notifications.
            bool areNotificationsEnabled = IsNotificationsEnabled();
            if (!IsNotificationsEnabled())
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Enable Notifications");
                builder.SetMessage("Notifications are currently disabled. Would you like to enable them?");
                builder.SetPositiveButton("Yes", (sender, e) =>
                {
                    // This intent takes the user to the app's settings page where they can enable notifications
                    Intent intent = new Intent();
                    intent.SetAction(Android.Provider.Settings.ActionAppNotificationSettings);

                    // For Android 5-7
                    intent.PutExtra("app_package", this.PackageName);
                    intent.PutExtra("app_uid", this.ApplicationInfo.Uid);

                    // For Android 8 and above
                    intent.PutExtra(Android.Provider.Settings.ExtraAppPackage, this.PackageName);

                    StartActivity(intent);
                });
                builder.SetNegativeButton("No", (sender, e) => { /* Do nothing */ });
                builder.Show();
            }


            // Ensure UI adjusts when the keyboard appears
            Window.SetSoftInputMode(SoftInput.AdjustResize);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu) // Android 13+
            {
                var status = Permissions.CheckStatusAsync<Permissions.PostNotifications>().Result;
                if (status != PermissionStatus.Granted)
                {
                    Permissions.RequestAsync<Permissions.PostNotifications>();
                }
            }

        }

        // Check if notifications are enabled.
        // For Android 8.0 (API level 26) and above, this means checking if any notification channels are disabled.
        // For Android 7.1 (API level 25) and below, this means checking if notifications are disabled at the app level.
        private bool IsNotificationsEnabled()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationManager manager = (NotificationManager)GetSystemService(NotificationService);
                if (!manager.AreNotificationsEnabled())
                {
                    return false;
                }
                var channels = manager.NotificationChannels;
                foreach (var channel in channels)
                {
                    if (channel.Importance == NotificationImportance.None)
                    {
                        return false;
                    }
                }
            }
            else
            {
                var areNotificationsEnabled = NotificationManagerCompat.From(this).AreNotificationsEnabled();
                if (!areNotificationsEnabled)
                {
                    return false;
                }
            }
            return true;
        }

    }
}