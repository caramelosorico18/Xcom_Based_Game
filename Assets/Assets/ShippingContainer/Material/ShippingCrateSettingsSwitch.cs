using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingCrateSettingsSwitch : MonoBehaviour
{
	private Renderer myObj;
	
	[SerializeField] private Color ExteriorColor;
	[SerializeField] private Color InteriorWallColor;
	[SerializeField] private Color InteriorFloorColor;
	[SerializeField] private float ChippingAmount;
	[SerializeField] private float ChippingControl;
	[SerializeField] private float MetalHandles;
	
    // Start is called before the first frame update
    void Start()
    {
		myObj = GetComponent<Renderer>();
		myObj.material.SetColor("_ExteriorColor", ExteriorColor);
		myObj.material.SetColor("_InteriorWallColor", InteriorWallColor);
		myObj.material.SetColor("_InteriorFloorColor", InteriorFloorColor);
		myObj.material.SetFloat("_ChippingAmount", ChippingAmount);
		myObj.material.SetFloat("_ChippingControl", ChippingControl);
		myObj.material.SetFloat("_MetalHandles", MetalHandles);
		
		

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
