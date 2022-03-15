using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApEnchere
{
     class Constantes
    {
        public static string BaseApiAddress => "http://172.17.0.61:8000/";

        public const string DatabaseFilename = "Enchere.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite //ouvre la base de donnée pour lire/écrire
            | SQLite.SQLiteOpenFlags.Create //crée la base de donnée si elle n'existe pas
            | SQLite.SQLiteOpenFlags.SharedCache//la connexion participera au cache partagé, si elle est activée
            | SQLite.SQLiteOpenFlags.ProtectionComplete;//le fichier est chiffré et inaccessible lorsque l'appareil est verrouillé
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);

            }
        }
    }
}
