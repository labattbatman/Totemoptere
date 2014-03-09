using UnityEngine;
using System.Collections;

public class VictoryCondition : MonoBehaviour 
{
    private int timer = 30;

    public GameObject player;

    private bool gameAsEnded = false;

    private bool p1Win = false;
    private bool p2Win = false;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        //if (gameAsEnded)
        //{
        //    print("game end");
        //    timer--;
        //    if (timer <= 0) gameRestart();
        //}
	}

    public void player1Win()
    {
        p1Win = true;
        gameEnd();
        print("bebitte wins");
    }

    public void player2Win()
    {
        p2Win = true;
        print("Armadildo wins");
        gameEnd();
    }

    void gameEnd()
    {
        gameAsEnded = true;
        player.GetComponent<PlayerMove>().isActive = false;
        Time.timeScale = 0;
    }

    void gameRestart()
    {
        Application.LoadLevel("MainScene");
    }

    void LateUpdate()
    {
        if (gameAsEnded) timer--;

        if (Input.anyKeyDown && gameAsEnded && timer <= 0)
        {
            Time.timeScale = 1;
            player.GetComponent<PlayerMove>().isActive = true;
            gameRestart();
        }
    }

    void OnGUI()
    {
        if (gameAsEnded)
        {
            if (p1Win)
            {
				GUI.Label(new Rect(Screen.width - Screen.width / 2, Screen.height - Screen.height / 2, 250, 300), "Totemoptère Wins!");
            }
			else if(p2Win)
            {
				GUI.Label(new Rect(Screen.width - Screen.width / 2, Screen.height - Screen.height / 2, 250, 300), "Armadillo Wins!");
            }
        }
            
    }
}
