using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour {

    public int GridScale = 1;
    public int FloorLevel = 1;

    // Use this for initialization
    void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
        var currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x / GridScale) * GridScale,
                                     Mathf.Round(FloorLevel / GridScale) * GridScale,
                                     Mathf.Round(currentPos.z / GridScale) * GridScale);
    }
}
