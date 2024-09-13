using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformWithParentObject : MonoBehaviour
{
    public Vector3 parentPosition;
    public Vector3 parentRotation;
    public Vector3 parentScale = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            transform.localPosition = parentPosition;
            transform.localRotation = Quaternion.Euler(parentRotation);
            transform.localScale = parentScale;
        }
    }
}
