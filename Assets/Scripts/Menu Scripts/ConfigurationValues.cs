using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class ConfigurationValues : MonoBehaviour {

	public string configKey;

	void Start () {
		Char[] splitChars = {'='};
		string[] lines = File.ReadAllLines("Assets/controls.txt");
		foreach (string s in lines)
		{
			if(s != null) {
				String[] keyValue = s.Split(splitChars);
				string key = keyValue[0];
				string value = keyValue[1];

				if(key.Equals(configKey)) {
					GetComponent<TextMesh>().text = value;
				}
			}
		}
	}

	void OnMouseOver () {
	}

	void OnMouseExit() {
	}

	void Update() {
	}
}
