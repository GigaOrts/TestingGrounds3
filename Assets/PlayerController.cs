using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string GroundTag = "Ground";
    private const string ObstacleTag = "Obstacle";

    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] private float jumpForce;

    private Rigidbody playerRigidbody;
    private Animator playerAnim;
    private bool isOnGround;
    public bool isGameOver;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag(ObstacleTag))
        {
            isGameOver = true;
            Debug.Log("GAME OVER");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
