using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{
    public class WeatherMapProxy //calling to the weatherMapProxy class
    {
       public async static Task<RootObject> GetWeather(double lat, double lon)// passing in the latatude and longatude
        {
            var http = new HttpClient();// calling out to the webservice, you need to install the http client in microsoft.net

            //this is the web site i am pulling the information for the weather,
            //for it to work i needed to get exact lonatude and latatude of galway city, 
            // then set my API key at the end. this is my API key = 7d45e053c3804f8de5e82e570c6dd089

            //this get the response from the web service

            var response = await http.GetAsync("http://api.openweathermap.org/data/2.5/weather?lat=53.2707&lon=-9.0568&units=metric&APPID=7d45e053c3804f8de5e82e570c6dd089");

            var result = await response.Content.ReadAsStringAsync();// getting the response and changing it to a read string

            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            // this is to serializ and deserializ from json thats connected to the RootObject task
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            //this the UTF8 coding that will be used for Json to read
            // memory stream is like data that can come in and go out at differnt speeds
            // like data will come in at one end and be taking out at the other end when needed.


            var data = (RootObject)serializer.ReadObject(ms);
            //this is to get the data out of the serializer
            // and then return the data
            return data;
        }
    }

    /*
     * under is the code that is change from json to csharp
     * from the weather map site i got the json string
     * and changed it to the C Sharp that i needed
     * it generated a serses of classes from json to C sharp for the weather app
    

    */
    /*
     * you need to give each class its own propertys with spechel atribuits 
     * ever class is going to need DataContract, this need to be added on top of ever class. this is a atribut that need s to be added at the top using System.Runtime.Serialization;
     *  and whats in the class is to be treated as a property calling it a DataMamber you need to add this to every membery inside every class
     * 
     */



    [DataContract]//atribuet
    public class Coord
    {

        [DataMember]//property
        public double lon { get; set; }


        [DataMember]//property
        public double lat { get; set; }
    }


    [DataContract]//atribuet
    public class Weather
    {

        [DataMember]//property
        public int id { get; set; }

        [DataMember]//property
        public string main { get; set; }

        [DataMember]//property
        public string description { get; set; }

        [DataMember]//property
        public string icon { get; set; }
    }


    [DataContract]//atribuet
    public class Main
    {

        [DataMember]//property
        public double temp { get; set; }

        [DataMember]//property
        public int pressure { get; set; }

        [DataMember]//property
        public int humidity { get; set; }

        [DataMember]//property
        public double temp_min { get; set; }

        [DataMember]//property
        public double temp_max { get; set; }
        
    }


    [DataContract]//atribuet
    public class Wind
    {

        [DataMember]//property
        public double speed { get; set; }

        [DataMember]//property
        public int deg { get; set; }
    }


    [DataContract]//atribuet
    public class Clouds
    {

        [DataMember]//property
        public int all { get; set; }
        
    }


    [DataContract]//atribuet
    public class Sys
    {

        [DataMember]//property
        public int type { get; set; }

        [DataMember]//property
        public int id { get; set; }

        [DataMember]//property
        public double message { get; set; }

        [DataMember]//property
        public string country { get; set; }

        [DataMember]//property
        public int sunrise { get; set; }

        [DataMember]//property
        public int sunset { get; set; }
    }


    [DataContract]//atribuet
    public class RootObject
    {

        [DataMember]//property
        public Coord coord { get; set; }

        [DataMember]//property
        public List<Weather> weather { get; set; }

        [DataMember]//property
        public string @base { get; set; }

        [DataMember]//property
        public Main main { get; set; }

        [DataMember]//property
        public int visibility { get; set; }

        [DataMember]//property
        public Wind wind { get; set; }

        [DataMember]//property
        public Clouds clouds { get; set; }

        [DataMember]//property
        public int dt { get; set; }

        [DataMember]//property
        public Sys sys { get; set; }

        [DataMember]//property
        public int id { get; set; }

        [DataMember]//property
        public string name { get; set; }

        [DataMember]//property
        public int cod { get; set; }
    }
}
