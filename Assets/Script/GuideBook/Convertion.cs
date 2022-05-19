using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehorizon.GuideBook
{
    public class Convertion : MonoBehaviour
    {
        public TextAsset textJson;
        
        public Document LoadFile()
        {
            Document document = JsonUtility.FromJson<Document>(textJson.text);
           
            return document;
        }

        
    }
}
