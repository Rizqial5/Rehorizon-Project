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
            
        }


        
        public float ShowStats(BuildingType buildingType, StatsType statsType)
        {
            return buildingStats.GetStats(buildingType,statsType);
        }

         // For test purpose-------------------------------------------------------
        private bool BuildingRequirement(BuildingType buildingType, float requiredAmount)
        {
            float woodRequirements = buildingStats.GetStats(buildingType, StatsType.Kayu);
            float elctronicRequirements = buildingStats.GetStats(buildingType, StatsType.Elektronik);

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
