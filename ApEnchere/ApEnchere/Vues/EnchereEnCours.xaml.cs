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
    public partial class EnchereEnCours : ContentPage
    {
        EnchereEnCoursVueModeles vueModeles;
        public EnchereEnCours(int param)
        {
            InitializeComponent();
            BindingContext = vueModeles = new EnchereEnCoursVueModeles(param);

            //On ajoute une méthode pour l'obliger à le faire travailler en async
           
           /*Task.Run(async () =>
            {
                EnchereApi uneEnchère = await vueModeles.GetLaEnchere(param);
            });
         */   
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void AjoutUserEncheri_Clicked(object sender, EventArgs e)
        {

        }
    }
}