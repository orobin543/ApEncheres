using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles
{
    class Encherir
    {
        #region Attributs
        private int _id;
        private int _idEnchere;
        private int _idUser;
        private int _prixEnchere;
        private DateTime _dateEnchere;
        private Encheres _lEnchere;
        private User _leUser;


        #endregion

        #region Constructeur
        public Encherir(int id, int idEnchere, int idUser, int prixEnchere)
        {
            Id = id;
            IdEnchere = idEnchere;
            IdUser = idUser;
            PrixEnchere = prixEnchere;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public int IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public int PrixEnchere { get => _prixEnchere; set => _prixEnchere = value; }
        public DateTime DateEnchere { get => _dateEnchere; set => _dateEnchere = value; }
        public Encheres LEnchere { get => _lEnchere; set => _lEnchere = value; }
        public User LeUser { get => _leUser; set => _leUser = value; }

        #endregion

        #region Methodes
        #endregion
    }
}
