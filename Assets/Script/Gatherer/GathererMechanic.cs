using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rehorizon.Inventory;

namespace Rehorizon.Gatherer
{
    public class GathererMechanic : MonoBehaviour
{
    
   
    [SerializeField] InventoryData inventoryData;
    
    public void GatherObject(StatsType statsType, int amount)
    {
        Destroy(gameObject);
        //Ienumerator
        inventoryData.SetAmountInventory(statsType,amount);

        
    }

    
}
}
