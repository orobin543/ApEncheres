using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles.Api
{
    public class EnchereApi
    {
        #region Attributs

            public static List<EnchereApi> CollClasse = new List<EnchereApi>();
            private int _id;
            private DateTime _date_debut;
            private DateTime _date_fin;
            private float _prixreserve;
            private int _type_enchere_id;
        private Magasin _leMagasin;
        private TypeEnchere _leTypeEnchere;
        private Produit _leProduit;
        private string _TVA;
        

            #endregion

            #region Constructeurs

           
            public EnchereApi(int id, DateTime date_debut, DateTime date_fin, float prixreserve, int type_enchere_id, Produit leProduit, TypeEnchere leType, Magasin leMagasin)
            {
                _id = id;
                _date_debut = date_debut;
                _date_fin = date_fin;
                _prixreserve = prixreserve;
                _type_enchere_id = type_enchere_id;
            _leProduit = leProduit;
            _leTypeEnchere = leType;
            _leMagasin = leMagasin;
                EnchereApi.CollClasse.Add(this);

            }



            #endregion

            #region Getters/Setters
            public int Id { get => _id; set => _id = value; }
            public DateTime Datedebut { get => _date_debut; set => _date_debut = value; }
            public DateTime Datefin { get => _date_fin; set => _date_fin = value; }
            public float Prixreserve { get => _prixreserve; set => _prixreserve = value; }
            public int Type_enchere_id { get => _type_enchere_id; set => _type_enchere_id = value; }
            public Produit LeProduit { get => _leProduit; set => _leProduit = value; }
        public TypeEnchere LeTypeEnchere { get => _leTypeEnchere; set => _leTypeEnchere = value; }
        public Magasin LeMagasin { get => _leMagasin; set => _leMagasin = value; }
        public string TVA { get => _TVA; set => _TVA = value; }
        #endregion

        #region Methodes

        #endregion
    }
    }
