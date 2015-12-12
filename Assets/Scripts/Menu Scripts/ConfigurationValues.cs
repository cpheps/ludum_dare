using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class ConfigurationValues : MonoBehaviour {

	public string configKey;
	private Boolean isMouseOver = false;
	private string[] lines;
	private string originalValue;

	void Start () {

		if(configKey == "coilLeft") {
			GetComponent<TextMesh>().text = PlayerPrefs.GetString ("coilLeft");
		}
		if(configKey == "coilRight") {
			GetComponent<TextMesh>().text = PlayerPrefs.GetString ("coilRight");
		}

	}

	void OnMouseOver () {
		GetComponent<TextMesh> ().color = Color.blue;
		isMouseOver = true;

	}

	void OnMouseExit() {
		GetComponent<TextMesh> ().color = Color.white;	
		isMouseOver = false;
	}

	void Update() {
		if (isMouseOver == true) {

			foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
				if (Input.GetKeyDown(kcode)) {

					if(configKey == "coilLeft") {
						if(PlayerPrefs.GetString("coilRight") != (kcode.ToString())) {
							PlayerPrefs.SetString("coilLeft",kcode.ToString());
							GetComponent<TextMesh>().text = kcode.ToString();
						}
					}
					if(configKey == "coilRight") {
						if(!PlayerPrefs.GetString("coilLeft").Equals(kcode.ToString())) {
							PlayerPrefs.SetString("coilRight",kcode.ToString());
							GetComponent<TextMesh>().text = kcode.ToString();
						}
					}
				}
			}
		}
	}
}
