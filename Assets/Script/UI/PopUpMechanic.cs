using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rehorizon.UI
{
    public class PopUpMechanic : MonoBehaviour
    {

        [SerializeField] GameObject panel;
        [SerializeField] Text keteranganText;
        

        public void ShowPopUp(string keterangan)
        {

            panel.SetActive(true);

            keteranganText.text = keterangan;

            
        }

        public void ClosePopUp()
        {
            panel.SetActive(false);
        }
    }
}
