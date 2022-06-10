using UnityEngine;


namespace Rehorizon.GuideBook
{
    [System.Serializable]
    public class DocumentList
    {
        public Document[] GuideBook;

        public Document ShowSpecificDocument(int idDocument)
        {
            idDocument = idDocument - 1;
            for (int i = 0; i < GuideBook.Length; i++)
            {
                if(idDocument == i)
                {
                    return GuideBook[idDocument];
                }
                
            }

            return null;
        }
    }
}   
        