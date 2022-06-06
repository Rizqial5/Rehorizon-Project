using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.Stats
{
    public class BaseBuilding : MonoBehaviour
    {
        [SerializeField] BuildingType buildingType;
        [SerializeField] BuildingStats buildingStats;

        
        

        
        

        private void Start() 
        {
           ShowInputMaterial(buildingType);
        }


        
        

        public void ShowInputMaterial(BuildingType buildingType)
        {
            Dictionary<StatsType, float> materials = buildingStats.GetInputMaterial(buildingType);

            foreach (var item in materials)
            {
                print(item.Key + " : " + item.Value);
            }
        }

         // For test purpose-------------------------------------------------------
        public bool BuildingRequirement(BuildingType buildingType, StatsType statsType, float contohAmountInventory)
        {

            Dictionary<StatsType, float> materials = buildingStats.GetRequiredStats(buildingType);
            //Membuat dictionary resource yang ada

            if(contohAmountInventory >= materials[statsType])
            {
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
