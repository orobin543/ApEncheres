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
        public int _id;
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
        private float _param;
        private float _newPrixEnchere;
        private string _pseudoUser;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeur

        public EnchereEnCoursVueModeles(int param)

        {
            GetLaEnchere(param);
            GetValeurActuelle(param);
             GetLesEncheri(param);
            //   SetEnchereAuto();
            BoutonActionEncheri = new Command(ActionEncheri);
        }
        #endregion

        #region Getter/Setter
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
            get {return _idUser;}
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
        public async Task<EnchereApi> GetLaEnchere(int param)
        {
            LaEnchere = await _apiServices.GetOneAsync<EnchereApi>
                ("api/getEnchere", EnchereApi.CollClasse, param);
            return LaEnchere;
        }

        //Permet de voir les dernier qui ont enchéri
        public void GetLesEncheri(int param)
        {

            //petit programme indépendant du programme principal (qui peut intéragir avec)
            //On ajoute une méthode pour l'obliger à le faire travailler en async
            Task.Run(async () =>

            {

                while (true)
                {

                    LesEncheri = await _apiServices.GetAllAsyncID<Encherir>("api/getLastSixOffer", Encherir.CollClasse, "Id", param);
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
       /* public async void ActionEncheri()
        {
            if (PrixActuel != null)
            {
                if (PrixEncheri > PrixActuel.PrixEnchere)
                {
                    IdUser = await SecureStorage.GetAsync("ID");
                    PseudoUser = await SecureStorage.GetAsync("Pseudo");
                    /*if (PseudoUser != PrixActuel.Pseudo)
                    {
                    Encherir newEncherir = new Encherir(PrixEncheri, int.Parse(IdUser), LaEnchere.Id, 0, PseudoUser);
                    await _apiServices.PostAsync<Encherir>(newEncherir, "api/postEncherir");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Vous ne pouvez pas enchérir sur vous-même! ", "Vous menez l'enchère!", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Vous devez proposer un prix plus grand que celui actuel! ", "Changez votre prix", "OK");
                }
            }
        }*/

        //Récupère les données d'un User
      /* public async void GetUnUserId()
        {

            UnUser = await _apiServices.GetOneAsyncID<User>("api/getUser", User.CollClasse, Id.ToString());
          
        }*/


        public async void ActionEncheri()
        {
                IdUser = await SecureStorage.GetAsync("id");
            PseudoUser = await SecureStorage.GetAsync("pseudo");


                if (PrixActuel != null)
                {
                    int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(PrixEncheri, int.Parse(IdUser), LaEnchere.Id, 0, PseudoUser), "api/postEncherir");

                }

        }

        public void GetValeurActuelle(int param)
        {
            int x = 0;

            Task.Run(async () =>
            {
                while (true)
                {
                    PrixActuel = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, param.ToString());
                    Thread.Sleep(2000);
                }
            });
        }
        #endregion
    }
}
