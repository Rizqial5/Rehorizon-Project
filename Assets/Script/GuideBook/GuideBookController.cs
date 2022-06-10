using System.Collections;
using System.Collections.Generic;
using Rehorizon.Inventory;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rehorizon.GuideBook
{
    [System.Serializable]
    public class GuideBookController : MonoBehaviour
    {
        [SerializeField] Text headerText;
        [SerializeField] Text descriptionText;
        [SerializeField] Text descriptionText2;
        [SerializeField] GameObject guidebookPanel;
        [SerializeField] InventoryData inventoryData;
        [SerializeField] UnityEvent unlockPopUp;
        

        private bool activePanel = false;
        private int totalBuilding;
       


        DocumentList document;
        Document selectedDocument;

        
        private void Awake() {
            document = GetComponent<Convertion>().LoadReader();
        }


        
        public int GetTotalBuilding(BuildingType buildingType)
        {
            totalBuilding = inventoryData.GetAmountBuilding(buildingType);

            return totalBuilding;
        }
    
        public void ShowDocument(int idDocument)
        {
            selectedDocument = document.ShowSpecificDocument(idDocument);

            
            headerText.text = selectedDocument.title;

            if(!selectedDocument.isDesc1Unlock) 
            {
                descriptionText.text = null;
                descriptionText2.text = null;
                return;
            }
            descriptionText.text = selectedDocument.description;

            if(!selectedDocument.isDesc2Unlock) 
            {
                descriptionText2.text = null;
                return;
            }
            
            descriptionText2.text = selectedDocument.description2;

            //Unlock Desc 3
            //Unlock Desc 4

            
            
        }

        public void UnlockDocument2(BuildingType buildingType)
        {
            if(buildingType == BuildingType.Organic)
            {
                selectedDocument = document.ShowSpecificDocument(1);
            }
            if(buildingType == BuildingType.Anorganic)
            {
                selectedDocument = document.ShowSpecificDocument(2);
            }
            if(buildingType == BuildingType.Green)
            {
                selectedDocument = document.ShowSpecificDocument(3);
            }
            
            
            unlockPopUp.Invoke();
            selectedDocument.isDesc2Unlock = true;
            
            
            
        }


        public void UnlockDocument1(BuildingType buildingType)
        {
            if(buildingType == BuildingType.Organic)
            {
                selectedDocument = document.ShowSpecificDocument(1);
            }
            if(buildingType == BuildingType.Anorganic)
            {
                selectedDocument = document.ShowSpecificDocument(2);
            }
            if(buildingType == BuildingType.Green)
            {
                selectedDocument = document.ShowSpecificDocument(3);
            }
            
            
            unlockPopUp.Invoke();
            selectedDocument.isDesc1Unlock = true;
            
            
            
        }

        public void ShowPanel()
        {
            guidebookPanel.SetActive(true);
        }

        public void ClosePanel()
        {
            guidebookPanel.SetActive(false);
        }

    
    }

    
}
