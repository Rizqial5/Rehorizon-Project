using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rehorizon.GuideBook
{
    [System.Serializable]
    public class GuideBookController : MonoBehaviour
    {
        [SerializeField] Text headerText;
        [SerializeField] Text descriptionText;
        [SerializeField] Text descriptionText2;



        DocumentList document;
        Document selectedDocument;
        
        private void Awake() {
            document = GetComponent<Convertion>().LoadReader();
        }


    
        

        public void ShowDocument(int idDocument)
        {
            selectedDocument = document.ShowSpecificDocument(idDocument);

            
            headerText.text = selectedDocument.title;
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

        public void UnlockDocument(int idDocument)
        {
            selectedDocument = document.ShowSpecificDocument(idDocument);

            selectedDocument.isDesc2Unlock = true;
            
            
            
        }

        

        
    }
}
