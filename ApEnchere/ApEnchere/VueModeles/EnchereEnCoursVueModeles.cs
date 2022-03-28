using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApEnchere.VueModeles
{
    public class EnchereEnCoursVueModeles : BaseVueModeles
    {
        #region Attributs
       EnchereApi _monEnchere;
        ObservableCollection<Encherir> _lesEncherir;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeur

        public EnchereEnCoursVueModeles(int param)

        {
            GetLaEnchere(param);
            GetLesEncheri(param);
        }
        #endregion

        #region Getter/Setter

        public EnchereApi LaEnchere
        {
            get { return _monEnchere; }


            set { SetProperty(ref _monEnchere, value); }
        }

        public ObservableCollection<Encherir> LesEncheri
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

        //Permet à un utilisateur d'encherir
        /* public async void GetLesEncheri()
         {
             Dictionary<string, object> param = new Dictionary<string, object>();
             param.Add("Id",13);
             LesEncheri = await _apiServices.GetAllAsync<Encherir>
                 ("api/getLastSixOffer", Encherir.CollClasse,param);
         }*/

        public  void GetLesEncheri(int param)
        {

            //petit programme indépendant du programme principal (qui peut intéragir avec)
            //On ajoute une méthode pour l'obliger à le faire travailler en async
            Task.Run(async () =>

            { 
               
                while (true)
                {
                   
                    LesEncheri = await _apiServices.GetAllAsyncID<Encherir> ("api/getLastSixOffer", Encherir.CollClasse, "Id", param);
                    Thread.Sleep(2000);
                }
            });
        }


        #endregion
    }
}
