using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles
{
    public class Magasin
    {
        #region Attributs
        private int _id;
        private string _nom;
        private int _codePostal;
        private string _adresse;
        private string _ville;
        private int _lattitude;
        private int _longitude;
        private int _portable;
        private Produit _lesProduits;
        #endregion

        #region Constructeur
        public Magasin(int id, string nom, int codePostal, string adresse, string ville, int lattitude, int longitude, int portable)
        {
            Id = id;
            Nom = nom;
            CodePostal = codePostal;
            Adresse = adresse;
            Ville = ville;
            Lattitude = lattitude;
            Longitude = longitude;
            Portable = portable;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int CodePostal { get => _codePostal; set => _codePostal = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public int Lattitude { get => _lattitude; set => _lattitude = value; }
        public int Longitude { get => _longitude; set => _longitude = value; }
        public int Portable { get => _portable; set => _portable = value; }
        public Produit LesProduits { get => _lesProduits; set => _lesProduits = value; }

        #endregion

        #region Methodes
        #endregion
    }
}
