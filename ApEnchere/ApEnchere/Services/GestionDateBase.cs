using ApEnchere.Modeles;
using ApEnchere.Modeles.Api;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApEnchere.Services
{
    public class GestionDataBase
    {
       /* #region Attributs
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        #endregion

        #region Constructeurs
        public GestionDataBase()
        {
            InitializeAsync().SafeFireAndForget(false); //endroit où l'on gère les extensions
        }
        #endregion

        #region Methodes
        //initialisation à la base de donnée
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
        });
        async Task InitializeAsync() // endroit de la connexion
        {
            if (!initialized)// la base de donnée existe ??
            {
                //permet de créer la table Etudiant
                //code a dupliqué par nb de table existante

                await Database.CreateTablesAsync(CreateFlags.None, typeof(EnchereApi)).ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(Encheres)).ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(Encherir)).ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(Magasin)).ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(Produit)).ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(TypeEnchere)).ConfigureAwait(false);

                initialized = true;
            }
        }
        //permet d/ajouter ou mettre a jour une instance de la classe
        public Task<int> SaveItemAsync<T>(T item)
        {
            PropertyInfo x = (item.GetType().GetProperty("ID"));
            int nbi = Convert.ToInt32(x.GetValue(item));
            if (nbi != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task MiseAJourRelation(object item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }
        //supprime toutes les instances de tables appreciation
        public Task<int> DeleteItemsAsync<T>()
        {
            return Database.DeleteAllAsync<T>();
        }
        //permet de recupérer la liste de tout ce qu'il y a a dans une classe
        public ObservableCollection<T> GetItemsAsync<T>() where T : new()
        {
            ObservableCollection<T> resultat = new ObservableCollection<T>();
            List<T> liste = Database.Table<T>().ToListAsync().Result;
            foreach (T unObjet in liste)
            {
                resultat.Add(unObjet);
            }
            return resultat;
        }
        //permet de recuperer un objet avec ces collections
        public Task<T> GetAvecRelations<T>(T item) where T : new()
        {
            PropertyInfo x = (item.GetType().GetProperty("ID"));
            int nbi = Convert.ToInt32(x.GetValue(item));
            return Database.GetWithChildrenAsync<T>(nbi);
        }
        //permet de recupérer un objet sans ces collections/qui n'a pas de collection
        public Task<T> GetItemAsync<T>(int id) where T : new()
        {
            return Database.FindAsync<T>(id);
        }

        #endregion*/
    }

}
