using ApEnchere.Modeles;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApEnchere.VueModeles
{
    class ListeProduitVueModele : BaseVueModeles
    {
        #region Attributs
        private ObservableCollection<Produit> _maListeProduits;
        private readonly Api _apiServices = new Api();
        private int _resultat;
        #endregion

        #region Constructeurs

        public ListeProduitVueModele()
        {
            Resultat = 0;
            PostProduit(new Produit(0, "test", "test", 10));
            GetListeProduits();
        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Produit> MaListeProduits { get => _maListeProduits; set => _maListeProduits = value; }
        public int Resultat { get => _resultat; set => _resultat = value; }

        #endregion

        #region Methodes
        public async void GetListeProduits()
        {
            MaListeProduits = await _apiServices.GetAllAsync<Produit>
                   ("api/getProduits", Produit.CollClasse);
        }

        public async void PostProduit(Produit unProduit)
        {

            Resultat = await _apiServices.PostAsync<Produit>
                   (unProduit, "api/postProduit");
        }
        #endregion


    }
}