using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles
{
    public class Produit
    {
        #region Attributs

        public static List<Produit> CollClasse = new List<Produit>();

        private int _id;
        private string _nom;

        private string _photo;
        private float _prixreel;

        #endregion

        #region Constructeurs



        public Produit(int id, string nom, string photo, float prixreel)
        {

            Id = id;
            Nom = nom;
           
            _photo = photo;
            _prixreel = prixreel; 
            Produit.CollClasse.Add(this);
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public float Prixreel { get => _prixreel; set => _prixreel = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
