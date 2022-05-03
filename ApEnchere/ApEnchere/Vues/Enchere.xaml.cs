using ApEnchere.VueModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApEnchere.Modeles.Api;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApEnchere.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Enchere : ContentPage
    {
        EnchereVueModeles vueModeles;
        public Enchere(EnchereApi param)
        {
            InitializeComponent();
            BindingContext = vueModeles = new EnchereVueModeles(param);
        }
    }
}