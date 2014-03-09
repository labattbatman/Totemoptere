using UnityEngine;
using System.Collections;

public class CreateWall : MonoBehaviour {
	
	public GameObject wallPrefab;
	public GameObject thePlatform;
	GameObject theWall;

	public int Rressource = 10;
	public int Bressource = 10;
	public int Gressource = 10;
	public float TempsRestant = 30.0f;

	public Material RedMat;
	public Material GreenMat;
	public Material BlueMat;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (TempsRestant >= 0.01)
        {
            TempsRestant -= Time.deltaTime;
        }
        else
            TempsRestant = 0.0f;

		if(Input.GetButtonDown("WallR") && Rressource > 0)
			CreateInvisibleWall(1);

		if(Input.GetButtonDown("WallB") && Bressource > 0)
			CreateInvisibleWall(2);

		if(Input.GetButtonDown("WallG") && Gressource > 0)
			CreateInvisibleWall(3);


		if((Input.GetButton("WallR") || Input.GetButton("WallG") || Input.GetButton("WallB")) && theWall != null)
			ShowAWall();
		if((Input.GetButtonUp("WallR") || Input.GetButtonUp("WallG") || Input.GetButtonUp("WallB")) && theWall != null)
			CreateAWall();
		
	}
	
	void CreateAWall()
	{

		Color originalColour = theWall.renderer.material.color;
		originalColour.a = 1;
		theWall.renderer.material.color = originalColour;
		//theWall.transform.parent = thePlatform.transform;
		theWall = null;	
	}
	
	void ShowAWall()
	{
		Vector3 posWall = (this.transform.forward * 3 + this.transform.position);
		theWall.transform.position = findPlatformPoint(posWall);

		Vector3 leLookAt = this.transform.position;
		leLookAt.y -= 2.2f;


		theWall.transform.parent = thePlatform.transform;
		Quaternion quat = Quaternion.AngleAxis(GameObject.Find("Player").transform.rotation.eulerAngles.y, Vector3.up);
		Vector3 direction = quat * Vector3.forward;

		theWall.transform.localRotation = quat;//.LookAt(leLookAt,thePlatform.transform.up);
		
	}
	
	void CreateInvisibleWall(int color)
	{
		Vector3 posWall = (this.transform.forward + this.transform.position);
		theWall = (GameObject)Instantiate(wallPrefab,posWall,new Quaternion(0,0,0,0));
		theWall.GetComponent<Collider>().isTrigger = false;

		switch(color)
		{
		case 1: theWall.renderer.material = RedMat; Rressource--; theWall.transform.tag = "RedWall"; break;
		case 2: theWall.renderer.material = BlueMat; Bressource--; theWall.transform.tag = "BlueWall"; break;
		case 3: theWall.renderer.material = GreenMat; Gressource--; theWall.transform.tag = "GreenWall"; break;
		default: break;
		}

		Color originalColour = theWall.renderer.material.color;
		originalColour.a = 0.25f;
		theWall.renderer.material.color = originalColour;
		print (originalColour);
		
	}
	
	Vector3 findPlatformPoint(Vector3 startingPoint)
	{
		RaycastHit hit;
		Vector3 RayCastPos = startingPoint + new Vector3(0,10,0);

		int layerMask = 1 << LayerMask.NameToLayer("Platform");

		if(Physics.Raycast(RayCastPos, Vector3.down, out hit, 100, layerMask))
		{
			print ("teste");
			return hit.point; 
		}

		return Vector3.zero;
	}
}
