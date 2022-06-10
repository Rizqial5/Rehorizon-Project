using UnityEngine;
using UnityEngine.UI;

namespace Rehorizon.Factory
{
    public class FactoryPanelUI : MonoBehaviour 
    {
        [SerializeField] Text buildingTittle;
        [SerializeField] Text materialName;
        [SerializeField] Text materialResultName;
        [SerializeField] Text valueMaterial;
        [SerializeField] Text valueOutput;
        [SerializeField] Text valueResource;
        [SerializeField] Text requirementsValue;

        [SerializeField] FactoryMechanic factoryMechanic;

        private int tempValue = 0;

        

        private void Update() 
        {
            buildingTittle.text = factoryMechanic.GetBuildingType().ToString();
            materialName.text = factoryMechanic.GetMaterialName().ToString();
            materialResultName.text = factoryMechanic.GetOutputMaterialName().ToString();
            requirementsValue.text = materialName.text + " : " + factoryMechanic.GetMaterialValue().ToString();
            valueResource.text = factoryMechanic.GetResourceAvailable().ToString();
            valueMaterial.text = GetTempValue().ToString();
            valueOutput.text = factoryMechanic.GetOutputValue().ToString();
        }

        

        public void AddValue()
        {
            if(tempValue == factoryMechanic.GetResourceAvailable()) return;

            tempValue++;
        }

        public void DecreaseValue()
        {
            if(tempValue == 0) return;

            tempValue--;
        }

        public int GetTempValue()
        {
            if(tempValue > factoryMechanic.GetResourceAvailable())
            {
                tempValue = 0;
            }
            return tempValue;
        }

        public void ConfirmButton()
        {
            if(factoryMechanic.GetResourceAvailable() <= 0) return;
            if(tempValue < factoryMechanic.GetMaterialValue())
            {
                print("Bahan " + factoryMechanic.GetMaterialName() + " masih belum cukup"); //Pop up bahan ndak cukup
                return;
            }


            factoryMechanic.SetResource(-tempValue);
            factoryMechanic.SetResourceValue(1);

        }

        

        public void XButton()
        {
            factoryMechanic.HidePanel();
        }

        
    }
}