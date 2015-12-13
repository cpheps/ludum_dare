using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {

	public static CameraBounds Instance { get; private set; }

	#region Properties
	public Vector3 HorizontalOffset
	{
		get 
		{
			return horizontalOffset;
		}
	}

	public Vector3 VerticalOffset
	{
		get
		{
			return verticalOffset;
		}
	}

	public float HorizontalEdge
	{
		get 
		{
			return horizontalEdge;
		}
	}

	public float VerticalEdge
	{
		get
		{
			return verticalEdge;
		}
	}

	public Vector3 ZOffset
	{
		get
		{
			return zOffset;
		}
	}

	public bool ScreenChanged 
	{
		get 
		{
			return screenChanged;
		}
	}
	#endregion

	private Vector3 horizontalOffset = Vector3.zero;
	private Vector3 verticalOffset = Vector3.zero;
	private Vector3 zOffset = Vector3.zero;

	//Signals if resolution of screen has changed since last update
	private bool screenChanged = false;

	private float horizontalEdge = 0;
	private float verticalEdge = 0;

	private float oldScreenWidth = 0;
	private float oldScreenHeight = 0;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			//DontDestroyOnLoad(this);
			getScreenBounds();
		}
		else if (Instance != null)
		{
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(oldScreenWidth != Screen.width || oldScreenHeight != Screen.height)
		{
			screenChanged = true;
			getScreenBounds();
		}
		else
		{
			screenChanged = false;
		}	
	}

	void getScreenBounds()
	{
		//Save current res information
		oldScreenWidth = Screen.width;
		oldScreenHeight = Screen.height;

		//Figure out the screen bounds
		horizontalOffset = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0.5f, -Camera.main.transform.position.z));
		verticalOffset = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.5f, -Camera.main.transform.position.z));
		horizontalEdge = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.5f, -Camera.main.transform.position.z)).x;
		verticalEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.0f, -Camera.main.transform.position.z)).y;
	}
}
