using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rehorizon.GuideBook
{
    public class Convertion : MonoBehaviour
    {
        public TextAsset jsonText;

        public DocumentList LoadReader()
        {
            DocumentList wrapper = JsonUtility.FromJson<DocumentList>(jsonText.text);
           
            return wrapper;
        }
    
    
        
    }

    
}
