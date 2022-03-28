using ApEnchere.Modeles.Api;
using ApEnchere.VueModeles;
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

        //aller à la page test
        void Test_SelectionChanged(object senser, SelectionChangedEventArgs e)
        {
            var current = (EnchereApi)e.CurrentSelection.FirstOrDefault(); //récupère l'objet ici l'id de l'enchère

            Navigation.PushAsync(new Test(current.Id));
        }

        //aller sur la page EnchereEnCours en récupérant les données de l'enchère à partir de son id
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (EnchereApi) e.CurrentSelection.FirstOrDefault(); //récupère l'objet ici l'id de l'enchère

            Navigation.PushAsync(new EnchereEnCours(current.Id));
        }

        //aller sur la page Enchere en récupérant les données de l'enchère à partir de son id
        private void SelectionChanged_Enchere(object sender, SelectionChangedEventArgs e)
        {
            var current = (EnchereApi)e.CurrentSelection.FirstOrDefault(); //récupère l'objet ici l'id de l'enchère

            Navigation.PushAsync(new Enchere(current.Id));
        }

        void Test_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
           
        }
    }
}