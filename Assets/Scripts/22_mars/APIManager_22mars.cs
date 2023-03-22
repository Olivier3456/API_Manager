using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[Serializable]
struct Parameter
{
    public string name;
    public string value;
}


public class APIManager_22mars : MonoBehaviour
{
    [SerializeField] private string _endPoint;
    [SerializeField] private List<Parameter> parameters;


    private string MakeQuerryString()
    {
        string querry = "";
        for (int i = 0; i < parameters.Count; i++)
        {
            querry += (i == 0) ? "?" : "&";

            // Ce qui équivaut à :
            //if (i == 0) querry += "?";
            //else querry += "&";

            querry += parameters[i].name + "=" + parameters[i].value;
        }

        return querry;
    }


    public void CallURL()
    {
        string requestUrl = _endPoint + MakeQuerryString();

        Debug.Log("requestUrl: " + requestUrl);

        // fait une get request (sans s'occuper du resultat) :
        StartCoroutine(GetRequest(requestUrl));
    }


    IEnumerator GetRequest(string requestUrl)
    {
        using (UnityWebRequest webrequest = UnityWebRequest.Get(requestUrl))
        {
            // envoi de la requete :
            yield return webrequest.SendWebRequest();

            // verification des erreurs :
            if (webrequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Il y a un problème");
            }

            // traitement du résultat :
            else
            {                
                HandleMeteoResponse(webrequest);
            }
        }
    }
        

    private void HandleMeteoResponse(UnityWebRequest webrequest)
    {
        var apiResponseData = JsonUtility.FromJson<APIResponseData>(webrequest.downloadHandler.text);

        // On peut aussi utiliser NewtonSoft Json pour gérer les Json (plus de fonction, pour les cas plus complexes),
        // mais il faut installer son package dans Unity.

        Debug.Log("La température est de : " + apiResponseData.current_weather.temperature + "°C.");


        winDirecIndic.ChangeDirection(apiResponseData.current_weather.winddirection, apiResponseData.current_weather.windspeed);
    }

    [SerializeField] WindDirectionIndicator winDirecIndic;






}
