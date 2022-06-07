using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Rehorizon.Core;


namespace Rehorizon.Stats
{
    public class DisplayStats : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] BuildingType buildingType;
        [SerializeField] Text[] statsTexts;
        [SerializeField] BuildingStats buildingStats;
        [SerializeField] GameObject hoverPanel;
        [SerializeField] GridBuilding gridBuilding;

        private bool isMouseOver = false ;

        private void Update() 
        {
            if(!gridBuilding) return;
            if(!gridBuilding.GetBuildMode()) return;

            if(isMouseOver)
            {
                DisplayRequireStats();
                HoverPanel();
            }
        }

       
        //Need modification Again----------------------
        public void DisplayRequireStats()
        {
            
            Dictionary<StatsType, float> materials = buildingStats.GetRequiredStats(buildingType);

            float batuAmount;
            float electronicAmount;

            foreach (var item in materials)
            {
                if( item.Key == StatsType.Batu)
                {
                    batuAmount = item.Value;
                    statsTexts[0].text = batuAmount.ToString();
                }

                else if( item.Key == StatsType.Elektronik)
                {
                    electronicAmount = item.Value;
                    statsTexts[1].text = electronicAmount.ToString();
                }
            }
            
            statsTexts[2].text = buildingType.ToString();
            
        }
        //--------------------------


        public void OnPointerEnter(PointerEventData eventData)
        {
            isMouseOver = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isMouseOver = false;
            hoverPanel.SetActive(false);
        }

        private void HoverPanel()
        {
            hoverPanel.SetActive(true);
            // Vector3 mousePos = Input.mousePosition;
            // mousePos.z = Camera.main.nearClipPlane;
            // hoverPanel.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}
