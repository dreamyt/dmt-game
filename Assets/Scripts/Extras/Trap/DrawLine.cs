using UnityEngine;
using System.Collections;
 
public class DrawLine : MonoBehaviour {
    public GameObject[] targets; // the objects to draw the line between
    // Use this for initialization
    private LineRenderer l;
    void Start () {
        l =this.GetComponent<LineRenderer>();
    }
     
    // Update is called once per frame
    void Update () {
        Vector3 p1 = targets [0].transform.position;
        Vector3 p2 = targets [1].transform.position;
        Vector3 lineVector = p2 - p1;
        l.SetPosition (0, p1);
        l.SetPosition (1, p2);
    }
}