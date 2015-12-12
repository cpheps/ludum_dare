using UnityEngine;
using System.Collections;

public class MenuItemOnMouseHover : MonoBehaviour {

	private GUIText menuItemText;

	void OnMouseOver() {
		this.GetComponentInChildren<TextMesh> ().color = Color.green;
	}

	void OnMouseExit() {
		this.GetComponentInChildren<TextMesh> ().color = Color.white;
	}
}
