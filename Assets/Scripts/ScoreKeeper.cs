using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class ScoreKeeper : MonoBehaviour {
	Dictionary<string, int> scores = new Dictionary<string, int>{
		{"Player1", 0},
		{"Player2", 0},
		{"Player3", 0},
		{"Player4", 0}
	};
		
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
		return scores [player];
	}


	public int[] getAllScores() {
		return new int[]{scores ["Player1"], scores ["Player2"], scores ["Player3"], scores ["Player4"]};
	}

	public void increaseScore(string player, int amount){
		scores [player] += amount;
	}

	public void decreaseScore(string player, int amount){

		scores [player] -= amount;
	}

	public void resetScores(){
		scores ["Player1"] = 0;
		scores ["Player2"] = 0;
		scores ["Player3"] = 0;
		scores ["Player4"] = 0;
	}
}
