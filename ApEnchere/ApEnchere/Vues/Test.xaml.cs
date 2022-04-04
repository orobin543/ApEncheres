﻿using ApEnchere.Modeles;
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
    }
}