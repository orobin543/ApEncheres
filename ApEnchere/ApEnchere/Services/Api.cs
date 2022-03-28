using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApEnchere.Services
{

    public class Api
    {
        private static HttpClient ClientHttp = new HttpClient();

        /// <summary>
        /// Cette methode est générique
        /// Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        /// 
        /// </summary>
        /// <typeparam name="T">la classe concernée</typeparam>
        /// <param name="paramUrl">l'adresse de l'API</param>
        /// <param name="param">la collection de classe concernee</param>
        /// public async void GetListe()
        ///{
        ///MaListeClients = await _apiServices.GetAllAsync<Client>("api/clients", Client.CollClasse);
        ///}
        /// <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync<T>(string paramUrl, List<T> param)
        {
            try
            {
                var json = await ClientHttp.GetStringAsync(Constantes.BaseApiAddress + paramUrl);
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        ///  <summary>
        ///  Cette methode est générique
        ///  Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        ///
        ///  </summary>
        ///  <typeparam name="T">la classe concernée</typeparam>
        ///  <param name="paramUrl">l'adresse de l'API</param>
        ///  <param name="collectionReturn">la collection de classe concernee</param>
        /// <param name="parameters">Dictionnary with Key = param name  and Value = param value</param>
        ///  public async void GetListe()
        /// {
        /// MaListeClients = await _apiServices.GetAllAsync<Client>("clients", Client.CollClasse);
        /// }
        ///  <returns>la liste des occurences</returns>
       /* public async Task<ObservableCollection<T>> GetAllAsync<T>(string paramUrl, List<T> collectionReturn, Dictionary<string, object> parameters)
        {
            try
            {
                JObject getResult = JObject.Parse(GetJsonString(parameters));
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await ClientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(collectionReturn);
            }
            catch (Exception)
            {
                return null;
            }
        }*/
       
        /*Lorsqu'on lui envoie un objet, il le convertit en json. Il encode le json pour en faire une page
         * Il l'envoie au serveur qui a lui donné une réponse. On récupère dans le Content le résultat du
         * serveur.
         */
        public async Task<int> PostAsync<T>(T param, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(param);
            int nID;
            try
            {
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await ClientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                var result = int.TryParse(content, out nID) ? nID : 0;
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<T> GetOneAsync<T>(string paramUrl, List<T> param, int paramId)
        {
            try
            {
                string jsonString = @"{'Id':'" + paramId + "'}";
                var getResult = JObject.Parse(jsonString);

                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");

                var response = await ClientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json);
                return res;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Get a Jsonstring for all the parameters with their name and value
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// 
        //Methode qui construit un body à partir d'un dictionnaire
       /* public static string GetJsonString(Dictionary<string, object> parameters)
        {
            string jsonString = @"{";
            int i = 0;
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                i++;
                jsonString += @"'" + parameter.Key + "':'" + parameter.Value + "'";
                if (i != parameters.Count)
                    jsonString += @",";
            }
            jsonString += @"}";
            return jsonString;
        }*/



    }
}