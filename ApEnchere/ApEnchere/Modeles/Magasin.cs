using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Maps;

namespace ApEnchere.Modeles
{
    public class Magasin
    {
        #region Attributs
        public static ObservableCollection<Magasin> CollClasse = new ObservableCollection<Magasin>();
        private int _id;
        private string _nom;
        private int _codePostal;
        private string _adresse;
        private string _ville;
        private double _latitude;
        private double _longitude;
        private int _portable;
        private Produit _lesProduits;
        private Position _position;
        #endregion

        #region Constructeur
        public Magasin(int id, string nom, int codePostal, string adresse, string ville, double latitude, double longitude, int portable)
        {
            Id = id;
            Nom = nom;
            CodePostal = codePostal;
            Adresse = adresse;
            Ville = ville;
            Latitude = latitude;
            Longitude = longitude;
            Portable = portable;
            _position = new Position(latitude, longitude);
            Magasin.CollClasse.Add(this);
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int CodePostal { get => _codePostal; set => _codePostal = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public double Latitude { get => _latitude; set => _latitude = value; }
        public double Longitude { get => _longitude; set => _longitude = value; }
        public int Portable { get => _portable; set => _portable = value; }
        public Produit LesProduits { get => _lesProduits; set => _lesProduits = value; }
        public Position Position { get => _position; set => _position = value; }

        #endregion

        #region Methodes
        #endregion
    }
}
