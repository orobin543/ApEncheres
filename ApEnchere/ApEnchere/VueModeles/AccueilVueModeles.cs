using ApEnchere.Modeles.Api;
using ApEnchere.Services;
using ApEnchere.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApEnchere.VueModeles
{
    class AccueilVueModeles : BaseVueModeles
    {
        #region Attributs
        ObservableCollection<EnchereApi> _maListeEncheres;
        ObservableCollection<EnchereApi> _maListeEnchereEnCours;
        private ObservableCollection<EnchereApi> _maListeEncheresEnCoursTypeClassique;
        private ObservableCollection<EnchereApi> _maListeEncheresEnCoursTypeInverse;
        private ObservableCollection<EnchereApi> _maListeEncheresEnCoursTypeFlash;
        private bool _visibleEnchereEnCoursTypeClassique = true;
        private bool _visibleEnchereEnCoursTypeInverse = true;
        private bool _visibleEnchereEnCoursTypeFlash = true;

        private readonly Api _apiServices = new Api();
        //private int _resultat;
        #endregion

        #region Constructeur
        public AccueilVueModeles()
        {
            GetListeEncheres();
            GetListeEnchereEnCours();
            GetListeEnCheresEnCoursTypeClassique(1);
        GetListeEncheresEnCoursTypeInverse(2);
        GetListeEncheresEnCoursTypeFlash(3);
        }
        #endregion

        #region Getters/Setters

        public ObservableCollection<EnchereApi> MaListeEncheres
        {
            get { return _maListeEncheres; }


            set { SetProperty(ref _maListeEncheres, value); }
        }

        public ObservableCollection<EnchereApi> MaListeEnchereEnCours
        {
            get { return _maListeEnchereEnCours; }

            set { SetProperty(ref _maListeEnchereEnCours, value); }
        }
      

    public ObservableCollection<EnchereApi> MaListeEncheresEnCoursTypeClassique
    {
        get { return _maListeEncheresEnCoursTypeClassique; }
        set { SetProperty(ref _maListeEncheresEnCoursTypeClassique, value); }
    }

    public ObservableCollection<EnchereApi> MaListeEncheresEnCoursTypeInverse
    {
        get { return _maListeEncheresEnCoursTypeInverse; }
        set { SetProperty(ref _maListeEncheresEnCoursTypeInverse, value); }
    }

    public ObservableCollection<EnchereApi> MaListeEncheresEnCoursTypeFlash
    {
        get { return _maListeEncheresEnCoursTypeFlash; }
        set { SetProperty(ref _maListeEncheresEnCoursTypeFlash, value); }
    }

    public bool VisibleEnchereEnCoursTypeClassique
    {
        get { return _visibleEnchereEnCoursTypeClassique; }
        set { SetProperty(ref _visibleEnchereEnCoursTypeClassique, value); }
    }

    public bool VisibleEnchereEnCoursTypeInverse
    {
        get { return _visibleEnchereEnCoursTypeInverse; }
        set { SetProperty(ref _visibleEnchereEnCoursTypeInverse, value); }
    }
    public bool VisibleEnchereEnCoursTypeFlash
    {
        get { return _visibleEnchereEnCoursTypeFlash; }
        set { SetProperty(ref _visibleEnchereEnCoursTypeFlash, value); }
    }

        #endregion

        #region Méthodes
        public async void GetListeEncheres()
        {
            MaListeEncheres = await _apiServices.GetAllAsync<EnchereApi>
                   ("api/getEnchere", EnchereApi.CollClasse);
        }

        public async void GetListeEnchereEnCours()
        {
            MaListeEnchereEnCours = await _apiServices.GetAllAsync<EnchereApi>
                   ("api/getEncheresEnCours", EnchereApi.CollClasse);
        }

        /*public async void PostEnchere(Encheres uneEnchere)
        {

            Resultat = await _apiServices.PostAsync<Encheres>
                   (uneEnchere, "api/postEnchere");
        }*/

    public async void GetListeEnCheresEnCoursTypeClassique(int id)
    {
        MaListeEncheresEnCoursTypeClassique = 
                await _apiServices.GetAllAsyncID<EnchereApi> ("api/getEncheresEnCours", EnchereApi.CollClasse, "IdTypeEnchere", id);
        EnchereApi.CollClasse.Clear();

    }

    public async void GetListeEncheresEnCoursTypeInverse(int id)
    {
        MaListeEncheresEnCoursTypeInverse = await _apiServices.GetAllAsyncID<EnchereApi>
            ("api/getEncheresEnCours", EnchereApi.CollClasse, "IdTypeEnchere", id);
        EnchereApi.CollClasse.Clear();
    }
    public async void GetListeEncheresEnCoursTypeFlash(int id)
    {
        MaListeEncheresEnCoursTypeFlash = await _apiServices.GetAllAsyncID<EnchereApi>
            ("api/getEncheresEnCours", EnchereApi.CollClasse, "IdTypeEnchere", id);
        EnchereApi.CollClasse.Clear();
    }
        #endregion
    }
}
