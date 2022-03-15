using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Connexion_Clicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new Connexion());
            Navigation.PushAsync(new AccueilVues());
        }

        private void Inscription_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InscriptionVues());
        }

        private void SansConnexion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccueilVues());
        }
    }
}