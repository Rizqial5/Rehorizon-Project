using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.Inventory
{
    public class resourceController : MonoBehaviour
    {

        [SerializeField] InventoryData inventoryData;
        public int builder;
        public int builderMaxCap;

        public int anorganicWaste;
        public int organicWaste;
        public int electronicWaste;
        public int stone ;
        public int water;

        public int anorganicWasteMaxcap;
        public int organicWasteMaxcap;
        public int electronicWasteMaxCap;
        public int stoneMaxCap;
        public int waterMaxCap;

        public int Get_anorganicWaste(){
            return anorganicWaste;
        }
        public int Get_organicWaste(){
            return organicWaste;
        }
        public int Get_ElectronicWaste(){
            return electronicWaste;
        }

        public int Get_Stone(){
            return stone;
        }

        public int Get_Water(){
            return water;
        }

        public int Get_Builder(){
            return builder;
        }


        public void addanorganicWaste(int addAmount){
            if (anorganicWaste+addAmount > anorganicWasteMaxcap){
                anorganicWaste = anorganicWasteMaxcap;
            }else{
                anorganicWaste+=addAmount;
            }
            
        }
        public void addorganicWaste(int addAmount){
            if (organicWaste+addAmount > organicWasteMaxcap){
                organicWaste = organicWasteMaxcap;
            }else{
                organicWaste+=addAmount;
            }
            
        }

        public void addElectronicWaste(int addAmount){
            if (electronicWaste+addAmount > electronicWasteMaxCap){
                electronicWaste = electronicWasteMaxCap;
            }else{
                electronicWaste+=addAmount;
            }
        }

        public void addStone(int addAmount){
            if(stone+addAmount > stoneMaxCap){
                stone = stoneMaxCap;
            }else{
                stone+=addAmount;
            }
        }

        public void addWater(int addAmount){
            if(water+addAmount>waterMaxCap){
                water = waterMaxCap;
            }else{
                water+=addAmount;
            }
        }

        public void addBuilder(){
            builderMaxCap+=1;
        }
    }

}