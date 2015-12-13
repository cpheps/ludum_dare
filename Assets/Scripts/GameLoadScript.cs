using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameLoadScript : MonoBehaviour {
    private bool startTime = false;

    static public int totalRounds = 3;
    static public int currentRound = 0;

    [SerializeField]
    private Color32[] playerColors;

    [SerializeField]
    private GameObject pelletGenerator;

    [SerializeField]
    private GameObject snake;

    [SerializeField]
    private int totalTimeOfRound = 120;
    
    [SerializeField]
    private int timeLeftInRound;

    private List<GameObject> createdSnakes = new List<GameObject>();

    // Use this for initialization
    void Start () {
		if (currentRound >= totalRounds) {
            Application.LoadLevel ("MainMenu");
            resetRounds();
        } else {
            currentRound = currentRound + 1;
            GameObject.FindGameObjectWithTag("Rounds").GetComponent<Text>().text = "Round " + currentRound + "/" + totalRounds;
        }

        
        for (int count = 1; count <= 4; ++count)
        {
            int multiplier = count * (count % 2 == 0 ? 2 : -2 );
            GameObject newSnake = GameObject.Instantiate(snake, new Vector3(multiplier, 0, 0), Quaternion.Euler(new Vector3(0, 0, 90))) as GameObject;
            newSnake.name = "Player" + count;
            SnakeController snakeController = newSnake.GetComponent<SnakeController>();
            snakeController.PlayerColor = playerColors[count - 1];
            snakeController.playerControlled = (count == 1);
            createdSnakes.Add(newSnake);

        }
        StartCoroutine(startCountDown());
    }

    void Update() {
        if (timeLeftInRound == 0) {
            startTime = false;
            Application.LoadLevel(Application.loadedLevel);
        }
        
        //Kind of hacky -- should fix
        if (startTime == true) {
            timeLeftInRound = totalTimeOfRound - (int)Time.timeSinceLevelLoad+3;
            GameObject.FindGameObjectWithTag("Time").GetComponent<Text>().text = ""+timeLeftInRound;
        }

		//Update Score Panel of HUD
		int[] scores = ScoreKeeper.Instance.getAllScores ();
		GameObject.FindGameObjectWithTag ("P1Score").GetComponent<Text> ().text = "" + scores [0];
		GameObject.FindGameObjectWithTag ("P2Score").GetComponent<Text> ().text = "" + scores [1];
		GameObject.FindGameObjectWithTag ("P3Score").GetComponent<Text> ().text = "" + scores [2];
		GameObject.FindGameObjectWithTag ("P4Score").GetComponent<Text> ().text = "" + scores [3];
    }

    private IEnumerator startCountDown()
    {
        yield return new WaitForSeconds(3);
        pelletGenerator.transform.SendMessage("gameStart", totalTimeOfRound);

        foreach (GameObject snake in createdSnakes)
        {
            snake.transform.SendMessage("gameStart");
        }
        
        startTime = true;
    }

    public void resetRounds() {
        currentRound = 0;
    }
}
