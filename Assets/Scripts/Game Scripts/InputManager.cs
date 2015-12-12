using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{

	public static InputManager Instance { get; private set; }

	public bool CoilLeft
	{
		get 
		{
			return Input.GetKey(PlayerPrefs.GetString("coilLeft"));
		}
	}

	public bool CoilRight
	{
		get
		{
			return Input.GetKey(PlayerPrefs.GetString("coilRight"));
		}
	}
}
