using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ApEnchere.VueModeles
{
    public class EnchereEnCoursVueModeles : BaseVueModeles
    {
        #region Attributs
        public User _unUser;
      private double _prixHT;
        public int _id;
        EnchereApi _monEnchere;
        ObservableCollection<Encherir> _lesEncherir;
        private DecompteTimer tmps;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private Encherir _prixActuel;
        private string _idUser;
        private float _param;
        private float _newPrixEnchere;
        private string _pseudoUser;
        public bool OnCancel = false;
        private string _TVA;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeur

        public EnchereEnCoursVueModeles(EnchereApi param)

        {
            LaEnchere = param;
            tmps = new DecompteTimer();
            DateTime datefin = param.Datefin;
            TimeSpan interval = datefin - DateTime.Now;
            tmps.Start(interval);

            //  GetLaEnchere(param);
            GetValeurActuelle(param);
            GetLesEncheri(param);
            //   SetEnchereAuto();
            BoutonActionEncheri = new Command(ActionEncheri);
            this.GetTimerRemaining(param.Datefin);
            StockerTVA(param);

        }
        #endregion

        #region Getter/Setter

       public double PrixHT
        {
            get { return _prixHT; }
            set { SetProperty(ref _prixHT, value); }
        }
        public string TVA
        {
            get { return _TVA; }
            set { SetProperty(ref _TVA, value); }
        }
        public float PrixEncheri
        {
            get
            {
                return _newPrixEnchere;
            }
            set
            {
                SetProperty(ref _newPrixEnchere, value);
            }
        }

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string PseudoUser
        {
            get
            {
                return _pseudoUser;
            }

            set
            {
                SetProperty(ref _pseudoUser, value);
            }
        }
        public ICommand BoutonActionEncheri { get; }
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
            get { return _idUser; }
            set { SetProperty(ref _idUser, value); }
        }

        public User UnUser
        {
            get { return _unUser; }
            set { SetProperty(ref _unUser, value); }
        }

        public float Param
        {
            get { return _param; }
            set { SetProperty(ref _param, value); }
        }
        #endregion

        #region Méthodes

        //Va chercher les donner pour une enchère
     /*   public async Task<EnchereApi> GetLaEnchere(EnchereApi param)
        {
            LaEnchere = await _apiServices.GetOneAsync<EnchereApi>
                ("api/getEnchere", EnchereApi.CollClasse, Id);
            return LaEnchere;
        }*/

        //Permet de voir les dernier qui ont enchéri
        public void GetLesEncheri(EnchereApi param)
        {

            //petit programme indépendant du programme principal (qui peut intéragir avec)
            //On ajoute une méthode pour l'obliger à le faire travailler en async
            Task.Run(async () =>

            {

                while (true)
                {

                    LesEncheri = await _apiServices.GetAllAsyncID<Encherir>("api/getLastSixOffer", Encherir.CollClasse, "Id", LaEnchere.Id);
                    Thread.Sleep(2000);
                    //thread : espace qui permet a un programme de fonctionné de manière indépendante
                    //permet de libérer du temps de calcul 
                }
            });
        }

        //Rend automatique le chargement des enchères
        /*  public void SetEnchereAuto()
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
          }*/

        //rend manuel l'envoie de l'encheri
        public async void ActionEncheri()
        {
            IdUser = await SecureStorage.GetAsync("id");
            PseudoUser = await SecureStorage.GetAsync("pseudo");


            if (PrixActuel != null)
            {
                int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(PrixEncheri, int.Parse(IdUser), LaEnchere.Id, 0, PseudoUser), "api/postEncherir");

            }

        }

        public void GetValeurActuelle(EnchereApi param)
        {
            //int x = 0;

            Task.Run(async () =>
            {
                while (true)
                {
                    PrixActuel = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, LaEnchere.Id.ToString());
                    CalculerPrixHt(param); //Appelle la méthode
                    CalculerTVA(param); 
                    Thread.Sleep(2000);
                }
            });
        }

        public void GetTimerRemaining(DateTime param)
        {


            Task.Run(async () =>
            {
                while (OnCancel == false)
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;

                    if (tmps.TempsRestant <= TimeSpan.Zero)
                    {
                        OnCancel = true;
                    }

                }



            });

        }

        //Méthode pour calculer le prixHT
        public void CalculerPrixHt(EnchereApi param)
        { 
            
            //PrixHT = PrixActuel / Convert.ToDouble(TVA); 
               // PrixHT = (PrixEncheri/PrixEncheri)*100;
               if (PrixActuel!= null)
            {
                  PrixHT = (PrixActuel.PrixEnchere/120)*100;
                }

        }

        //Méthode pour stocker sur le téléphone l'objet voulu
        public async void StockerTVA(EnchereApi TVA)
        {
            try
            {
                await SecureStorage.SetAsync("TVA", LaEnchere.TVA);

            }

            catch (Exception ex)
            {
                //Possible that device doesn't support secure storage on device.
            }
        }

        //Méthode pour caculer la TVA
        public async void CalculerTVA(EnchereApi param)
        {
            double resultat;
            
            resultat = PrixHT * 0.2;
                TVA = Convert.ToString(resultat);

            
        }
        #endregion
    }
}
