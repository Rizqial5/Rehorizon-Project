using UnityEngine;
using Rehorizon.Core;
using UnityEngine.Tilemaps;
using System;

namespace Rehorizon.River
{
    public class RiverController : MonoBehaviour 
    {

        

        [SerializeField] BoundsInt riverArea;
        [SerializeField] Tilemap tilemapPrefab;

        [SerializeField] GridBuilding gridBuilding;
        

        

        

        
        private void Update() {
            // IdentifyingEffect();
            
        }

        public void IdentifyingEffect()
        {
            int rumus = Mathf.RoundToInt(riverArea.size.x % 2) ;
            
            if(rumus == 1 )
            {
                print("nature");
            }
            else{
                print("river");
            }
        }
        
        public void RiverBehaviour()
        {
            //Manage river mechanic
        }

        public void RiverPlaced()
        {
            //Managing prerequisite for placing the river
        }

        private void SetRiverTiles(BoundsInt area, Tilemap tilemap)
        {
            int sizeNature;
            int sizeWater;


        
            
            
            
            
            
        }

        private bool ShouldRIver(BoundsInt area)
        {
            int oddMath = area.size.x % 2;

            if(oddMath == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}