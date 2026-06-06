using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingCrateScript : MonoBehaviour
{

	private Renderer myObject;
	
	[SerializeField] private Color colorA;
	[SerializeField] private Color colorB;
	
	[SerializeField] private float Float;
	
	
    // Start is called before the first frame update
    void Start()
    {
		myObject = GetComponent<Renderer>();
		
		
        myObject.material.SetColor("_ColorA", colorA);
		myObject.material.SetColor("_ColorB", colorB);
		myObject.material.SetFloat("_Float", Float);
		
    }
	

  
}
