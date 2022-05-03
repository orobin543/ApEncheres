using ApEnchere.Services;
using ApEnchere.Vues;
using System;
using ApEnchere.Modeles.Api;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApEnchere.VueModeles
{
    public class MapVueModeles :BaseVueModeles
    {
        #region Attributs
        private ObservableCollection<EnchereApi> _maListeEncheres;
        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public MapVueModeles()
        {
            GetListeEncheres();
        }
        #endregion

        #region Getters/Setters

        public ObservableCollection<EnchereApi> MaListeEncheres
        {
            get
            {
                return _maListeEncheres;
            }
            set
            {
                SetProperty(ref _maListeEncheres, value);
            }
        }

        #endregion

        #region Methodes
        /// <summary>
        /// Permet d'avoir la liste des enchères
        /// </summary>
        public async void GetListeEncheres()
        {
            MaListeEncheres = await _apiServices.GetAllAsync<EnchereApi>("api/getEnchere", EnchereApi.CollClasse);
            EnchereApi.CollClasse.Clear();
        }
        #endregion
    }
}
