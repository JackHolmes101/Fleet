using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour {

    private float r = 0;
    private float g = 0;
    private float b = 0;

    public float R {
        get { return r; }
        set
        {
            r = value;
            updateColor();
        }
    }

    public float G
    {
        get { return g; }
        set
        {
            g = value;
            updateColor();
        }
    }

    public float B
    {
        get { return b; }
        set
        {
            b = value;
            updateColor();
        }
    }

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void updateColor()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(r, g, b);
    }
}
