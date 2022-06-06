using UnityEngine;
using System.Collections.Generic;
using System;

namespace Rehorizon.Stats
{
    [CreateAssetMenu(fileName = "BuildingStats", menuName = "City Builder tutorial/BuildingStats", order = 0)]
    public class BuildingStats : ScriptableObject 
    {
        [SerializeField] BuildingTypeStats[] buildingTypeStats;

        Dictionary<BuildingType,Dictionary<StatsType,float>> lookUpRequiredResourceTable;
        Dictionary<BuildingType,Dictionary<StatsType,float>> lookUpInputMaterialTable;
        Dictionary<BuildingType,Dictionary<StatsType,float>> lookUpOutputEffectTable;


        public Dictionary<StatsType, float> GetRequiredStats(BuildingType buildingType)
        {
            BuildLookUpResource();

            foreach (var type in lookUpRequiredResourceTable)
            {
                if(type.Key == buildingType)
                {
                    return type.Value;
                }
            }
            
            return null;
        }

        public Dictionary<StatsType, float> GetInputMaterial(BuildingType buildingType)
        {
            BuildLookUpInputMaterial();


            foreach (var type in lookUpInputMaterialTable)
            {
                if(type.Key == buildingType)
                {
                    return type.Value;
                }
            }
            
            return null;
        }

        public float GetOutputEfffect(BuildingType buildingType, StatsType statsType)
        {
            BuildLookUpOutputEffect();

            return lookUpOutputEffectTable[buildingType][statsType];
        }

        private void BuildLookUpResource()
        {
            if(lookUpRequiredResourceTable != null) return;
            
            lookUpRequiredResourceTable = new  Dictionary<BuildingType,Dictionary<StatsType,float>>();

            foreach (BuildingTypeStats buildingStats in buildingTypeStats)
            {
                var statLookUpTable = new Dictionary<StatsType, float>();

                foreach (StatsRequired statsRequired in buildingStats.statsResources.statsTypes)
                {
                    statLookUpTable[statsRequired.statsType] = statsRequired.amount;
                }
                
                lookUpRequiredResourceTable[buildingStats.buildingType] = statLookUpTable;
            }
        }

        private void BuildLookUpInputMaterial()
        {
            if(lookUpInputMaterialTable != null) return;
            
            lookUpInputMaterialTable= new  Dictionary<BuildingType,Dictionary<StatsType,float>>();

            foreach (BuildingTypeStats buildingStats in buildingTypeStats)
            {
                var statLookUpTable = new Dictionary<StatsType, float>();

                foreach (StatsRequired statsRequired in buildingStats.inputResource.inputMaterial)
                {
                    statLookUpTable[statsRequired.statsType] = statsRequired.amount;
                }
                
                lookUpInputMaterialTable[buildingStats.buildingType] = statLookUpTable;
            }
        }

        private void BuildLookUpOutputEffect()
        {
            if(lookUpOutputEffectTable != null) return;
            
            lookUpOutputEffectTable = new  Dictionary<BuildingType,Dictionary<StatsType,float>>();

            foreach (BuildingTypeStats buildingStats in buildingTypeStats)
            {
                var statLookUpTable = new Dictionary<StatsType, float>();

                foreach (StatsRequired statsRequired in buildingStats.outputResource.outputEffects)
                {
                    statLookUpTable[statsRequired.statsType] = statsRequired.amount;
                }
                
                lookUpOutputEffectTable[buildingStats.buildingType] = statLookUpTable;
            }
        }

        
    }

    [System.Serializable]
    public class BuildingTypeStats 
    {
        public string buildingDesc;
        public BuildingType buildingType;
        public StatsResource statsResources;
        public InputResource inputResource;
        public OutputResource outputResource;
        
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

    [System.Serializable]
    public class InputResource 
    {
        public StatsRequired[] inputMaterial;
    }

    [System.Serializable]
    public class OutputResource
    {
        public StatsRequired[] outputEffects;
    }
}