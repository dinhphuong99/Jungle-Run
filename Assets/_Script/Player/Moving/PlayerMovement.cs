using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public RayCastCheck rayCastCheck;
    public Transform PointLeft;
    public Transform PointRight;
    public Transform PointMiddle;
    public Transform PointUp;

    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public bool isGrounded = true;
    private bool reachMiddle = true;
    public bool isCround = false;
    public bool isFallOutWorld = false;
    bool isImpact = false;
    public bool isImpactPre = false;

    private Rigidbody rb;
    Vector3 currentPosition;
    private bool isPausedInAir = false; // Thêm biến này để theo dõi trạng thái "dừng lại trên không"

    [SerializeField] private KeyRebindManager keyRebind;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = transform.position;
        currentPosition.x = PointMiddle.position.x;
    }

    void Update()
    {
        Move();
        LimitHeight();
        isImpact = rayCastCheck.isImpact;
        if (isImpact)
        {
            isImpactPre = true;
        }
    }

    private void Move()
    {
        if (PointMiddle.position.y - transform.position.y > 1f)
        {
            isFallOutWorld = true;
            rb.useGravity = false;
        }

        if (isImpactPre)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, PointMiddle.position.z - 0.5f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, PointMiddle.position.z);
        }

        if ((currentPosition.x == PointRight.position.x) || (currentPosition.x == PointLeft.position.x))
        {
            reachMiddle = false;
        }

        if ((currentPosition.x == PointMiddle.position.x) && !keyRebind.isMoveLeft && !keyRebind.isMoveRight)
        {
            reachMiddle = true;
        }

        if (reachMiddle)
        {
            if (keyRebind.isMoveLeft && Mathf.Approximately(currentPosition.x, PointMiddle.position.x))
            {
                // Move to PointLeft
                currentPosition.x = PointLeft.position.x;
                transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
            }
            else if (keyRebind.isMoveRight && Mathf.Approximately(currentPosition.x, PointMiddle.position.x))
            {
                // Move to PointRight
                currentPosition.x = PointRight.position.x;
                transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (keyRebind.isMoveLeft && Mathf.Approximately(currentPosition.x, PointRight.position.x))
            {
                // Move to PointMiddle
                currentPosition.x = PointMiddle.position.x;
                transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
            }
            else if (keyRebind.isMoveRight && Mathf.Approximately(currentPosition.x, PointLeft.position.x))
            {
                // Move to PointMiddle
                currentPosition.x = PointMiddle.position.x;
                transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
            }
        }

        // Jump Up
        if (keyRebind.isJump && isGrounded && currentPosition.y < PointUp.position.y)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }

        // Fall Down
        if (keyRebind.isCrouch && currentPosition.y > PointMiddle.position.y && !isGrounded)
        {
            rb.MovePosition(new Vector3(currentPosition.x, Mathf.Max(currentPosition.y - moveSpeed * Time.deltaTime, PointMiddle.position.y), currentPosition.z));
        }

        if (keyRebind.isCrouch && isGrounded)
        {
            isCround = true;
        }

        if (!keyRebind.isCrouch || !isGrounded)
        {
            isCround = false;
        }
    }

    private void LimitHeight()
    {
        // Khi nhân vật chạm đến PointUp, tạm dừng trong 0.25 giây
        if (transform.position.y >= PointUp.position.y && rb.velocity.y > 0 && !isPausedInAir)
        {
            StartCoroutine(PauseInAir());  // Bắt đầu dừng lại trên không
        }
    }

    private IEnumerator PauseInAir()
    {
        isPausedInAir = true;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Dừng vận tốc dọc
        rb.useGravity = false; // Tắt trọng lực
        yield return new WaitForSeconds(0.5f); // Chờ 0.25 giây
        rb.useGravity = true; // Bật lại trọng lực
        isPausedInAir = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
