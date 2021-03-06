using ApEnchere.Modeles;
using ApEnchere.Services;
using ApEnchere.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ApEnchere.VueModeles
{
    public class ConnexionVueModeles : BaseVueModeles
    {
        #region Attributs
        private readonly Api _apiServices = new Api();

        #endregion
        #region Constructeur
        public ConnexionVueModeles()
        {
            GetUserByMailAndPass();
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
            CommandBoutonConnexion = new Command(OnSubmit);
        }


        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonRetour { get; }
        public ICommand CommandBoutonConnexion { get; private set; }
        #endregion

        #region Methodes

        public async void GetUserByMailAndPass()
        {
           string id = await SecureStorage.GetAsync("id");

            User monUser = await _apiServices.GetOneAsync<User>("api/getUserByMailAndPass", User.CollClasse, Convert.ToInt32(id));
        }

        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new Page1();
        }

        public async void OnSubmit()
        {
           
        }
        #endregion
    }
}
