using UnityEngine;
using System.Collections;

public class WrapToScreen : MonoBehaviour 
{
	// Update is called once per frame
	void Update ()
	{
		//Check to see if the object has exceeded the screen bounds
		if(transform.position.x > CameraBounds.Instance.HorizontalEdge)
		{
			transform.position -= CameraBounds.Instance.HorizontalOffset;
		}
		else if(transform.position.x < -CameraBounds.Instance.HorizontalEdge)
		{
			transform.position += CameraBounds.Instance.HorizontalOffset;
		}
		if(transform.position.y > CameraBounds.Instance.VerticalEdge)
		{
			transform.position -= CameraBounds.Instance.VerticalOffset;
		}
		else if(transform.position.y < -CameraBounds.Instance.VerticalEdge)
		{
			transform.position += CameraBounds.Instance.VerticalOffset;
		}
	}
}
