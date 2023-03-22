using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using static System.Net.WebRequestMethods;



// url : https://api.tvmaze.com/schedule



public class APIManager_Test_Perso : MonoBehaviour
{
    private string url = "https://api.tvmaze.com/schedule";
    [SerializeField] private TextMeshProUGUI resultatText;   

    

    public void CallURL()
    {
      
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Envoi de la requête
            yield return webRequest.SendWebRequest();

            // Vérification des erreurs
            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                // Traitement du json
                APIresponse_Test_Perso apiResponse = JsonUtility.FromJson<APIresponse_Test_Perso>(webRequest.downloadHandler.text);
                resultatText.text = apiResponse.resultat[0].id;

                
                // Affichage de la température sur le bouton (par exemple)
                // buttonText.text = apiResponse.current_weather.temperature.ToString();
            }
        }
    }
}
