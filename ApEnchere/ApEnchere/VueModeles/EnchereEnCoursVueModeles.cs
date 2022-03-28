using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ApEnchere.VueModeles
{
    public class EnchereEnCoursVueModeles : BaseVueModeles
    {
        #region Attributs
       EnchereApi _monEnchere;
        ObservableCollection<Encherir> _lesEncherir;
        private DecompteTimer tmps;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private ObservableCollection<Encherir> _maListeSixDernieresEncheres;
        private Encherir _prixActuel;
        private string _idUser;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeur

        public EnchereEnCoursVueModeles(int param)

        {
            GetLaEnchere(param);
            GetLesEncheri(param);
            SetEnchereAuto();
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

        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
        }
        public int TempsRestantJour
        {
            get { return _tempsRestantJour; }
            set { SetProperty(ref _tempsRestantJour, value); }
        }
        public int TempsRestantMinutes
        {
            get { return _tempsRestantMinutes; }
            set { SetProperty(ref _tempsRestantMinutes, value); }
        }
        public int TempsRestantSecondes
        {
            get { return _tempsRestantSecondes; }
            set { SetProperty(ref _tempsRestantSecondes, value); }
        }

        public Encherir PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
        }

        public string IdUser
        {
            get => _idUser;
            set => _idUser = value;
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
                    //thread : espace qui permet a un programme de fonctionné de manière indépendante
                    //permet de libérer du temps de calcul 
                }
            });
        }

        //Rend automatique le chargement des enchères
        public void SetEnchereAuto()
        {

            Task.Run(async () =>
            {
                IdUser = await SecureStorage.GetAsync("ID");
                //récupère l'id du user dans le storage

                while (tmps.TempsRestant > TimeSpan.Zero)
                {
                    if (PrixActuel != null && PrixActuel.Id != int.Parse(IdUser))
                    {
                        float paramValeur = PrixActuel.PrixEnchere + 1; //ajoute 1 au prix actuel
                        int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(paramValeur, int.Parse(IdUser), LaEnchere.Id, 0, ""), "api/postEncherir");

                    }
                    Thread.Sleep(10000);
                }
            });
        }

        #endregion
    }
}
