using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string GroundTag = "Ground";
    private const string ObstacleTag = "Obstacle";
    private const float VolumeScale = 0.5f;
    private const int jumpAmount = 2;


    public KeyCode DashKey;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] private float jumpForce;

    private int jumpCounter = 0;

    public bool dashPressed;
    public bool isGameOver;
    private bool isOnGround;

    private Rigidbody playerRigidbody;
    private AudioSource playerAudio;
    private Animator playerAnim;
    public bool obstaclePassed;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(DashKey))
            dashPressed = !dashPressed;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            Jump();

            jumpCounter++;
            dirtParticle.Stop();
            isOnGround = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < jumpAmount && !isGameOver)
        {
            Jump();

            jumpCounter++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            jumpCounter = 0;
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag(ObstacleTag))
        {
            Die();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstaclePassed = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstaclePassed = true;
        }
    }

    private void Jump()
    {
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnim.SetTrigger("Jump_trig");
        playerAudio.PlayOneShot(jumpSound, VolumeScale);
    }

    private void Die()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        explosionParticle.Play();
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, VolumeScale);
    }
}
