using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float gravity = -3f;
    private UIManager uiManager;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isGamePaused = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    private void Update()
    {
        if (!uiManager.UIactive && !isGamePaused)
        {
            // 이동 처리
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);

            // 점프 처리
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        // 중력 처리
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);

        // 게임 일시 정지 토글 (예: ESC 키를 누를 때)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            if (isGamePaused)
            {
                Time.timeScale = 0; // 게임 일시 정지
            }
            else
            {
                Time.timeScale = 1; // 게임 다시 시작
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
