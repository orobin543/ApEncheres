using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles
{
    public class Encheres
    {
        #region Attributs

        private int _id;
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private int _prixReserve;
        private int _prixEncheres;
        private Produit _leProduit;
        private TypeEnchere _leType;
        private Encherir _lEnchere;
        #endregion

        #region Constructeurs
        public Encheres(int id, DateTime dateDebut, DateTime dateFin, int prixReserve, int prixEncheres)
        {
            Id = id;
            DateDebut = dateDebut;
            DateFin = dateFin;
            PrixReserve = prixReserve;
            PrixEncheres = prixEncheres;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime DateDebut { get => _dateDebut; set => _dateDebut = value; }
        public DateTime DateFin { get => _dateFin; set => _dateFin = value; }
        public int PrixReserve { get => _prixReserve; set => _prixReserve = value; }
        public int PrixEncheres { get => _prixEncheres; set => _prixEncheres = value; }
        public TypeEnchere LeType { get => _leType; set => _leType = value; }
        public Encherir LEnchere { get => _lEnchere; set => _lEnchere = value; }
        internal Produit LeProduit { get => _leProduit; set => _leProduit = value; }

        #endregion

        #region Methodes
        #endregion

    }
}
