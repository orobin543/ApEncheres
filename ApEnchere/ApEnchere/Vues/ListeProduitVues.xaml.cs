﻿using ApEnchere.VueModeles;
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
    public partial class ListeProduitVues : ContentPage
    {
        ListeProduitVueModele vueModel;
        public ListeProduitVues()
        {
            InitializeComponent();
            BindingContext = vueModel = new ListeProduitVueModele();

        }
    }
}