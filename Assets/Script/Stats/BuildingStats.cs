using UnityEngine;
using System.Collections.Generic;
using System;

namespace Rehorizon.Stats
{
    [CreateAssetMenu(fileName = "BuildingStats", menuName = "City Builder tutorial/BuildingStats", order = 0)]
    public class BuildingStats : ScriptableObject 
    {
        [SerializeField] BuildingTypeStats[] buildingTypeStats;

        Dictionary<BuildingType,Dictionary<StatsType,float>> lookUpTable;


        public float GetStats(BuildingType buildingType, StatsType statsType)
        {
            BuildLookUpResource();

            return lookUpTable[buildingType][statsType];
        }

        private void BuildLookUpResource()
        {
            if(lookUpTable != null) return;
            
            lookUpTable = new  Dictionary<BuildingType,Dictionary<StatsType,float>>();

            foreach (BuildingTypeStats buildingStats in buildingTypeStats)
            {
                var statLookUpTable = new Dictionary<StatsType, float>();

                foreach (StatsRequired statsRequired in buildingStats.statsResources.statsTypes)
                {
                    statLookUpTable[statsRequired.statsType] = statsRequired.amount;
                }
                
                lookUpTable[buildingStats.buildingType] = statLookUpTable;
            }
        }

        
    }

    [System.Serializable]
    public class BuildingTypeStats 
    {
        public string buildingDesc;
        public BuildingType buildingType;
        public StatsResource statsResources;
        
    }

    [System.Serializable]
    public class StatsResource
    {
        public StatsRequired[] statsTypes;
        
    }

    [System.Serializable]
    public class StatsRequired
    {
        public StatsType statsType;
        public float amount;
    }
}