using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.VueModeles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        MapVueModeles vueModeles;
        public ObservableCollection<EnchereApi> ListeEnchere = new ObservableCollection<EnchereApi>();
        public Map()
        {
            InitializeComponent();
            BindingContext = vueModeles = new MapVueModeles();
            Geolocalisation();
        }
        public async void Geolocalisation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromMiles(10));
                    map.MoveToRegion(mapSpan);
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

           
    }

        private void Pin_MarkerClicked(object sender, PinClickedEventArgs e)
        {
            ListeEnchere.Clear();
            Pin p = (Pin)sender;

            foreach(EnchereApi uneEnchere in vueModeles.MaListeEncheres)
            {
                Position EnchePos = new Position(uneEnchere.LeMagasin.Latitude, uneEnchere.LeMagasin.Longitude);
                if (EnchePos == p.Position)
                {
                    ListeEnchere.Add(uneEnchere);
                }
            }
            Liste.ItemsSource = ListeEnchere;
        }

    }

}