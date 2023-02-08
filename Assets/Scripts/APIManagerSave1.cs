using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIManagerSave1 : MonoBehaviour
{
    [SerializeField] private string url;
    private string queryString = "";
    [SerializeField] private List<string> parametersName;
    [SerializeField] private List<string> parametersValue;

    private void Start()
    {
        CallURL();
    }


    public void CallURL()
    {
        for (int i = 0; i < parametersName.Count; i++)
        {
            queryString += parametersName[i] + "=" + parametersValue[i] + "&";
        }
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
                // Affichage du résultat
                Debug.Log("Received: " + webRequest.downloadHandler.text);
            }
        }
    }
}
