using MAUIAPI.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;


namespace MAUIAPI.Controllers
{
    public class PushNotificationController : Controller
    {

        private async Task SendPushNotification(string token, DevicePlatform platform, string payload/*, AuthenType authenType*/)
        {
            switch (platform)
            {
                case DevicePlatform.Android:

                    var notfiObj = new NotificationAlert()
                    {
                        data = new Data()
                        {
                            notification = new Notification()
                            {
                                alert = " Auth Request",
                                backgroundImage = "http://ebanking.azurewebsites.net/images/1.png",
                                backgroundImageTextColour = "#FFFFFF",
                                badge = 1,
                                body = "Login Request",
                                category = "Authentication",
                                channel = "PFO",
                                colour = "White",
                                groupIcon = "test",
                                groupKey = "PFO",
                                groupSummary = "PFO",
                                groupTitle = "PFO",
                                icon = "http://ebanking.azurewebsites.net/images/4.png",
                                largeIcon = "http://ebanking.azurewebsites.net/images/1.png",
                                priority = "high",
                                sound = "default",
                                TimeToLiveInSeconds = 120,
                                style = new Style()
                                {
                                    image = "http://ebanking.azurewebsites.net/images/4.png",
                                    lines = new System.Collections.Generic.List<string>() { " Authentication Request" },
                                    text = "PF Authentication Request",
                                    type = "text"
                                },
                                title = "PFO Auth Request",
                                vibrate = "true"
                            },
                            //messageType = authenType.ToString(),
                            payload = payload
                        },
                    };

                    FcmNotification fcmNotification = new FcmNotification(JsonConvert.SerializeObject(notfiObj));
                    await Notifications.Instance.Hub.SendDirectNotificationAsync(fcmNotification, token);

                    break;
                case DevicePlatform.iOS:
                    {
                        var notification = new ApnsNotification()
                        {
                            aps = new Aps()
                            {
                                alert = new Alert()
                                {
                                    body = " Authentication Request",
                                    title = "Login Request"
                                },
                                badge = 1,
                                sound = "default",
                                vibrate = "true",
                                ContentAvialble = "1"
                            },
                            //messageType = authenType.ToString(),
                            payload = payload
                        };
                        AppleNotification iosfcmNotification = new AppleNotification(JsonConvert.SerializeObject(notification));
                        iosfcmNotification.Priority = 10;
                        iosfcmNotification.ContentType = "application/json";
                        await Notifications.Instance.Hub.SendDirectNotificationAsync(iosfcmNotification, token);
                    }
                    break;
            }
        }

    }
}
