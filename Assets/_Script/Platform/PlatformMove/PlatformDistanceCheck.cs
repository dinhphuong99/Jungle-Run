using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDistanceCheck : MonoBehaviour
{
    public GameObject frontPlatform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckDistance()
    {
        if(Vector3.Distance(transform.position, frontPlatform.transform.position) 
            > 8.95f)
        {
            return false;
        }
        return true;
    }
}
