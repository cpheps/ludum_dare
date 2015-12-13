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
		if(player.Equals("Player1")){
			return playerOneScore;
		} 
		else if (player.Equals("Player2")){
			return playerTwoScore;
		}
		else if (player.Equals("Player3")){
			return playerThreeScore;
		} 
		else if (player.Equals ("Player4")){
			return playerFourScore;
		}
		return -1;
	}


	public int[] getAllScores() {
		return new int[] {playerOneScore, playerTwoScore, playerThreeScore, playerFourScore};
	}

	public void increaseScore(string player, int amount){
		if(player.Equals("Player1")){
			playerOneScore += amount;
		} 
		else if (player.Equals("Player2")){
			playerTwoScore += amount;
		}
		else if (player.Equals("Player3")){
			playerThreeScore += amount;
		} 
		else if (player.Equals ("Player4")){
			playerFourScore += amount;
		}
	}

	public void decreaseScore(string player, int amount){
		if(player.Equals("Player1")){
			playerOneScore -= amount;
		} 
		else if (player.Equals("Player2")){
			playerTwoScore -= amount;
		}
		else if (player.Equals("Player3")){
			playerThreeScore -= amount;
		} 
		else if (player.Equals ("Player4")){
			playerFourScore -= amount;
		}
	}

	public void resetScores(){
		playerOneScore = 0;
		playerTwoScore = 0;
		playerThreeScore = 0;
		playerFourScore = 0;
	}
}
