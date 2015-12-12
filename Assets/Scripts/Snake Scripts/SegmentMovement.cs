using UnityEngine;
using System.Collections;

public class SegmentMovement: MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			transform.localRotation = Quaternion.Lerp (transform.localRotation, Quaternion.Euler (0, 0, -30), Time.deltaTime*5);
		} else if(transform.root!=transform) {
			transform.localRotation = Quaternion.Lerp (transform.localRotation, Quaternion.Euler (0, 0, 0), Time.deltaTime*5);
		}
	}
		
	public void Grow(){
		if (transform.childCount == 0) {
			GameObject child = Instantiate(gameObject);
			child.name = "Segment";
			child.transform.parent = this.transform;
			child.transform.localRotation = transform.rotation;
			child.transform.localPosition = new Vector3(-0.5f,0f,0f);
		}
		else
		{
			foreach(Transform child in transform)
			{
				SegmentMovement segmentMovement = child.GetComponent<SegmentMovement>();
				segmentMovement.Grow();
			}
		}
	}
}
