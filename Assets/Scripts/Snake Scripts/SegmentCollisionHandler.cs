using UnityEngine;
using System.Collections;

public class SegmentCollisionHandler : MonoBehaviour {
    void OnTriggerEnter( Collider collider )
    {
        if ( collider.tag == "Snake Head" )
        {
            SendMessageUpwards( "removeAllSegmentsAfter", gameObject );            
        }
    }
}
