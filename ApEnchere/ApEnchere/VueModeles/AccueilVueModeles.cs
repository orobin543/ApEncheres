using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApEnchere.VueModeles
{
    class AccueilVueModeles : BaseVueModeles
    {
        #region Attributs
        ObservableCollection<EnchereApi> _maListeEncheres;
        ObservableCollection<EnchereApi> _maListeEnchereEnCours;

        private readonly Api _apiServices = new Api();
        //private int _resultat;
        #endregion

        #region Constructeur
        public AccueilVueModeles()
        {
            GetListeEncheres();
            GetListeEnchereEnCours();
        }
        #endregion

        #region Getters/Setters
        // public ObservableCollection<EnchereApi> MaListeEncheres { get => _maListeEncheres; set => _maListeEncheres = value; }


        public ObservableCollection<EnchereApi> MaListeEncheres
        {
            get { return _maListeEncheres; }


            set { SetProperty(ref _maListeEncheres, value); }
        }

        public ObservableCollection<EnchereApi> MaListeEnchereEnCours
        {
            get { return _maListeEnchereEnCours; }

            set { SetProperty(ref _maListeEnchereEnCours, value); }
        }


        #endregion

        #region Méthodes
        public async void GetListeEncheres()
        {
            MaListeEncheres = await _apiServices.GetAllAsync<EnchereApi>
                   ("api/getEnchere", EnchereApi.CollClasse);
        }

        public async void GetListeEnchereEnCours()
        {
            MaListeEnchereEnCours = await _apiServices.GetAllAsync<EnchereApi>
                   ("api/getEncheresEnCours", EnchereApi.CollClasse);
        }

        /*public async void PostEnchere(Encheres uneEnchere)
        {

            Resultat = await _apiServices.PostAsync<Encheres>
                   (uneEnchere, "api/postEnchere");
        }*/

       
        #endregion
    }
}
