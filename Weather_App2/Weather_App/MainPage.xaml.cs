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
            try
            {
                var position = await Location.GetPosition();

                RootObject myWeather =
                    await WeatherMapProxy.GetWeather(
                        position.Coordinate.Latitude,
                        position.Coordinate.Longitude);

                String icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
                // String icon = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);

                ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

                // ResultTextBlock.Text = myWeather.name + " - " + myWeather.main.temp + " - " + myWeather.weather[0].description;


                ResultTextBlock.Text = myWeather.name + " - " + myWeather.main.temp + " - " + myWeather.weather[0].description;

            /*   TempTextBlock.Text = ((int)myWeather.main.temp).ToString();
                DescriptionTextBlock.Text = myWeather.weather[0].description;
                LocationTextBlock.Text = myWeather.name;*/
            }

            catch
            {
                ResultTextBlock.Text = "Unable to get Weather";

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
    }
}
