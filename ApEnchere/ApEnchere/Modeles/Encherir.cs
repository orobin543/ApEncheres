using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles
{
    public class Encherir
    {
        #region Attributs
        private int _id;
        private int _idEnchere;
        private int _idUser;
        private float _prixEnchere;
        private DateTime _dateEnchere;
        private Encheres _lEnchere;
        private User _leUser;
        private string _pseudo;

        
        public static List<Encherir> CollClasse = new List<Encherir>();

        #endregion

        #region Constructeur
        public Encherir(float prixenchere, int idUser, int idEnchere, int id, string pseudo)
        {
            Encherir.CollClasse.Add(this);
            PrixEnchere = prixenchere;
            IdUser = idUser;
            IdEnchere = idEnchere;
            Id = id;
            Pseudo = pseudo;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public int IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public float PrixEnchere { get => _prixEnchere; set => _prixEnchere = value; }
        public DateTime DateEnchere { get => _dateEnchere; set => _dateEnchere = value; }
        public Encheres LEnchere { get => _lEnchere; set => _lEnchere = value; }
        public User LeUser { get => _leUser; set => _leUser = value; }

        public string Pseudo { get => _pseudo; set => _pseudo = value; } 

        #endregion

        #region Methodes
        #endregion
    }
}
