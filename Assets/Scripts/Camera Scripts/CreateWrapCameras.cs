using UnityEngine;
using System.Collections;

public class CreateWrapCameras : MonoBehaviour 
{

	public GameObject wrapCam;


	// Use this for initialization
	void Start ()
	{
		LayoutCameras();
	}

	void Update()
	{
		if(CameraBounds.Instance.ScreenChanged)
		{
			LayoutCameras();
		}
	}

	void LayoutCameras()
	{
		//Destroy any wrap cameras (if they exist)
		foreach(GameObject cam in GameObject.FindGameObjectsWithTag("WrapCamera"))
		{
			Destroy(cam);
		}

		//Instantiate our cameras at the proper position
		//Side cameras
		Instantiate(wrapCam, transform.position + CameraBounds.Instance.HorizontalOffset, wrapCam.transform.rotation);
		Instantiate(wrapCam, transform.position - CameraBounds.Instance.HorizontalOffset, wrapCam.transform.rotation);
		Instantiate(wrapCam, transform.position + CameraBounds.Instance.VerticalOffset, wrapCam.transform.rotation);
		Instantiate(wrapCam, transform.position - CameraBounds.Instance.VerticalOffset, wrapCam.transform.rotation);

		//Corner cameras
		Instantiate(wrapCam, transform.position + CameraBounds.Instance.HorizontalOffset + CameraBounds.Instance.VerticalOffset, wrapCam.transform.rotation);
		Instantiate(wrapCam, transform.position + CameraBounds.Instance.HorizontalOffset - CameraBounds.Instance.VerticalOffset, wrapCam.transform.rotation);
		Instantiate(wrapCam, transform.position - CameraBounds.Instance.HorizontalOffset + CameraBounds.Instance.VerticalOffset, wrapCam.transform.rotation);
		Instantiate(wrapCam, transform.position - CameraBounds.Instance.HorizontalOffset - CameraBounds.Instance.VerticalOffset, wrapCam.transform.rotation);
	}
}
