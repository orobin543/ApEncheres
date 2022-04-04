using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using ApEnchere.VueModeles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionVues : ContentPage
    {
        InscriptionVueModeles vueModeles;
        public InscriptionVues()
        {
            InitializeComponent();
            BindingContext = vueModeles = new InscriptionVueModeles();

        }

        async void AjoutPhoto(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

                (sender as Button).IsEnabled = true;
        }

        private void Accueil_Clicked(object sender, EventArgs e)
        {
            //Creation du USER

            User unUser = new User(Email.Text, Password.Text, Pseudo.Text, Photo.Text);
            vueModeles.PostUser(unUser);

            Navigation.PushAsync(new AccueilVues(), true);
        }
    }
}