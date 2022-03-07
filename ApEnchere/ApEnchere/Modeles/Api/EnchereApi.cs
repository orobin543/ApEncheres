﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Modeles.Api
{
    class EnchereApi
    {
        #region Attributs

            public static List<EnchereApi> CollClasse = new List<EnchereApi>();
            private int _id;
            private DateTime _date_debut;
            private DateTime _date_fin;
            private float _prixreserve;
            private int _type_enchere_id;
            private int _produit_id;

            #endregion

            #region Constructeurs

            public EnchereApi(int id, DateTime date_debut, DateTime date_fin, float prixreserve, int type_enchere_id, int produit_id)
            {
                _id = id;
                _date_debut = date_debut;
                _date_fin = date_fin;
                _prixreserve = prixreserve;
                _type_enchere_id = type_enchere_id;
                _produit_id = produit_id;
                EnchereApi.CollClasse.Add(this);

            }



            #endregion

            #region Getters/Setters
            public int Id { get => _id; set => _id = value; }
            public DateTime Date_debut { get => _date_debut; set => _date_debut = value; }
            public DateTime Date_fin { get => _date_fin; set => _date_fin = value; }
            public float Prixreserve { get => _prixreserve; set => _prixreserve = value; }
            public int Type_enchere_id { get => _type_enchere_id; set => _type_enchere_id = value; }
            public int Produit_id { get => _produit_id; set => _produit_id = value; }
            #endregion

            #region Methodes

            #endregion
        }
    }
