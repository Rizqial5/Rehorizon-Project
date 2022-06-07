using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rehorizon.Stats;
using Rehorizon.Inventory;

namespace Rehorizon.Core
{
   public class Buiilding : MonoBehaviour
   {
      public bool Placed{get; private set; }
      public TileType colorCell;
      public TileType colorEffectCell;

      [SerializeField] BuildingType buildingType;
      [SerializeField] InventoryData inventoryData;

      

      public BoundsInt area;
      public BoundsInt effectArea;

      BaseBuilding baseBuilding;

      private void Awake() 
      {
         baseBuilding = GetComponent<BaseBuilding>();
      }
     
      

      public bool CanBePlaced()
        {
            Vector3Int positionInt = GridBuilding.current.gridLayout.LocalToCell(transform.position);
            BoundsInt areaTempt = area;
            BoundsInt areaEffectTempt = effectArea;
            areaTempt.position = positionInt;

            if (!GridBuilding.current.CanTakeArea(areaTempt) & !GridBuilding.current.CanTakeAreaEffect(areaEffectTempt)) return false;
            if (!CheckResource(StatsType.Batu)) return false;
            if (!CheckResource(StatsType.Elektronik)) return false;

            return true;




        }

        private bool CheckResource(StatsType statsType)
        {
            int amountItem = inventoryData.GetAmountInventory(statsType);
            return baseBuilding.BuildingRequirement(buildingType, statsType, amountItem);
        }

        public void Place()
      {
         Vector3Int positionInt = GridBuilding.current.gridLayout.LocalToCell(transform.position);
         BoundsInt areaTempt = area;
         BoundsInt areaTemptEffect = effectArea;
         areaTempt.position = positionInt;
         Placed = true;
         GridBuilding.current.TakeArea(areaTempt);
         GridBuilding.current.TakeAreaEffect(areaTemptEffect);
         
         
      }

      public void PlaceRiver()
      {
         Vector3Int positionInt = GridBuilding.current.gridLayout.LocalToCell(transform.position);
         BoundsInt areaTempt = area;
         BoundsInt areaTemptEffect = effectArea;
         areaTempt.position = positionInt;
         Placed = true;
         GridBuilding.current.TakeArea(areaTempt, TileType.White);
         GridBuilding.current.TakeAreaEffect(areaTemptEffect,TileType.Nature);
         
         
      }


      

      


   }

}
