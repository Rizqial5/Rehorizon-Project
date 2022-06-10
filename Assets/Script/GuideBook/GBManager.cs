using UnityEngine;

namespace Rehorizon.GuideBook
{
    public class GBManager : MonoBehaviour 
    {
        

        [SerializeField] int idDocument = 1;
    
        GuideBookController GBController;

        private void Awake() {
            GBController = GetComponent<GuideBookController>();
        }

        private void Start() 
        {
            GBController.ShowDocument(1);
        
        }

        private void Update() 
        {
            GBController.ShowDocument(idDocument);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                GBController.UnlockDocument(3);
            }
        }

        public void SetIdDocument(int id)
        {
            idDocument = id;
        }



    }


}