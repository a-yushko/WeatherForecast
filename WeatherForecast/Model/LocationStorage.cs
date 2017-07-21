using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WeatherForecast.Model
{
    class LocationStorage : ILocationStorage
    {
        public string SettingsFilename = "settings.xml";
        public AppSettings ReadLocations()
        {
            AppSettings settings;
            XmlSerializer formatter = new XmlSerializer(typeof(AppSettings));
            using (FileStream fs = new FileStream(SettingsFilename, FileMode.OpenOrCreate))
            {
                settings = (AppSettings)formatter.Deserialize(fs);
            }
            return settings;
        }

        public void SaveLocations(AppSettings settings)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(AppSettings));
            using (FileStream fs = new FileStream(SettingsFilename, FileMode.OpenOrCreate | FileMode.Truncate))
            {
                formatter.Serialize(fs, settings);
            }
        }
    }
}
