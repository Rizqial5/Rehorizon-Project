using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.Core
{
   public class Buiilding : MonoBehaviour
   {
      public bool Placed{get; private set; }
      public BoundsInt area;
      public BoundsInt effectArea;
      public TileType colorCell;
      public TileType colorEffectCell;


      public bool CanBePlaced()
      {
         Vector3Int positionInt = GridBuilding.current.gridLayout.LocalToCell(transform.position);
         BoundsInt areaTempt = area;
         areaTempt.position = positionInt;

         if(GridBuilding.current.CanTakeArea(areaTempt))
         {
            return true;
         }

         return false;
      }

      public void Place()
      {
         Vector3Int positionInt = GridBuilding.current.gridLayout.LocalToCell(transform.position);
         BoundsInt areaTempt = area;
         areaTempt.position = positionInt;
         Placed = true;
         GridBuilding.current.TakeArea(areaTempt);
      }

      public TileType SetColorCell()
      {
         return colorCell;
      }

      public TileType SetColorCellEffect()
      {
         return colorEffectCell;
      }

   }

}
