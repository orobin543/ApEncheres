using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles
{
    class TypeEnchere
    {
        #region Attributs
        private int _id;
        private string _nom;
        private Encheres _lesEncheres;


        #endregion

        #region Constructeur
        public TypeEnchere(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public Encheres LesEncheres { get => _lesEncheres; set => _lesEncheres = value; }

        #endregion

        #region Methodes
        #endregion
    }
}
