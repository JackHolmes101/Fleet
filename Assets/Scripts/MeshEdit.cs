using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Performs transformations on a mesh in real-time.
public class MeshEdit : MonoBehaviour
{
    public float width = 0; // The width of the plane.
    public float height = 0; // The height of the plane.
    public float updateInterval = 3; // The amount of time between updates.
    public float scaleIncrementAmount = 0.1f; // The amount of scaling that will occur per update.

    private float updateCountdown = 0; // The current time until the next update.
    private float currentScale = 1; // The current scale applied to the vertices.
    private MeshFilter mf = null;
    private Mesh mesh = null;

    void Start()
    {
        mf = GetComponent<MeshFilter>();
        mesh = new Mesh();
        mf.mesh = mesh;

        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(width, 0, 0);
        vertices[2] = new Vector3(0, height, 0);
        vertices[3] = new Vector3(width, height, 0);

        mesh.vertices = vertices;

        int[] tri = new int[6];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        mesh.triangles = tri;

        Vector3[] normals = new Vector3[4];

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;

        mesh.normals = normals;

        Vector2[] uv = new Vector2[4];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);

        mesh.uv = uv;
    }

    // Update is called once per frame
    void Update()
    {
        updateCountdown -= Time.deltaTime;

        if (updateCountdown <= 0.0f)
        {
            rescaleVertices();
            updateCountdown = updateInterval; // reset the timer.
            currentScale += scaleIncrementAmount;
        }      
    }

    private void rescaleVertices()
    {
        Vector3[] newVertices = mesh.vertices;
        for(int i = 0; i < mesh.vertices.Length; i++)
        {
            newVertices[i].Scale(new Vector3(currentScale, 1, currentScale));
        }

        mesh.vertices = newVertices;
    }
}
