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


        
        public float ShowStats(BuildingType buildingType, StatsType statsType)
        {
            return buildingStats.GetRequiredStats(buildingType,statsType);
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
        private bool BuildingRequirement(BuildingType buildingType, float requiredAmount)
        {
            float woodRequirements = buildingStats.GetRequiredStats(buildingType, StatsType.Kayu);
            float elctronicRequirements = buildingStats.GetRequiredStats(buildingType, StatsType.Elektronik);

            if(woodRequirements <= requiredAmount & elctronicRequirements <= requiredAmount)
            {
                return true;
            }
            
            return false;
        }
        //---------------------------------------------------------------------------

        public BuildingType GetBuildingType()
        {
            return buildingType;
        }
        
    }
}
