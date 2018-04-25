using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    public TextMesh infoText;
    public Player player;

    private float gameTimer = 0f;
    private float restartTimer = 3f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.reachedFinishLine == false)
        {
            gameTimer += Time.deltaTime;

            infoText.text = "Avoid Obstacles!\nPress the button to jump!\nTime: " + Mathf.Floor(gameTimer);
        }
        else
        {
            infoText.text = "\nYou Win!\nYour Time: " + Mathf.Floor(gameTimer);
            player.maxSpeed = 1f;
            restartTimer -= Time.deltaTime;

            if (restartTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


	}
}
