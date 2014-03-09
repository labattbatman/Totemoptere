using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	public GameObject player;
	public Texture2D p_R; 
	public Texture2D p_G; 
	public Texture2D p_B;
	
	public int t_R;
	public int t_G;
	public int t_B;
	
	public float temps;
	
	void OnGUI(){
		
		
		// Ressources
		t_R = player.GetComponent<CreateWall>().Rressource;
		t_G = player.GetComponent<CreateWall>().Gressource;
		t_B = player.GetComponent<CreateWall>().Bressource;
		
		GUI.Box (new Rect (10,10,140,130), "Ressources:");
 		GUI.Box (new Rect (15,35,130,30), new GUIContent(" "+t_R.ToString(), p_R));
		GUI.Box (new Rect (15,70,130,30), new GUIContent(" "+t_G.ToString(), p_G));
		GUI.Box (new Rect (15,105,130,30), new GUIContent(" "+t_B.ToString(), p_B)); 
		
		
		// Temps restant
		temps = player.GetComponent<CreateWall>().TempsRestant;
		temps = Mathf.Round(temps * 100f) / 100f;
		
		GUI.Box (new Rect (Screen.width - 150,10,140,60), "Temps:");
 		GUI.Box (new Rect (Screen.width - 145,35,130,30), temps.ToString());
	}

    void FixedUpdate()
    {
        if(player.GetComponent<CreateWall>().TempsRestant <= 0.01f)
            this.GetComponent<VictoryCondition>().player1Win();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Start") || Input.GetButtonDown("StartP2"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                player.GetComponent<PlayerMove>().isActive = true;
            }
            else
            {
                player.GetComponent<PlayerMove>().isActive = false;
                Time.timeScale = 0;
            }
        }

        if (Input.GetButtonDown("gameExit") || Input.GetButtonDown("gameExitP2"))
        {
            Application.Quit();
        }
    }
}
