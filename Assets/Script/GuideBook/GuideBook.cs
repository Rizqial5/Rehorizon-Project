using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rehorizon.GuideBook
{
    [System.Serializable]
    public class GuideBook : MonoBehaviour
    {
        [SerializeField] Text headerText;
        [SerializeField] Text descriptionText;
        [SerializeField] int startDocumentID = 1;

        

       

        DocumentList document;
        
        
       

        private void Start() {

            document = GetComponent<Convertion>().LoadReader();

            ShowDocument(1);
        }

        

        public void ShowDocument(int idDocument)
        {
            foreach (Document documentFile in document.GuideBook)
            {
                if(documentFile.documentId == idDocument)
                {
                    headerText.text = documentFile.title;
                    descriptionText.text = documentFile.description;
                }
                
            }

            
        }

        
    }
}
