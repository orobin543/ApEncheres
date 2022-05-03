using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.VueModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        TestVueModeles vueModel;
        public Xamarin.Forms.Color BarBackgroundColor { get; set; }
        public Test()
        {
            InitializeComponent();
            BindingContext = vueModel = new TestVueModeles();

            /*  //On ajoute une méthode pour l'obliger à le faire travailler en async
              Task.Run(async () =>
              {
                  EnchereApi uneEnchère = await vueModel.GetLaEnchere(param);
              });*/
        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            EnchereApi current = (EnchereApi)e.CurrentSelection.FirstOrDefault(); //récupère l'objet ici l'enchère

            Navigation.PushAsync(new EnchereEnCours(current), true);
        }
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
    }
}