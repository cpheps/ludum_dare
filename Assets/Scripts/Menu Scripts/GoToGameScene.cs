using UnityEngine;
using System.Collections;

public class GoToGameScene : MonoBehaviour {
	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			//GameObject.FindGameObjectWithTag("NewGame").SendMessage("resetRounds");
			Application.LoadLevel("GameScene");
		}
	}
}
