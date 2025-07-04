using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;

namespace MAUIAPI
{
 
        public class Notifications
        {
            public static Notifications Instance = new Notifications();

            public NotificationHubClient Hub { get; set; }

            private Notifications()
            {
                Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://xsenseone.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=O7kjV+vnRx4enk+5oxwRHOLlzy246ev1n51ex7hAcQc=", "xsenseone");
            }
        }
        public class Style
        {

            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string text { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> lines { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string image { get; set; }
        }

        public class Notification
        {

            /// <summary>
            /// 
            /// </summary>
            public string icon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string alert { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string body { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sound { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string vibrate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string largeIcon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string priority { get; set; }


            [JsonProperty("time_to_live")]
            public int TimeToLiveInSeconds { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public int badge { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string colour { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string channel { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string backgroundImage { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string backgroundImageTextColour { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Style style { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string groupIcon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string groupKey { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string groupTitle { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string groupSummary { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string category { get; set; }
        }

        public class Data
        {

            /// <summary>
            /// 
            /// </summary>
            public Notification notification { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string messageType { get; set; }

            public string payload { get; set; }
        }

        public class NotificationAlert
        {

            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
        }

        public class Alert
        {
            public string body { get; set; }
            public string title { get; set; }
        }

        public class Aps
        {
            public Alert alert { get; set; }
            public int badge { get; set; }
            public string sound { get; set; }
            public string vibrate { get; set; }

            [JsonProperty("content-available")]
            public string ContentAvialble { get; set; }

        }

        public class ApnsNotification
        {
            public Aps aps { get; set; }

            public string messageType { get; set; }
            public string payload { get; set; }
        }
    }
