using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApEnchere.VueModeles.Inversees;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues.Inversee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionInversees : ContentPage
    {
        InscriptionInverseesVueModeles vueModel;

        public InscriptionInversees()
        {
            InitializeComponent();
            BindingContext = vueModel = new InscriptionInverseesVueModeles();
        }

        void PlaceEnchereInversees(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EnchereInversees());
        }
    }
}