using UnityEngine;
using System.Collections;

public class GameLoadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("coilLeft", "A");
		PlayerPrefs.SetString ("coilRight", "S");
	}
}
