using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        void Accueil_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}