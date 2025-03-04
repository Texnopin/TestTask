using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    bool isTaken = false;

    void Update()
    {
        if (isTaken)
        {
            transform.localPosition = Vector3.zero;
        }
    }

    public void TakeObject(Transform parent)
    {
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        isTaken = true;
    }

    public void DropObject()
    {
        transform.parent = null;
        isTaken = false;
    }
}
