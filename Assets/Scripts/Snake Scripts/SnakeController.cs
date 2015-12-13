using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour {
    private Color32 playerColor = Color.black;
    private List<GameObject> segments = new List<GameObject>();
    public GameObject segment;
    public bool playerControlled = true;
    public bool turnRight = false;
    public bool turnLeft = false;

    public void gameStart()
    {
        InvokeRepeating( "Move", .020f, .020f );
    }

    public Color32 PlayerColor
    {
        set
        {
            playerColor = value;
            for (int segmentIndex = 0; segmentIndex < segments.Count; ++segmentIndex)
            {
                segments[segmentIndex].GetComponent<Renderer>().material.color = playerColor;
            }
        }
    }

    void Start () {
        GameObject head = transform.Find("Head").gameObject;

        head.GetComponent<Renderer>().material.color = playerColor;

        segments.Add (head);

        //InvokeRepeating( "AddSegment", 1, 2 );
    }

    void Update () {
        if (playerControlled) {
            turnRight = Input.GetKey (KeyCode.S);
            turnLeft = Input.GetKey (KeyCode.A);
        }
    }

    void Move() {
        for(int i = segments.Count; i > 1; --i)
        {
            float offSet = i == 2 ? 2 : 1.5f;
            segments[i - 1].transform.position = segments[i - 2].transform.position - segments[i - 2].transform.forward * offSet;
            segments[i-1].transform.rotation = segments[i-2].transform.rotation;
        }
        segments[0].transform.Translate(Vector3.forward * 10 * Time.deltaTime);

        if (turnLeft) {
            segments [0].transform.localRotation *= Quaternion.Euler(Vector3.up * 5);
        } else if (turnRight) {
            segments [0].transform.localRotation *= Quaternion.Euler (Vector3.up * -5);
        }
    }

    public void AddSegment(){
        GameObject predecessor = segments [segments.Count - 1];
        GameObject g = (GameObject)GameObject.Instantiate (segment, new Vector3(-50, -50, -50), predecessor.transform.rotation);
        g.GetComponent<Renderer>().material.color = playerColor;
        g.transform.parent = this.transform;

        float offSet = segments.Count == 1 ? 2 : 1.5f;
        g.transform.position = predecessor.transform.position - predecessor.transform.forward * offSet;
        g.name = "Segment" + segments.Count;
        segments.Add (g);
    }

    public void removeAllSegmentsAfter(Dictionary<string, GameObject> hitSegmentandAttackingSnake )
    {
		int segmentIndex = segments.IndexOf( hitSegmentandAttackingSnake["attackedSnake"]);
		int decreaseScoreBy = segments.Count - segmentIndex;
		ScoreKeeper.Instance.decreaseScore(hitSegmentandAttackingSnake["attackedSnake"].transform.parent.gameObject.name.ToString(), decreaseScoreBy);
		ScoreKeeper.Instance.increaseScore (hitSegmentandAttackingSnake ["attackingSnake"].name.ToString (), decreaseScoreBy);

        for (int removeIndex = segmentIndex; removeIndex < segments.Count; ++removeIndex )
        {
            Destroy( segments[removeIndex] );
        }

        segments.RemoveRange( segmentIndex, segments.Count - segmentIndex );
    }


}
