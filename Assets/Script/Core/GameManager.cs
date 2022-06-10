using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Rehorizon.Core
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] UnityEvent documentUnlock;

        private void Update() 
        {
            if(EventSystem.current.IsPointerOverGameObject()) return;

            // if(Input.GetKeyDown(KeyCode.Space))
            // {
            //     documentUnlock.Invoke();
            // }
        }
    
    }
}