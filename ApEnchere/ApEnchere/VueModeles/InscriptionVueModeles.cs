using ApEnchere.Modeles;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

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

           // int resultat = await _apiServices.PostAsync<User>(unUser, "api/postUser");
            unUser.Id= await _apiServices.PostAsync<User>(unUser, "api/postUser");
            this.StockerId(unUser);
            
        }
        public async void StockerId(User unUser)
            {
                try
                {
                    await SecureStorage.SetAsync("id", unUser.Id.ToString());
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
            }
        #endregion

    }
}
