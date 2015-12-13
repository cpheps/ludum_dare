using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class ScoreKeeper : MonoBehaviour {
	private int playerOneScore = 0;
	private int playerTwoScore = 0;
	private int playerThreeScore = 0;
	private int playerFourScore = 0;
		
	public static ScoreKeeper Instance { get; private set; }

	void onAwake()
	{
		if (Instance == null) {
			Instance = this;

		} else {
			Destroy (this);
		}
	}

	public int getScore(){
		return playerOneScore;
	}

	public void increaseScore(int player, int amount){
		switch(player){
		case 1:
			playerOneScore += amount;
			break;
		case 2:
			playerTwoScore += amount;
			break;
		case 3:
			playerThreeScore += amount;
			break;
		case 4:
			playerFourScore += amount;
			break;
		default:
			break;
		}
	}

	public void decreaseScore(int player, int amount){
		switch(player){
		case 1:
			playerOneScore -= amount;
			break;
		case 2:
			playerTwoScore -= amount;
			break;
		case 3:
			playerThreeScore -= amount;
			break;
		case 4:
			playerFourScore -= amount;
			break;
		default:
			break;
		}
	}

	public void resetScores(int player, int amount){
		playerOneScore = 0;
		playerTwoScore = 0;
		playerThreeScore = 0;
		playerFourScore = 0;
	}
}
