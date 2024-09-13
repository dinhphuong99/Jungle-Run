using UnityEngine;

public class PlatformPath
{
    public Vector3 EndPoint { get; private set; }
    public Vector3 ReturnPoint { get; private set; }

    public PlatformPath(Vector3 endPoint, Vector3 returnPoint)
    {
        EndPoint = endPoint;
        ReturnPoint = returnPoint;
    }
}