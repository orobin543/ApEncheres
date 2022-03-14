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
    public partial class ValidationClassique : ContentPage
    {
        public ValidationClassique()
        {
            InitializeComponent();
        }

        void Accueil_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}