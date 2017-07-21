using System;
using System.IO;

namespace WeatherForecast.Model
{
    public class KeyReader
    {
        private readonly string _path;

        public KeyReader(string path)
        {
            _path = path;
        }

        public string DarkSkyKey
        {
            get
            {
                try
                {
                    var key = File.ReadAllText(_path);
                    return key.Substring(0, 32);
                }
                catch (IOException e)
                {
                    throw new InvalidOperationException(Resources.ErrorNoKey, e);
                }
                catch (UnauthorizedAccessException e)
                {
                    throw new InvalidOperationException(Resources.ErrorNoPermission, e);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(Resources.ErrorInvalidKey, e);
                }
            }
        }

        public string GeoNamesKey
        {
            get
            {
                try
                {
                    var key = File.ReadAllText(_path);
                    return KeyEncoder.Decode(key.Substring(32));
                }
                catch (IOException e)
                {
                    throw new InvalidOperationException(Resources.ErrorNoKey, e);
                }
                catch (UnauthorizedAccessException e)
                {
                    throw new InvalidOperationException(Resources.ErrorNoPermission, e);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(Resources.ErrorInvalidKey, e);
                }
            }
        }
    }
}
