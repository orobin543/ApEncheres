using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.VueModeles.Classique
{
    class InscriptionClassiqueVueModeles : BaseVueModeles
    {
        #region Attributs

        private readonly Api _apiServices = new Api();

        #endregion

        #region Constructeurs

        public InscriptionClassiqueVueModeles(int param)
        {
            //PostUser(new User("tes1t", "tes1t", "test", "test"));

        }

        #endregion

        #region Getters/Setters

        #endregion

        #region Methodes
        public async void PostUser(User unUser)
        {

            int resultat = await _apiServices.PostAsync<User>(unUser, "api/postUser");

            
        }
        #endregion
    }
}
