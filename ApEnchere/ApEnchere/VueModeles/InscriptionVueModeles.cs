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
            PostUser(new User("testgg", "tggjhhest", "tehgjhhghjst", "thjjjhest"));
        }

        #endregion

        #region Getters/Setters

        #endregion

        #region Methodes
        public async void PostUser(User unUser)
        {
            unUser.Id= await _apiServices.PostAsync<User>(unUser, "api/postUser");
            this.StockerId(unUser);
            this.StockerPseudo(unUser);
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

        public async void StockerPseudo(User unUser)
        {
            try
            {
                await SecureStorage.SetAsync("pseudo", unUser.Pseudo);

            }

            catch (Exception ex)
            {
                //Possible that device doesn't support secure storage on device.
            }
        }

        public async void StockerPhoto(User unUser)
        {
            try
            {
                await SecureStorage.SetAsync("photo", unUser.Photo);
            }
            catch (Exception ex)
            {
                //Possible that device doesn't support secure storage on device.
            }
        }
        #endregion

    }
}
