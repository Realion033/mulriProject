using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float gravity = -3f;
    private UIManager uiManager;

    public GameObject diesee;
    public GameObject monster;
    public GameObject monstera;
    public AudioClip walk;
    private AudioSource Asu;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isGamePaused = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
        Asu = GetComponent<AudioSource>();

        // 오디오 소스 설정
        Asu.clip = walk;
        Asu.loop = true; // 반복 재생 설정 (걷는 동안 계속 재생)
        Asu.playOnAwake = false; // 시작 시 재생하지 않도록 설정
    }

    private void Update()
    {
        

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

            // 움직일 때 오디오 재생
            if (moveX != 0 || moveZ != 0)
            {
                if (!Asu.isPlaying)
                {
                    Asu.Play();
                }
            }
            else
            {
                // 멈출 때 오디오 정지
                Asu.Stop();
            }
            // 이동 처리
        
       
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        

        // 중력 처리

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
        if (collision.gameObject.CompareTag("Monster"))
        {
            Debug.Log("die");
            monster.SetActive(false);
            
            diesee.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
}
