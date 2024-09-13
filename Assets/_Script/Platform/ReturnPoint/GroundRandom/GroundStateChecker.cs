using UnityEngine;

public class GroundStateChecker : MonoBehaviour
{
    public bool IsAtReturnPoint(Transform returnPoint, Transform currentTransform)
    {
        return Vector3.Distance(returnPoint.position, currentTransform.position) <= 0.1f;
    }

    public bool IsNearReturnPoint(Transform returnPoint, Transform currentTransform)
    {
        float distance = Vector3.Distance(returnPoint.position, currentTransform.position);
        return distance > 0.2f && distance < 0.3f;
    }
}