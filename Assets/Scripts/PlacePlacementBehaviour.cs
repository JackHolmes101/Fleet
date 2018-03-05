using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlacementBehaviour : MonoBehaviour {

    //public Camera camera;
    public GameObject BoundsObject;
    public GameObject Placement;
    Vector3 targetPosition;
    Bounds constructionBounds;
    Bounds placementBounds;

    // Use this for initialization
    void Start () {
        Renderer boundsRenderer = BoundsObject.GetComponent<Renderer>();
        constructionBounds = boundsRenderer.bounds;
        Renderer placementRenderer = Placement.GetComponent<Renderer>();
        placementBounds = placementRenderer.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Placement.transform.position);
        //Bind the mousePosition with Object in 3D space.
        Vector3 bindMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
        //Now just restrict the Y axis with a fixed position and give X and Z of bindMousePosition to move a gameObect in X-Z plane.
        targetPosition = new Vector3(bindMousePosition.x, 0, bindMousePosition.z);

        //Placement.transform.position = targetPosition;

        if (constructionBounds.Contains(targetPosition))
        {
            Placement.transform.position = targetPosition;
        }
        else
        {
            Placement.transform.position = constructionBounds.ClosestPoint(targetPosition);
        }

    }
}
