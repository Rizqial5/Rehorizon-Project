using System;
using System.Collections;
using System.Collections.Generic;
using GameDevTV.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;


namespace Rehorizon.Core
{
    public class GridBuilding : MonoBehaviour
    {
        public static GridBuilding current;

        public GridLayout gridLayout;

        public Tilemap mainTilemap;
        public Tilemap tempTilemap;
        public Tilemap backgroundTilemap;
        public bool isBuildMode;
        public TileType color;
       
        [SerializeField] BuildingSO currentBuilding = null;

        

        private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

        

        private Vector3 prevPos;
        private BoundsInt prevArea;   
        private BoundsInt prevAreaEffect;  

        BuildingSO temp = null;
        LazyValue<Buiilding> buiilding;

        

         

        private void Awake() {
            current = this;
            buiilding = new LazyValue<Buiilding>(SetupDefaultBuilding);
        }

        private Buiilding SetupDefaultBuilding()
        {
            return currentBuilding.GetBuildingPrefab();
        }

        private void Start() {

            // buiilding.ForceInit();
            isBuildMode = false;
            tempTilemap.gameObject.SetActive(false);
            mainTilemap.gameObject.SetActive(false);
            
            string tilePath = @"Tiles\";

            tileBases.Add(TileType.Empty, null);
            tileBases.Add(TileType.White, Resources.Load<TileBase>(tilePath + "white"));
            tileBases.Add(TileType.Green, Resources.Load<TileBase>(tilePath + "green"));
            tileBases.Add(TileType.Red, Resources.Load<TileBase>(tilePath + "red"));
            tileBases.Add(TileType.Brown, Resources.Load<TileBase>(tilePath + "brown"));
            tileBases.Add(TileType.Nature, Resources.Load<TileBase>(tilePath + "nature"));
        }

        private void Update() {
            
            if(!isBuildMode) return;
            if(!temp) return;
            

            if(Input.GetMouseButton(0))
            {
                if(EventSystem.current.IsPointerOverGameObject(0)) return;

                if(!buiilding.value.Placed)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3Int cellPos = gridLayout.LocalToCell(touchPos);

                    if(prevPos != cellPos)
                    {
                        buiilding.value.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos
                            + new Vector3(.5f, .5f, 0f));
                        prevPos = cellPos;
                        FollowBuilding();
                    }
                }
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                if(buiilding.value.CanBePlaced())
                {
                    buiilding.value.Place();
                    ClearAreaEffect();
                    temp = null;
                    
                    
                }
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(!buiilding.value.Placed)
                {
                    ClearArea();
                    ClearAreaEffect();

                    print("bisa");
                    Destroy(buiilding.value.gameObject);
                }
                
            }
            
        }

        public void GridMode()
        {
            
            isBuildMode = !isBuildMode;
            if(!isBuildMode)
            {
                if(buiilding.value && !buiilding.value.Placed)
                {
                    if(temp)
                    {
                        Destroy(buiilding.value.gameObject);
                    } 
                    
                    temp = null;
                }
                
                ClearArea();
            }
            mainTilemap.gameObject.SetActive(isBuildMode);
            tempTilemap.gameObject.SetActive(isBuildMode);
            
        }


        private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
        {
            TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
            int counter = 0;

            foreach (var v in area.allPositionsWithin)
            {
                Vector3Int pos = new Vector3Int(v.x, v.y, 0);
                array[counter] = tilemap.GetTile(pos);
                counter++;
            }

            return array;
        }

        private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
        {
            int size = area.size.x * area.size.y * area.size.z;
            TileBase[] tileArray = new TileBase[size];
            FillTiles(tileArray, type);
            tilemap.SetTilesBlock(area, tileArray);
        }

        private static void FillTiles(TileBase[] tileArray, TileType type)
        {
            for (int i = 0; i < tileArray.Length; i++)
            {
                tileArray[i] = tileBases[type];
            }
        }


        public void InitializeWithBuilding(BuildingSO buildingSO)
        {
            if(!isBuildMode) return;
            if(temp) return;
            
            temp = buildingSO;
            buiilding.value =  AttachBuilding(buildingSO);
        
            
            
            FollowBuilding();
        }

        public Buiilding AttachBuilding(BuildingSO buildingSO)
        {
            return buildingSO.Spawn();

        }

        private void ClearArea()
        {
            TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
            FillTiles(toClear, TileType.Empty);
            tempTilemap.SetTilesBlock(prevArea, toClear);
        }

        private void ClearAreaEffect()
        {
            TileBase[] toClear = new TileBase[prevAreaEffect.size.x * prevAreaEffect.size.y * prevAreaEffect.size.z];
            FillTiles(toClear, TileType.Empty);
            tempTilemap.SetTilesBlock(prevAreaEffect, toClear);
        }

        private void FollowBuilding()
        {
            ClearArea();
            ClearAreaEffect();

            buiilding.value.area = temp.GetBuildingArea();
            buiilding.value.effectArea = temp.GetEffectArea();

            buiilding.value.area.position = gridLayout.WorldToCell(buiilding.value.gameObject.transform.position);
            buiilding.value.effectArea.position = gridLayout.WorldToCell(buiilding.value.gameObject.transform.position);
            
            BoundsInt buildingArea = buiilding.value.area;
            BoundsInt effectArea = buiilding.value.effectArea;
            

            TileBase[] baseArray = GetTilesBlock(buildingArea, mainTilemap);
            TileBase[] baseArrayEffect = GetTilesBlock(effectArea, mainTilemap);

            int size = baseArray.Length;
            int sizeEffect = baseArrayEffect.Length;

            TileBase[] tileArray = new TileBase[size];
            TileBase[] tileArrayEffect = new TileBase[sizeEffect];

            for (int i = 0; i < baseArray.Length; i++)
            {
                if (baseArray[i] == tileBases[TileType.White])
                {
                    tileArray[i] = tileBases[TileType.Green];
                }
                else
                {
                    FillTiles(tileArray, TileType.Red);
                    break;
                }
            }

            for (int i = 0; i < baseArrayEffect.Length; i++)
            {
                if (baseArrayEffect[i] == tileBases[TileType.White])
                {
                    tileArrayEffect[i] = tileBases[TileType.Brown];
                }
                else
                {
                    break;
                }
            }

            tempTilemap.SetTilesBlock(buildingArea, tileArray);
            tempTilemap.SetTilesBlock(effectArea, tileArrayEffect);

            prevAreaEffect = effectArea;
            prevArea = buildingArea;
        }

        public bool CanTakeArea(BoundsInt area)
        {
            TileBase[] baseArray = GetTilesBlock(area, mainTilemap);
            foreach (var b in baseArray)
            {
                if(b != tileBases[TileType.White])
                {
                    Debug.Log("Cannot Place Here");
                    return false;
                }
            }

            return true;
        }

        public void TakeArea(BoundsInt area)
        {
            SetTilesBlock(area, TileType.Empty, tempTilemap);
            SetTilesBlock(area, TileType.Green, mainTilemap);
        }

        public void TakeAreaEffect(BoundsInt area)
        {
            SetTilesBlock(area, TileType.Empty, tempTilemap);
            SetTilesBlock(area, TileType.Nature, backgroundTilemap);
        }

        

    }

    

    public enum TileType
    {
        Empty,
        White,
        Green,
        Red,
        Brown,
        Nature,
    }

}

