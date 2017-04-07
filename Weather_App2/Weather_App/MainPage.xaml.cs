using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //  ResultTextBlock.Text = "Unable to get Weather";
            try
            {
                var position = await Location.GetPosition();//get local position from location.cs

                RootObject myWeather =
                    await WeatherMapProxy.GetWeather(
                        position.Coordinate.Latitude,
                        position.Coordinate.Longitude);//get the cordenits from the openweatherproxy

                String icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
                // String icon = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);

                ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //pulling the icons from the weather folder i added with my own icons

                // ResultTextBlock.Text = myWeather.name + " - " + myWeather.main.temp + " - " + myWeather.weather[0].description;


                ResultTextBlock.Text = myWeather.name + " - " + myWeather.main.temp + " - " + myWeather.weather[0].description;

            /*   TempTextBlock.Text = ((int)myWeather.main.temp).ToString();
                DescriptionTextBlock.Text = myWeather.weather[0].description;
                LocationTextBlock.Text = myWeather.name;
            */
            }

            catch
            {
                ResultTextBlock.Text = "Unable to get Weather";
                //if unable to get weather print this
            }


           /* var position = await Location.GetPosition();

            RootObject myWeather = 
                await WeatherMapProxy.GetWeather(
                    position.Coordinate.Latitude,
                    position.Coordinate.Longitude);

            String icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
           // String icon = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);

            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

           // ResultTextBlock.Text = myWeather.name + " - " + myWeather.main.temp + " - " + myWeather.weather[0].description;

            TempTextBlock.Text = myWeather.main.temp.ToString();
            DescriptionTextBlock.Text = myWeather.weather[0].description;
            LocationTextBlock.Text = myWeather.name;*/
        }

        // trying to get the tiles to work

        /*  private void ChangeTileContentButton_click(object sender, RoutedEventArgs e)
         {

             var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);

             var tileAttributes = tileXml.GetElementsByTagName("text");
             tileAttributes[0].AppendChild(tileXml.CreateTextNode(MyTextBlock.Text));
             var tileNotification = new TileNotification(tileXml);
             TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
         }
         // trying to get tiles to update every half hour
         private void ScheduleNotificationButton_Click(object sender, RoutedEventArgs e)
         {

             var TileContent = new Uri("");
             var requestedInterval = PeriodicUpdateRecrrence.HalfHour;

             var update = TileUpdateManager.CreateTileUpdaterForApplication();
             updater.StartPeriodicUpdate(TileContent, requestedInterval);
         }*/
    }
}
