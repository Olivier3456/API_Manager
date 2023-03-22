using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;


public class APIManager : MonoBehaviour
{
    [SerializeField] private string url;
    private string queryString;
    [SerializeField] private List<string> parametersName;
    [SerializeField] private List<string> parametersValue;

    [SerializeField] private TextMeshProUGUI buttonText;


    public void CallURL()
    {
        queryString = "";

        for (int i = 0; i < parametersName.Count; i++)
        {
            queryString += parametersName[i] + "=" + parametersValue[i] + "&";
        }
        Debug.Log("queryString: " + queryString);

        StartCoroutine(GetRequest(url + "?" + queryString));
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
                APIresponse apiResponse = JsonUtility.FromJson<APIresponse>(webRequest.downloadHandler.text);

                // Affichage de la température sur le bouton (par exemple)
                buttonText.text = apiResponse.current_weather.temperature.ToString();
            }
        }
    }
}
