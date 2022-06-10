using UnityEngine;

namespace Rehorizon.GuideBook
{
    public class GBManager : MonoBehaviour 
    {
        

        [SerializeField] int idDocument = 1;
        [SerializeField] int requirementsToUnlockDesc1 = 2;
        [SerializeField] int requirementsToUnlockDesc2 = 4;

        public static GBManager current;
        
        
        

       
        GuideBookController GBController;

        private void Awake() {
            GBController = GetComponent<GuideBookController>();
            current = this;
            
        }

        

        private void Update()
        {
            GBController.ShowDocument(idDocument);

            
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GBController.ClosePanel();
            }
            

        }

        private bool CheckRequirementDesc1(BuildingType buildingType)
        {
            int totalBuilding = GBController.GetTotalBuilding(buildingType);

            if(totalBuilding == requirementsToUnlockDesc1)
            {
                return true;
            }

            return false;

        }

        private bool CheckRequirementDesc2(BuildingType buildingType)
        {
            int totalBuilding = GBController.GetTotalBuilding(buildingType);

            if(totalBuilding == requirementsToUnlockDesc2)
            {
                return true;
            }

            return false;

        }

        public void SetIdDocument(int id)
        {
            idDocument = id;
        }

        public void UnlockNewDocument(BuildingType buildingType, int descDoc)
        {
            if(descDoc == 1)
            {
                if(!CheckRequirementDesc1(buildingType)) return;
                GBController.UnlockDocument1(buildingType);
            }
            else if(descDoc == 2)
            {
                if(!CheckRequirementDesc2(buildingType)) return;
                GBController.UnlockDocument2(buildingType);
            }
            
        }

        

        

       




        

        



    }


}