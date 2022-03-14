using ApEnchere.VueModeles.Classique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues.Classique
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnchereClassiques : ContentPage
    {
        EnchereClassiqueVueModeles vueModeles;
        public EnchereClassiques()
        {
            InitializeComponent();
            BindingContext = vueModeles = new EnchereClassiqueVueModeles();
        }

        void EncherirClassique (object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ValidationClassique());
        }
    }
}