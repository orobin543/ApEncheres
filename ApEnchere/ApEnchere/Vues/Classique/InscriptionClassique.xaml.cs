using ApEnchere.Modeles;
using ApEnchere.Services;
using ApEnchere.VueModeles.Classique;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues.Classique
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionClassique : ContentPage
    {
        InscriptionClassiqueVueModeles vueModeles;
        public InscriptionClassique(int param)
        {
            InitializeComponent();
            BindingContext = vueModeles = new InscriptionClassiqueVueModeles(param);
            
        }

        void PlaceEnchereClassique(object sender, System.EventArgs e)
        {
            //Creation du USER

            User unUser = new User(Email.Text, Password.Text, Pseudo.Text, Photo.Text);
            vueModeles.PostUser(unUser);


            Navigation.PushAsync(new EnchereClassiques());
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


    }
}