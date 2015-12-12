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
		isMouseOver = true;

	}

	void OnMouseExit() {
		isMouseOver = false;
	}

	void Update() {
		if (isMouseOver == true) {
			foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
				if (Input.GetKeyDown(kcode)) {
					GetComponent<TextMesh>().text = kcode.ToString();

					if(configKey == "coilLeft") {
						PlayerPrefs.SetString("coilLeft",kcode.ToString());					
					}
					if(configKey == "coilRight") {
						PlayerPrefs.SetString("coilRight",kcode.ToString());					
					}

				}
			}
		}
	}
}
