using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCheck : MonoBehaviour
{
    public MovePlatform movePlatform;
    public PlayerMovement playerMovement;
    public bool isImpact = false;
    public bool isFallOutWorld = false;

    public Transform leftPoint;
    public Transform rightPoint;
    public Transform leftPointUp;
    public Transform rightPointUp;
    public LayerMask layerMask;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isCround)
        {
            CheckImpact(0.8f);
        }
        else
        {
            CheckImpact(2.25f);
        }

        if (playerMovement.isFallOutWorld || isImpact)
        {
            movePlatform.enabled = false;
        }
    }

    public void CheckImpact(float distanceCheck)
    {
        if(Physics.Raycast(leftPoint.position, Vector3.up, distanceCheck, layerMask)
            || Physics.Raycast(rightPoint.position, Vector3.up, distanceCheck, layerMask)
            || Physics.Raycast(leftPoint.position, Vector3.forward, 0.1f, layerMask)
            || Physics.Raycast(rightPoint.position, Vector3.forward, 0.1f, layerMask)
            || Physics.Raycast(leftPointUp.position, Vector3.down, 1.1f, layerMask)
            || Physics.Raycast(rightPointUp.position, Vector3.down, 1.1f, layerMask))
        {
            isImpact = true;
            return;
        }
        else
        {
            isImpact = false;
            return;
        }
    }
}
