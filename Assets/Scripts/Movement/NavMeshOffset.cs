using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/954805/mesh-as-navmesh.html
//Put on your renderer (should be child of your navmesh agent)
public class NavMeshOffset : MonoBehaviour {

    public NavMeshDynamic navMeshDynamic;
    public GameObject objectToMove;

    protected Quaternion initialObjectRotation;

    void Awake()
    {
        initialObjectRotation = objectToMove.transform.rotation;
    }

    void LateUpdate()
    {
        //Correct position from object rotation
        Vector3 offsetDirection = objectToMove.transform.position - navMeshDynamic.getInitialPosition();
        Vector3 offsetDirectionRotated = navMeshDynamic.getOffsetRotation() * offsetDirection;
        transform.position = navMeshDynamic.transform.position + offsetDirectionRotated;
        transform.rotation = objectToMove.transform.rotation * navMeshDynamic.getOffsetRotation();
    }
}
