using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour {

    public float R = 0;
    public float G = 0;
    public float B = 0;

    // Use this for initialization
    void Start () {
        //Renderer rend = GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("Standard");
        //rend.material.SetColor("_SpecColor", new Color(R, G, B));

        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = new Color(R, G, B);
        GetComponent<Renderer>().material = material;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
