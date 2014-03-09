using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public Material yellowMaterial;
	public Material cyanMaterial;
	public Material magentaMaterial;
	public Material originalMaterial;
	public bool isInAnotherWall;
	public string originalTag;
	public bool isDoubleColor;
	public GameObject theAnotherWall;
	

	void OnTriggerEnter(Collider collider)
	{
		if(collider.transform.tag.Contains("Wall") && !isDoubleColor && !collider.GetComponent<Wall>().isDoubleColor)
		{	
				if((collider.tag.Contains("Red") && transform.tag.Contains("Blue"))  || (collider.tag.Contains("Blue") && transform.tag.Contains("Red")))
				{
					transform.tag = "RedBlueWall";
					renderer.material = magentaMaterial;
				//	isDoubleColor = true;

					collider.transform.tag = "RedBlueWall";
					collider.renderer.material = magentaMaterial;
					//collider.GetComponent<Wall>().isDoubleColor = true;
				}

				if((collider.tag.Contains("Red") && transform.tag.Contains("Green"))  || (collider.tag.Contains("Green") && transform.tag.Contains("Red")))
				{
					transform.tag = "RedGreenWall";
					renderer.material = yellowMaterial;
					//isDoubleColor = true;

					collider.transform.tag = "RedGreenWall";
					collider.renderer.material = yellowMaterial;
					//collider.GetComponent<Wall>().isDoubleColor = true;
				}

				if((collider.tag.Contains("Green") && transform.tag.Contains("Blue"))  || (collider.tag.Contains("Blue") && transform.tag.Contains("Green")))
				{
					transform.tag = "GreenBlueWall";
					renderer.material = cyanMaterial;
					//isDoubleColor = true;

					collider.transform.tag = "GreenBlueWall";
					collider.renderer.material = cyanMaterial;
					//collider.GetComponent<Wall>().isDoubleColor = true;
				}
				isInAnotherWall = true;
				theAnotherWall = collider.gameObject;
			}
	}

	void OnTriggerExit(Collider collider)
	{
		if(collider.transform.tag.Contains("Wall") && !isDoubleColor && !collider.GetComponent<Wall>().isDoubleColor)// && collider.transform.tag != "RedBlueWall" && collider.transform.tag != "RedGreenWall" && collider.transform.tag != "GreenBlueWall")
		{
			renderer.material = originalMaterial;
			transform.tag = originalTag;
			isInAnotherWall = false;
		}
		else print ("Exit");
	}
}
