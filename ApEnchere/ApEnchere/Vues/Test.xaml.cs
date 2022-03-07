using ApEnchere.Modeles;
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
        public Test()
        {
            InitializeComponent();
            BindingContext = vueModel = new TestVueModeles();
        }

    }
}