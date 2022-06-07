using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rehorizon.TimeManager;


namespace Rehorizon.Inventory
{
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
        [SerializeField] InventoryData srcTxt;
        timeController srcTime;


        public GameObject timeControllerObject;
        
        private void Awake() {
            srcTime = timeControllerObject.GetComponent<timeController>();
        }
        void Start()
        {
            anorganic.text = srcTxt.GetAmountInventory(StatsType.Elektronik).ToString();
            organic.text = srcTxt.GetAmountInventory(StatsType.Kompos).ToString();
            electric.text = srcTxt.GetAmountInventory(StatsType.Baterai).ToString();
            stone.text = srcTxt.GetAmountInventory(StatsType.Batu).ToString();
            water.text = srcTxt.GetAmountInventory(StatsType.Water).ToString();
            timeCounter.text = srcTime.Get_FullTime();
            dayCounter.text = string.Format("Day : {0}", srcTime.Get_DayCount().ToString()) ;
            
        }

        // Update is called once per frame
        void Update()
        {
            anorganic.text = srcTxt.GetAmountInventory(StatsType.Elektronik).ToString();
            organic.text = srcTxt.GetAmountInventory(StatsType.Kompos).ToString();
            electric.text = srcTxt.GetAmountInventory(StatsType.Baterai).ToString();
            stone.text = srcTxt.GetAmountInventory(StatsType.Batu).ToString();
            water.text = srcTxt.GetAmountInventory(StatsType.Water).ToString();
            timeCounter.text = srcTime.Get_FullTime();
            dayCounter.text = string.Format("Day : {0}", srcTime.Get_DayCount().ToString()) ;
            
        }
    }
}
