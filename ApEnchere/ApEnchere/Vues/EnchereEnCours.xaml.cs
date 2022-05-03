using ApEnchere.Modeles.Api;
using ApEnchere.VueModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnchereEnCours : ContentPage
    {
        EnchereEnCoursVueModeles vueModeles;
        public EnchereEnCours(EnchereApi param)
        {
            InitializeComponent();
            BindingContext = vueModeles = new EnchereEnCoursVueModeles(param);

        //On ajoute une méthode pour l'obliger à le faire travailler en async
        /*Task.Run(async () =>
         {
             EnchereApi uneEnchère = await vueModeles.GetLaEnchere(param);
             Thread.Sleep(10000);
         });*/
        }

        protected override void OnDisappearing() //lance la méthode lorsqu'on quitte la page
        {
            vueModeles.OnCancel = true;
            base.OnDisappearing();
        }

    }

}