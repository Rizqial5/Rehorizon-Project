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
        [SerializeField] Text tabName;

       

        DocumentList document;
        string tittle;
        
       

        private void Start() {
            // description.text = GetComponent<Convertion>().GetDataDocument();

            document = GetComponent<Convertion>().LoadReader();

            print(GetTitle());

            // for (int i = 0; i < document.GuideBook.Length; i++)
            // {
            //     print(document.GuideBook[i]);
            // }
            // headerText.text = document.title;
            // descriptionText.text = document.description;
            // tabName.text = document.tabName;
        }

        private string GetTitle()
        {
            ;
            foreach (Document documentFile in document.GuideBook)
            {
                tittle = documentFile.title;
                
            }

            return tittle;

            
        }
    }
}
