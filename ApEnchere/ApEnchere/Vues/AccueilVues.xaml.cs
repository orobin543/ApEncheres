using ApEnchere.Modeles.Api;
using ApEnchere.VueModeles;
using ApEnchere.Vues.Classique;
using ApEnchere.Vues.Inversee;
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
    public partial class AccueilVues : ContentPage
    {
        AccueilVueModeles vueModel;
        public AccueilVues()
        {
            InitializeComponent();
            BindingContext = vueModel = new AccueilVueModeles();
        }

       /* void Classique_Clicked(object sender, System.EventArgs e)
        {
           Navigation.PushAsync(new InscriptionClassique());
        }*/

        void Inversees_Clicked(object senser, System.EventArgs e)
        {
            Navigation.PushAsync(new InscriptionInversees());
        }

        void Flash_Clicked(object senser, System.EventArgs e)
        {
            Navigation.PushAsync(new InscriptionVues());
        }

        void Inscription_Clicked(object senser, System.EventArgs e)
        {
            Navigation.PushAsync(new InscriptionVues());
        }

        void Test_Clicked(object senser, System.EventArgs e)
        {
            Navigation.PushAsync(new Test());
        }

       /* void RecuperationIdEnchere(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false; //associe l'argument à l'envoie des données

            Navigation.PushAsync(new InscriptionClassique());
        }*/

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (EnchereApi) e.CurrentSelection.FirstOrDefault(); //récupère l'objet 

            Navigation.PushAsync(new InscriptionClassique(current.Id));
        }
    }
}