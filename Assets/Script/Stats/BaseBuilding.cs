using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.Stats
{
    public class BaseBuilding : MonoBehaviour
    {
        [SerializeField] BuildingType buildingType;
        [SerializeField] BuildingStats buildingStats;

        [SerializeField] float amountDummy; //for test purpose
        

        private void Start() {
            print(buildingType + " " + PrintStats(buildingType,StatsType.Elektronik));

            print(buildingType+""+BuidlingRequirement(buildingType, amountDummy));
        }


        // For test purpose-------------------------------------------------------
        private float PrintStats(BuildingType buildingType, StatsType statsType)
        {
            return buildingStats.GetStats(buildingType,statsType);
        }

         // For test purpose-------------------------------------------------------
        private bool BuidlingRequirement(BuildingType buildingType, float requiredAmount)
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
    }
}
