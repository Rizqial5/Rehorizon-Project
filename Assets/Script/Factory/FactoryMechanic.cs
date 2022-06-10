using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rehorizon.Core;
using Rehorizon.Stats;
using Rehorizon.Inventory;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Rehorizon.Factory
{
    public class FactoryMechanic : MonoBehaviour
    {

        [SerializeField] FactoryPanelUI factoryPanel;
        [SerializeField] BuildingType buildingType;
        [SerializeField] BuildingStats buildingStats;
        [SerializeField] InventoryData inventoryData;

        private Dictionary<StatsType, int> inputMaterial;
        private Dictionary<StatsType, int> outputMaterial;
        private int finalValue;
        

        bool isPanelShow;
        // Start is called before the first frame update

        private void Awake() 
        {
            isPanelShow = false;
        }

        private void Update() {
            if(!factoryPanel) return;
            factoryPanel.gameObject.SetActive(isPanelShow);
        }


        private void OnMouseDown() 
        {
            if(EventSystem.current.IsPointerOverGameObject()) return;
            if(GridBuilding.current.GetBuildMode()) return;
            

            isPanelShow = true;
            
            
        }
         
        private Dictionary<StatsType, int> ShowMaterial()
        {
            Dictionary<StatsType, int> materials = buildingStats.GetInputMaterial(buildingType);
            
            return materials;
        }

        private Dictionary<StatsType, int> ShowOutputMaterial()
        {
            return buildingStats.GetOutputEfffectStats(buildingType);
        }

        

        public StatsType GetMaterialName()
        {
            inputMaterial = ShowMaterial();
            
            StatsType materialName;

            foreach (var item in inputMaterial)
            {
                materialName = item.Key;
                return materialName;
            }

            return StatsType.Baterai ;

        }

        public StatsType GetOutputMaterialName()
        {
            outputMaterial = ShowOutputMaterial();
            
            StatsType materialName;

            foreach (var item in outputMaterial)
            {
                materialName = item.Key;
                return materialName;
            }

            return StatsType.Baterai ;
        }

        public int GetMaterialValue()
        {
            inputMaterial = ShowMaterial();
            
            int materialValue;

            foreach (var item in inputMaterial)
            {
                materialValue = item.Value;
                return materialValue;
            }

            return 0 ;

        }

        public int GetOutputValue()
        {
            return inventoryData.GetAmountInventory(GetOutputMaterialName());

        }

        public int GetResourceAvailable()
        {
            return inventoryData.GetAmountInventory(GetMaterialName());
        }

        public BuildingType GetBuildingType()
        {
            return buildingType;
        }



        public bool GetIsPanelShow()
        {
            return isPanelShow;
        }

        public void SetResource(int amount)
        {
            inventoryData.SetAmountInventory(GetMaterialName(),amount);
        }

        public void SetResourceValue(int amount)
        {
            inventoryData.SetAmountInventory(GetOutputMaterialName(),amount);
        }

        public void HidePanel()
        {
            isPanelShow = false;
        }

        
    }

}