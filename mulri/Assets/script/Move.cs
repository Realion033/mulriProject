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

        // ����� �ҽ� ����
        Asu.clip = walk;
        Asu.loop = true; // �ݺ� ��� ���� (�ȴ� ���� ��� ���)
        Asu.playOnAwake = false; // ���� �� ������� �ʵ��� ����
    }

    private void Update()
    {
        

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);

            // ���� ó��
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            // ������ �� ����� ���
            if (moveX != 0 || moveZ != 0)
            {
                if (!Asu.isPlaying)
                {
                    Asu.Play();
                }
            }
            else
            {
                // ���� �� ����� ����
                Asu.Stop();
            }
            // �̵� ó��
        
       
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        

        // �߷� ó��

        // ���� �Ͻ� ���� ��� (��: ESC Ű�� ���� ��)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            if (isGamePaused)
            {
                Time.timeScale = 0; // ���� �Ͻ� ����
            }
            else
            {
                Time.timeScale = 1; // ���� �ٽ� ����
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
