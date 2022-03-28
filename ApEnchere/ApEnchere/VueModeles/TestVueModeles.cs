using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ApEnchere.VueModeles
{
    class TestVueModeles : BaseVueModeles
    {
        #region Attributs
        EnchereApi _monEnchere;
        ObservableCollection<Encherir> _lesEncherir;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeur

        public TestVueModeles()

        {
            //GetLaEnchere(param);
        }
        #endregion

        #region Getter/Setter

        public EnchereApi LaEnchere
        {
            get { return _monEnchere; }


            set { SetProperty(ref _monEnchere, value); }
        }

        public ObservableCollection<Encherir> LesEncherir
        {
            get { return _lesEncherir; }

            set { SetProperty(ref _lesEncherir, value); }
        }
        #endregion

        #region Méthodes

        //Va chercher les donner pour une enchère
        public async Task<EnchereApi> GetLaEnchere(int param)
        {
            LaEnchere = await _apiServices.GetOneAsync<EnchereApi>
                ("api/getEnchere", EnchereApi.CollClasse, param);
            return LaEnchere;
        }

        /*public async void PostEnchere(Encheres uneEnchere)
        {

            Resultat = await _apiServices.PostAsync<Encheres>
                   (uneEnchere, "api/postEnchere");
        }*/
        #endregion
    }
}
