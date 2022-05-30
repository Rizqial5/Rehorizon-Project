using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statController : MonoBehaviour
{
    public int temperature;
    public int co2;
    public int ch4;
    public int o2;
    public string weather;
    public int population;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Get_Temperature(){
        return temperature;
    }

    public int Get_co2(){
        return co2;
    }

    public int Get_ch4(){
        return 02;
    }

    public int Get_o2(){
        return o2;
    }

    public string Get_weather(){
        return weather;
    }

    public int Get_population(){
        return population;
    }
}
