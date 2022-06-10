using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rehorizon.Core;
using UnityEngine.EventSystems;

namespace Rehorizon.Gatherer
{
    public class GathererController : MonoBehaviour
    {   
        [SerializeField] float gatherTime = 3f;
        [SerializeField] StatsType statsType;
        [SerializeField] int amountGather;
        [SerializeField] GridBuilding gridBuilding;
        [SerializeField] GameObject fillAnimation;

        // float timeGather = Mathf.Infinity;
        GathererMechanic gathererMechanic;

        private void Update() {

            // timeGather += Time.deltaTime;
            // Debug.Log(timeGather);
            
        }

        private void Awake() {
            gathererMechanic = GetComponent<GathererMechanic>();
        }

        private void OnMouseDown() 
        {
            if(EventSystem.current.IsPointerOverGameObject()) return;
            if(gridBuilding.GetBuildMode()) return;

            

            fillAnimation.SetActive(true);

            
            StartCoroutine(GatherTime(gatherTime));
            
            
            
            
        }

        private IEnumerator GatherTime(float seconds)
        {
            
            yield return new WaitForSeconds(seconds);
            gathererMechanic.GatherObject(statsType,amountGather);

            
            
        }

        
    }
}
