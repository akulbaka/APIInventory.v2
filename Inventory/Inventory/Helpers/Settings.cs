using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace Inventory.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string Username
        {
            get
            {

                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }
        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static DateTime AccessTokenExpirationDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessTokenExpirationDate", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessTokenExpirationDate", value);
            }
        }

        public static string SetTrainId
        {
            get
            {
                return AppSettings.GetValueOrDefault("TrainId", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("TrainId", value);
            }
        }

        public static string SetLineId
        {
            get
            {
                return AppSettings.GetValueOrDefault("LineId", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("LineId", value);
            }
        }

        public static string TempString
        {
            get
            {
                return AppSettings.GetValueOrDefault("TempString", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("TempString", value);
            }
        }
    }
}