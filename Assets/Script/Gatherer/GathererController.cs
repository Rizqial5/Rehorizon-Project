using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rehorizon.Core;

namespace Rehorizon.Gatherer
{
    public class GathererController : MonoBehaviour
    {   
        [SerializeField] float gatherTime = 3f;
        [SerializeField] StatsType statsType;
        [SerializeField] int amountGather;
        [SerializeField] GridBuilding gridBuilding;

        float timeGather = Mathf.Infinity;
        GathererMechanic gathererMechanic;

        private void Update() {

            timeGather += Time.deltaTime;
            
        }

        private void Awake() {
            gathererMechanic = GetComponent<GathererMechanic>();
        }
        private void OnMouseDown() 
        {
            if(gridBuilding.GetBuildMode()) return;

            timeGather = 0;
            StartCoroutine(GatherTime(gatherTime));
            
            
        }

        private IEnumerator GatherTime(float seconds)
        {
            
            yield return new WaitForSeconds(seconds);

            gathererMechanic.GatherObject(statsType,amountGather);
            
        }
    }
}
