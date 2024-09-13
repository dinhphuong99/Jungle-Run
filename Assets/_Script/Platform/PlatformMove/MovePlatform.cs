using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject returnPoint;
    public static float speed = 10f;
    public static float maxSpeed = 25f;

    private List<PlatformController> platformControllers;
    public GenRandomNumWorld genRandomNumWorld;
    public GameObject[] platforms; // Array of platforms to be managed

    void Start()
    {
        platformControllers = new List<PlatformController>();

        foreach (GameObject platform in platforms)
        {
            GroundRandom groundRandom = platform.GetComponent<GroundRandom>();
            PlatformDistanceCheck distanceCheck = platform.GetComponent<PlatformDistanceCheck>();
            platformControllers.Add(new PlatformController(
                platform.transform,
                endPoint.transform.position,
                returnPoint.transform.position,
                groundRandom,
                distanceCheck
            ));
        }
    }

    void Update()
    {
        foreach (var platformController in platformControllers)
        {
            if (!platformController.DistanceCheck.CheckDistance())
            {
                if (Vector3.Distance(platformController.EndPoint, platformController.Transform.position) == 0f)
                {
                    platformController.Transform.position = platformController.ReturnPoint;
                    genRandomNumWorld.GenerateCountNumber();
                    platformController.GroundRandom.CreateGround();
                    UpdateSpeed();
                }

                platformController.Move(speed);
            }
        }
    }

    public void UpdateSpeed()
    {
        speed = Mathf.Min(speed + 0.1f, maxSpeed);
    }
}

public class PlatformController
{
    public Transform Transform { get; private set; }
    public Vector3 EndPoint { get; private set; }
    public Vector3 ReturnPoint { get; private set; }
    public GroundRandom GroundRandom { get; private set; }
    public PlatformDistanceCheck DistanceCheck { get; private set; }
    private IMovable _mover;

    public PlatformController(
        Transform transform,
        Vector3 endPoint,
        Vector3 returnPoint,
        GroundRandom groundRandom,
        PlatformDistanceCheck distanceCheck
    )
    {
        Transform = transform;
        EndPoint = endPoint;
        ReturnPoint = returnPoint;
        GroundRandom = groundRandom;
        DistanceCheck = distanceCheck;
        _mover = new PlatformMover(transform);
    }

    public void Move(float speed)
    {
        _mover.Move(EndPoint, speed);
    }
}
