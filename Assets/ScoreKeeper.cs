using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class ScoreKeeper : MonoBehaviour {
	private int playerOneScore = 0;
	private int playerTwoScore = 0;
	private int playerThreeScore = 0;
	private int playerFourScore = 0;
		
	public static ScoreKeeper Instance { get; private set; }

	void Awake()
	{
		if (Instance == null) {
			Instance = this;

		} else {
			Destroy (this);
		}
	}

	public int getScore(string player){
		switch(player){
		case "player1":
			return playerOneScore;
		case "player2":
			return playerTwoScore;
		case "player3":
			return playerThreeScore;
		case "player4":
			return playerFourScore;
		default:
			return -1;
		}
	}

	public void increaseScore(string player, int amount){
		switch(player){
		case "player1":
			playerOneScore += amount;
			break;
		case "player2":
			playerTwoScore += amount;
			break;
		case "player3":
			playerThreeScore += amount;
			break;
		case "player4":
			playerFourScore += amount;
			break;
		default:
			break;
		}
	}

	public void decreaseScore(string player, int amount){
		switch(player){
		case "player1":
			playerOneScore -= amount;
			break;
		case "player2":
			playerTwoScore -= amount;
			break;
		case "player3":
			playerThreeScore -= amount;
			break;
		case "player4":
			playerFourScore -= amount;
			break;
		default:
			break;
		}
	}

	public void resetScores(){
		playerOneScore = 0;
		playerTwoScore = 0;
		playerThreeScore = 0;
		playerFourScore = 0;
	}
}
