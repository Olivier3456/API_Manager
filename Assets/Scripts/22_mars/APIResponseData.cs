using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Tous nos noms de classe de l'APIResponse vont se terminer par Data (convention).
// Toutes nos variables dans ces classes et sous-classes doivent être déclarées en public.
// Les noms de variables doivent correspondre exactement aux noms des valeurs du JSon.


[Serializable]
public class APIResponseData
{
    public WeatherData current_weather;    
}

[Serializable]
public class WeatherData
{
    public float temperature;
    public float windspeed;
    public float winddirection;
    public float weathercode;
}
