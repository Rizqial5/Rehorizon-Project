using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.Core
{

    [CreateAssetMenu(fileName = "BuildingSO", menuName = "City Builder tutorial/BuildingSO", order = 0)]
    public class BuildingSO : ScriptableObject 
    {

        [SerializeField] public Buiilding buiildingPrefab;
        [SerializeField] Sprite buildingSprite;
        [SerializeField] BoundsInt buildingArea;
        [SerializeField] BoundsInt effectArea;

        public bool Placed{get; private set; }
        



        public Buiilding Spawn()
        {
            Buiilding buiilding = null;
            if(buiildingPrefab != null)
            {
                buiilding = Instantiate(buiildingPrefab,Vector3.zero,Quaternion.identity);
            }

            return buiilding;
        }


    
        public Vector3 SetBuildingAreaPosition(Vector3Int parameter)
        {
            return buildingArea.position = parameter;
        }
        public Vector3 SetEffectAreaPosition( Vector3Int parameter )
        {
            return effectArea.position = parameter;
        }
        
        public BoundsInt GetBuildingArea()
        {
            return buildingArea;
        }

        public BoundsInt GetEffectArea()
        {
            return effectArea;
        }

        public Buiilding GetBuildingPrefab()
        {
            return buiildingPrefab;
        }

    



    }
}
