using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rehorizon.Inventory;

namespace Rehorizon.Stats
{
    public class BaseBuilding : MonoBehaviour
    {
        [SerializeField] BuildingType buildingType;
        [SerializeField] BuildingStats buildingStats;
        [SerializeField] InventoryData inventoryData;

        
        

        
        

        private void Start() 
        {
           ShowInputMaterial(buildingType);
        }


        
        

        public void ShowInputMaterial(BuildingType buildingType)
        {
            Dictionary<StatsType, int> materials = buildingStats.GetInputMaterial(buildingType);

            foreach (var item in materials)
            {
                print(item.Key + " : " + item.Value);
            }
        }

         // For test purpose-------------------------------------------------------
        public bool BuildingRequirement(BuildingType buildingType, StatsType statsType, int amountInventory)
        {

            Dictionary<StatsType, int> materials = buildingStats.GetRequiredStats(buildingType);
            
            //Membuat dictionary resource yang ada

            if(amountInventory >= materials[statsType])
            {
                inventoryData.SetAmountInventory(statsType,-materials[statsType]);
                return true;
            }
            
            Debug.Log(statsType + " masih kurang");
            return false;
        }
        //---------------------------------------------------------------------------

        public BuildingType GetBuildingType()
        {
            return buildingType;
        }
        
    }
}
