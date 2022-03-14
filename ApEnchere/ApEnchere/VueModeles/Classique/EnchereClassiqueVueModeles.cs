using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApEnchere.VueModeles.Classique
{
     class EnchereClassiqueVueModeles : BaseVueModeles
    {
        #region Attributs
        ObservableCollection<Encherir> _maListeUserEncherir;

        private readonly Api _apiServices = new Api();
        //private int _resultat;
        #endregion

        #region Constructeur
        public EnchereClassiqueVueModeles()
        {
            GetListeUserEncherir();
        }
        #endregion

        #region Getters/Setters
         public ObservableCollection<Encherir> MaListeUserEncherir
        {
            get { return _maListeUserEncherir; }


            set { SetProperty(ref _maListeUserEncherir, value); }
        }

        #endregion

        #region Méthodes
        public async void GetListeUserEncherir()
        {
            MaListeUserEncherir = await _apiServices.GetAllAsync<Encherir>
                   ("api/getUserEncherir", Encherir.CollClasse);
        }

        /*public async void PostEnchere(Encheres uneEnchere)
        {

            Resultat = await _apiServices.PostAsync<Encheres>
                   (uneEnchere, "api/postEnchere");
        }*/
        #endregion
    }
}
