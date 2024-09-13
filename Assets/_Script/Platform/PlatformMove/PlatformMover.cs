using UnityEngine;

public interface IMovable
{
    void Move(Vector3 targetPosition, float speed);
}

public class PlatformMover : IMovable
{
    private Transform _transform;

    public PlatformMover(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 targetPosition, float speed)
    {
        _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, Time.deltaTime * speed);
    }
}
