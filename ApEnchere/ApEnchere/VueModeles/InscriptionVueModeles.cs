using ApEnchere.Modeles;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.VueModeles
{
    class InscriptionVueModeles : BaseVueModeles
    {

        #region Attributs

        private readonly Api _apiServices = new Api();

        #endregion

        #region Constructeurs

        public InscriptionVueModeles()
        {
            PostUser(new User("test", "test", "test", "test"));
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
