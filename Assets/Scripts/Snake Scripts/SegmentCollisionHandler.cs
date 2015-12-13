using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SegmentCollisionHandler : MonoBehaviour {
    void OnTriggerEnter( Collider collider )
    {
        if ( collider.tag == "Snake Head" )
        {
			Dictionary<string, GameObject> snakes = new Dictionary<string , GameObject>{
				{"attackedSnake", gameObject},
				{"attackingSnake", collider.transform.parent.gameObject}
			};
			SendMessageUpwards( "removeAllSegmentsAfter", snakes );   
		}
    }
}
