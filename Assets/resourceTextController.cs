using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class resourceTextController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text anorganic;
    public Text organic;
    public Text electric;
    public Text stone;
    public Text water;

    public Text dayCounter;
    public Text timeCounter;

    public GameObject resourceControllerObject;
    resourceController srcTxt;

    public GameObject timeControllerObject;
    timeController srcTime;
    void Start()
    {
        srcTxt = resourceControllerObject.GetComponent<resourceController>();
        srcTime = timeControllerObject.GetComponent<timeController>();
    }

    // Update is called once per frame
    void Update()
    {
        anorganic.text = srcTxt.Get_anorganicWaste().ToString();
        organic.text = srcTxt.Get_organicWaste().ToString();
        electric.text = srcTxt.Get_ElectronicWaste().ToString();
        stone.text = srcTxt.Get_Stone().ToString();
        water.text = srcTxt.Get_Water().ToString();
        timeCounter.text = srcTime.Get_FullTime();
        dayCounter.text = string.Format("Day : {0}", srcTime.Get_DayCount().ToString()) ;
    }
}