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

        //aller sur la page EnchereEnCours en récupérant les données de l'enchère
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnchereApi current = (EnchereApi) e.CurrentSelection.FirstOrDefault(); //récupère l'objet ici l'enchère

            Navigation.PushAsync(new EnchereEnCours(current), true);
        }

        //aller sur la page Enchere en récupérant les données de l'enchère
        private void SelectionChanged_Enchere(object sender, SelectionChangedEventArgs e)
        {
            EnchereApi current = (EnchereApi)e.CurrentSelection.FirstOrDefault(); //récupère l'objet ici l'enchère

            Navigation.PushAsync(new Enchere(current), true);
        }

       /* private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Application.Current.MainPage = new Enchere(current);
        }*/
        private void classique_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = true;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;

        }

        private void inverse_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = true;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;
        }

        private void flash_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await remonte.ScrollToAsync(0, 0, true);

        }

        void Test_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new Test());
        }

        //Guide vers la page de map
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Map());
        }
    }
}