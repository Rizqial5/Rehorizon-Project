using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.GuideBook
{
    
    public class ButtonChanger : MonoBehaviour
    {
        [SerializeField] int buttonId;
        [SerializeField] string buttonName;

        public int GetButtonId()
        {
            return buttonId;
        }
    }
}
