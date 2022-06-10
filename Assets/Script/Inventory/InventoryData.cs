using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Rehorizon.Inventory
{
    [CreateAssetMenu(fileName = "InventoryData", menuName = "City Builder tutorial/InventoryData", order = 0)]
    public class InventoryData : ScriptableObject 
    {
        [SerializeField] InventoryStats[] inventoryStats;
        [SerializeField] int amountMax;

        Dictionary<StatsType,int> inventoryLookupTable;


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


        private void BuildLookUpTable()
        {
            if(inventoryLookupTable != null) return;
            
            inventoryLookupTable = new  Dictionary<StatsType,int>();

            foreach (InventoryStats inventory in inventoryStats)
            {
               
               inventoryLookupTable[inventory.statsType] = inventory.amount;
                
            }
            
        }
    }

    [System.Serializable]
    public class InventoryStats 
    {
        public StatsType statsType;
        public int amount;
    }

}