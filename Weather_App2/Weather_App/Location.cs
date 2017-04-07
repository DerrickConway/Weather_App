using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Weather_App
{
    public class Location
    {
        public async static Task<Geoposition> GetPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();// access the Geolocator

            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();//if access is not allowed to the Geolocator it will throw exception

            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };// get the accuracy of location

            var position = await geolocator.GetGeopositionAsync();// get the current position

            return position;// return position
        }
    }
}
