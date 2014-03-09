using UnityEngine;
using System.Collections;

public class Totem : MonoBehaviour {

	public int LIVES = 5;
	public int HITS = 0;
	public int HEIGHT = 0;
	
 	public GameObject totem_body1;
	public GameObject totem_body2;
	public GameObject totem_body3;
	public GameObject totem_body4;
	public GameObject totem_body5; 
	public GameObject totemPrefab;

	public bool isBodyDead = false;
	private float invincibleBody;
	private float invincibleBodyCounter = 2;

	
	// Update is called once per frame
	void Update () {

		if(isBodyDead)
		{
			invincibleBody += Time.deltaTime;
			if(invincibleBody > invincibleBodyCounter)
			{
				isBodyDead = false;
				invincibleBody = 0;
			}
		}
	}	
	
	/////////////////////////////////////////////////////////////////
	
	void Fall(int p){
	
		if(p <= 2){
			totem_body2.GetComponent<TotemBody>().isGrounded = false;
			totem_body2.GetComponent<TotemBody>().isPlaced = false;
		}
		
		if(p <= 3){
			totem_body3.GetComponent<TotemBody>().isGrounded = false;
			totem_body3.GetComponent<TotemBody>().isPlaced = false;
		}
		
		if(p <= 4){
			totem_body4.GetComponent<TotemBody>().isGrounded = false;
			totem_body4.GetComponent<TotemBody>().isPlaced = false;
		}
		
		if(p <= 5){
			totem_body5.GetComponent<TotemBody>().isGrounded = false;
			totem_body5.GetComponent<TotemBody>().isPlaced = false;
		}
		
		HEIGHT = 0;
	}
	
	///////////////////////////////////////////////////////////////////

	public void killBodyTotem()
	{

		if(LIVES < 0)
			return;
		LIVES--;
		HITS++;
		
		switch(HITS){
		case 1:
			Destroy(this.totem_body1);
			Fall(2);
			break;
			
		case 2:
			Destroy(this.totem_body2);
			Fall(3);
			break;
			
		case 3:
			Destroy(this.totem_body3);
			Fall(4);
			break;
			
		case 4:
			Destroy(this.totem_body4);
			Fall(5);
			break;
			
		case 5:
			Destroy(this.totem_body5);
            this.GetComponent<VictoryCondition>().player2Win();
			break;
		}
	}
}
