using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikingMovement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float movement;
    public bool canMove = true;
    public AudioSource pointSound;
    private Animator animator;
    public GameObject retryMenu;
    [SerializeField] public CameraMovement cameraMovement;
    [SerializeField] public ScoreManager scoreManager;
    [SerializeField] public Text startCountdown;
    [SerializeField] public BikingPause bikingPause;
    public AudioSource jumpSound;
    public AudioSource obstacleSound;

    //Jump variables
    private bool isGrounded;
    public Transform basePos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private IEnumerator crashWait()
    {
        if (scoreManager.score >= 10)
        {
            startCountdown.text = "CONGRATS!";
            yield return new WaitForSecondsRealtime(3f);
            retryMenu.SetActive(true);
        }

        else
        {
            startCountdown.text = "TOO BAD";
            yield return new WaitForSecondsRealtime(3f);
            retryMenu.SetActive(true);
        } 
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {       
        if (canMove == true)
        {
            movement = 1;
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
           
        else
        {
            movement = 0;
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(basePos.position, checkRadius, whatIsGround);
        if (canMove == true && isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }    
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            pointSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            bikingPause.canPause = false;
            obstacleSound.Play();
            movement = 0;
            canMove = false;
            cameraMovement.camMoveEnabled = false;
            animator.SetTrigger("Crash");
            StartCoroutine(crashWait());
        }
    }
}
