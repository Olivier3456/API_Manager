

// Pour recevoir les infos de l'api de : https://open-meteo.com avec juste Settings coché.


[System.Serializable]
public class APIresponse
{
    public WeatherInfo current_weather;
}

[System.Serializable]
public class WeatherInfo
{
    public float temperature;
    public float windspeed;
    public float winddirection;
    public int weathercode;
}