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

       

        private void Start() {
            // description.text = GetComponent<Convertion>().GetDataDocument();

            Document document = GetComponent<Convertion>().LoadFile();
            
            headerText.text = document.title;
            descriptionText.text = document.description;
        }
    }
}
