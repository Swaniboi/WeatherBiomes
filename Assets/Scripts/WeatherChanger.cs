/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherChanger : MonoBehaviour
{
    public GameObject[] weather;
    int activeWeather;
    // Start is called before the first frame update
    void Start()
    {
        weather[0].SetActive(true);
        activeWeather = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            weather[activeWeather].SetActive(false);
            if(activeWeather+1 < weather.Length)
            {
                weather[activeWeather + 1].SetActive(true);
                activeWeather++;
            }
            else
            {
                weather[0].SetActive(true);
                activeWeather = 0;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weather[activeWeather].SetActive(false);
            if (activeWeather - 1 > 0)
            {
                weather[activeWeather - 1].SetActive(true);
                activeWeather--;
            }
            else
            {
                weather[weather.Length-1].SetActive(true);
                activeWeather = weather.Length-1;
            }
        }
    }
}
*/