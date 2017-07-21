using System;
using System.Text;

namespace WeatherForecast.Model
{
    public static class KeyEncoder
    {
        public static string Encode(string key)
        {
            return Base64Encode(key);
        }

        public static string Decode(string key)
        {
            return Base64Decode(key);
        }

        private static string Base64Encode(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(bytes);
        }
        private static string Base64Decode(string data)
        {
            var bytes = Convert.FromBase64String(data);
            return Encoding.UTF8.GetString(bytes);
        }
        private static string XorMask(string data)
        {
            if (String.IsNullOrEmpty(data))
                return data;
            string mask = "vkzlg42l1vd69xtgtgf22y16j6jmbe1g";
            char[] masked = new char[data.Length];
            for(int i = 0; i < data.Length && i < mask.Length; i++)
            {
                masked[i] = (char) (data[i] ^ mask[i]);
            }
            return new string(masked);
        }
    }
}
