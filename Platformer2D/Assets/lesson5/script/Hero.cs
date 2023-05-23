using Assets.lesson5;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Hero : MonoBehaviour
{

    public int heartCount;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptuHeart;
    public float speed = 2f;
    public float jumpForce = 5f;
    public Joystick joystick;
    public Transform GroundCheck;
    public LayerMask Ground;
    [SerializeField] Bullet bullet;
    [SerializeField] LayerMask enemyBulletMask;
    [SerializeField] GameObject restartPanel;
    AudioService audioService;

    Rigidbody2D rb;
    Animator anim;
    Vector2 moveVector;
    bool faceRight = true;
    bool onGround;
    float checkRadius = 0.3f;


    void Start()
    {
        audioService = FindObjectOfType<AudioService>();
        if (GameLoader.X != 0 && GameLoader.Y != 0)
        {
            transform.position = new Vector2(GameLoader.X, GameLoader.Y);
        }
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        heartCount = hearts.Length;
        StartCoroutine(WalkCoroutine());



    }

    void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGroud();
        Fire();

        if (heartCount == 0)
        {
            restartPanel.SetActive(true);
        }

        if (anim.GetBool("hagging_run") && moveVector.x == 0)
        {
            anim.SetBool("hagging_idle", true);
        }
        else
        {
            anim.SetBool("hagging_idle", false);
        }

        float verticalMove = joystick.Vertical;

        if (Input.GetKeyUp(KeyCode.DownArrow) || verticalMove <= 0.5f)
        {
            BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();
            Collider2D[] colls = new Collider2D[10];
            ContactFilter2D filter = new ContactFilter2D();


            int size = playerCollider.OverlapCollider(filter, colls);
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    if (colls[i].gameObject.name.Contains("verevka"))
                    {
                        colls[i].isTrigger = true;

                        anim.SetBool("hagging_idle", false);
                        anim.SetBool("hagging_run", true);



                    }
                }
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("verevka"))
        {
            anim.SetBool("hagging_run", false);
            anim.SetBool("hagging_idle", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("enemyBullet"))
        {
            hearts[heartCount - 1].gameObject.SetActive(false);
            heartCount--;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("verevka"))
        {
            anim.SetBool("hagging_run", true);
        }
    }


    public void FireJoistik()
    {
        Bullet b = GameObject.Instantiate<Bullet>(bullet, bullet.transform.position, bullet.transform.rotation);
        b.SetHorizontalDirection();
        b.gameObject.SetActive(true);
        b.move = true;
        GameObject.Destroy(b.gameObject, 3f);
        audioService.PlayShoot();
    }
    public void Fire()
    {


        if (Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.UpArrow))
        {

            Bullet b = GameObject.Instantiate<Bullet>(bullet, bullet.transform.position, bullet.transform.rotation);
            b.SetUpDirection();
            b.gameObject.SetActive(true);
            b.move = true;
            GameObject.Destroy(b.gameObject, 3f);
            audioService.PlayShoot();
        }
        else if (Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.DownArrow))
        {
            Bullet b = GameObject.Instantiate<Bullet>(bullet, bullet.transform.position, bullet.transform.rotation);
            b.SetDownDirection();
            b.gameObject.SetActive(true);
            b.move = true;
            GameObject.Destroy(b.gameObject, 3f);
            audioService.PlayShoot();
        }

        else if (Input.GetKeyDown(KeyCode.F))
        {
            Bullet b = GameObject.Instantiate<Bullet>(bullet, bullet.transform.position, bullet.transform.rotation);
            b.SetHorizontalDirection();
            b.gameObject.SetActive(true);
            b.move = true;
            GameObject.Destroy(b.gameObject, 3f);
            audioService.PlayShoot();
        }


    }


    void Walk()
    {
        moveVector.x = joystick.Horizontal;
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

    }

    IEnumerator WalkCoroutine()
    {
        int step = 0;
        while (true)
        {
            float x = joystick.Horizontal;
            if (x != 0)
            {
                if (step % 2 == 0)
                {
                    audioService.PlayStep1();
                }
                else
                {
                    audioService.PlayStep2();
                }
                step++;
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void Reflect()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("fire_up", true);
        }
        else
        {
            anim.SetBool("fire_up", false);
        }

        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            if (moveVector.x > 0) bullet.goToRight = true;
            if (moveVector.x < 0) bullet.goToRight = false;



            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }


    void Jump()
    {
        float verticalMove = joystick.Vertical;
        if (verticalMove >= 0.5f && onGround)
        {
            audioService.PlayJump();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


    void CheckingGroud()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        if (onGround)
        {

            anim.SetBool("onGround", onGround);
        }
    }
}
