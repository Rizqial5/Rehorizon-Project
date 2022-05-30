using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottomTextController : MonoBehaviour
{
    public Text temp;
    public Text co2;
    public Text ch4;
    public Text o2;
    public Text weather;
    public Text population;


    public GameObject statTextControllerObject;
    public statController srcText;
    // Update is called once per frame

    void Start() {
        srcText = statTextControllerObject.GetComponent<statController>();
    }
    void Update()
    {
        // temp.text = srcText.Get_Temperature().ToString();
        temp.text = string.Format("Temp : {0}°C", srcText.Get_Temperature());
        co2.text = string.Format("CO2 : {0}", srcText.Get_o2());
        ch4.text = string.Format("CH4 : {0}", srcText.Get_ch4());
        o2.text = string.Format("O2 : {0}", srcText.Get_o2());
        weather.text = string.Format("weather : {0}", srcText.Get_weather());
        population.text = string.Format("population : {0}", srcText.Get_population());
    }
}
