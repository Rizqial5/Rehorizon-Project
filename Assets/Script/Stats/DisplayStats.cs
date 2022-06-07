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

        [SerializeField] Transform positionHover;

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
            
            Dictionary<StatsType, int> materials = buildingStats.GetRequiredStats(buildingType);

            int batuAmount;
            int electronicAmount;

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
            
            hoverPanel.transform.position = positionHover.position;
        }
    }
}
