using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject looseScreen;
    public Text healthDisplay;

    Rigidbody2D rb;
    Animator anim;
    private float input;
    
    public float speed = 20;
    public int health = 3;

    public float startDashTime = 0.1f;
    private float dashTime = 0f;
    public float extraSpeed = 75f;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        healthDisplay.text = health.ToString();
    }

    void Update()
    {
        anim.SetBool("isRunning", input != 0);
        transform.eulerAngles = new Vector3(0, input >= 0 ? 0 : 180, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false)
        {
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        if (dashTime <= 0 && isDashing == true)
        {
            isDashing = false;
            speed -= extraSpeed;
        }
        else{
            dashTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        input = Input.GetAxis("Horizontal"); //GetAxisRaw for "less smooth" feeling
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        audioSource.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            looseScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
