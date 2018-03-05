using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/954805/mesh-as-navmesh.html
//Put on your moving platform
public class NavMeshDynamic : MonoBehaviour
{
    protected Vector3 initialPosition;
    protected Quaternion initialRotation;

    // Use this for initialization
    void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public Vector3 getOffsetPosition()
    {
        return transform.position - initialPosition;
    }

    public Quaternion getOffsetRotation()
    {
        return transform.rotation * Quaternion.Inverse(initialRotation);
    }

    public Vector3 getCorrectedPosition(Vector3 position)
    {
        return position + (transform.position - initialPosition);
    }

    public Quaternion getCorrectedRotation(Quaternion rotation)
    {
        return rotation * transform.rotation * Quaternion.Inverse(initialRotation);
    }

    public Vector3 getInitialPosition()
    {
        return initialPosition;
    }

    public Quaternion getInitialRotation()
    {
        return initialRotation;
    }
}
