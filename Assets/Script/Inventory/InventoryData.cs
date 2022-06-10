using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Rehorizon.Inventory
{
    [CreateAssetMenu(fileName = "InventoryData", menuName = "City Builder tutorial/InventoryData", order = 0)]
    public class InventoryData : ScriptableObject 
    {
        [SerializeField] InventoryStats[] inventoryStats;
        [SerializeField] TotalBuildingType[] totalBuildingTypes;
        [SerializeField] int amountMax;

        Dictionary<StatsType,int> inventoryLookupTable;
        Dictionary<BuildingType,int> buildingLookUpTable;


        public int GetAmountInventory(StatsType statsType)
        {
            BuildLookUpTable();

            return inventoryLookupTable[statsType];
        }

        public void SetAmountInventory(StatsType statsType, int amount)
        {
            BuildLookUpTable();
            
            int total = amount + inventoryLookupTable[statsType];

            if(total < 0) return;
            if(total <= amountMax)
            {
                inventoryLookupTable[statsType] = total;
            }
            
        }

        public int GetAmountBuilding(BuildingType buildingType)
        {
            BuildTotalBuildingLookUpTable();

            return buildingLookUpTable[buildingType];
        }

        public void SetAmountBuilding(BuildingType buildingType)
        {
            BuildTotalBuildingLookUpTable();
        
            
            buildingLookUpTable[buildingType] += 1;

            
            
        }


        private void BuildLookUpTable()
        {
            if(inventoryLookupTable != null) return;
            
            inventoryLookupTable = new  Dictionary<StatsType,int>();

            foreach (InventoryStats inventory in inventoryStats)
            {
               
               inventoryLookupTable[inventory.statsType] = inventory.amount;
                
            }
            
        }

        private void BuildTotalBuildingLookUpTable()
        {
            if(buildingLookUpTable != null) return;
            
            buildingLookUpTable = new  Dictionary<BuildingType,int>();

            foreach (TotalBuildingType building in totalBuildingTypes)
            {
               
               buildingLookUpTable[building.buildingType] = building.totalBuilding;
                
            }
            
        }
    }

    [System.Serializable]
    public class InventoryStats 
    {
        public StatsType statsType;
        public int amount;
    }

    [System.Serializable]
    public class TotalBuildingType
    {
        public BuildingType buildingType;
        public int totalBuilding;
    }

}