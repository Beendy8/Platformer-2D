using Assets.lesson5;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] Bullet bullet;
    int rayLength = 10;
    Rigidbody2D rb;
    public float speed = 2f;
    public GameObject Die;
    
    float checkRadius = 0.3f;
    public LayerMask playerBulletMask;
    bool canShoot = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Turn()
    {
        if (detectedPlayer != null)
        {
            if (detectedPlayer.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    GameObject detectedPlayer;
    void Move()
    {
        if (detectedPlayer != null)
        {
            if (detectedPlayer.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector3(-1, rb.velocity.y, 0);

            }

            else
            {
                rb.velocity = new Vector3(1, rb.velocity.y, 0);
            }
        }
    }
    
    void Update()
    {
        Vector2[] rayVectors = { Vector2.left, new Vector2(-1,1), Vector2.up, new Vector2(1, 1), Vector2.right };
        Move();
        Turn();
        if (canShoot)
        {
            foreach (Vector2 rayVector in rayVectors)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, rayVector, rayLength, playerMask);
                Debug.DrawRay(transform.position, rayVector * rayLength, Color.red, 0.2f);
                
                
                if (hit.collider != null )
                {
                    if (detectedPlayer == null)
                    {
                        detectedPlayer = hit.collider.gameObject;
                    }
                    
                    
                    Bullet b = GameObject.Instantiate<Bullet>(bullet, bullet.transform.position, bullet.transform.rotation);
                    Vector3 playerPosition = hit.collider.transform.position;
                    Vector2 bulletVelocity = playerPosition - b.transform.position;
                    bulletVelocity = bulletVelocity.normalized;

                    b.SetBulletVelocity(bulletVelocity);

                    b.gameObject.SetActive(true);
                    b.move = true;
                    GameObject.Destroy(b.gameObject, 3f); 
                    canShoot = false;  
                    StartCoroutine(CoolDown()); 
                    
                }
            }
        }


        Collider2D bulletCollider = Physics2D.OverlapCircle(this.gameObject.transform.position, checkRadius, playerBulletMask);
        if (bulletCollider)
        {
            DieAnimation();
            GameObject bullet = bulletCollider.gameObject; 
            GameObject.Destroy(this.gameObject); 
            GameObject.Destroy(bullet); 
        }
    }

    public void DieAnimation()
    {
        Instantiate(Die, transform.position, Quaternion.identity);
    }

    IEnumerator CoolDown()
    {
        int timer = 2;
        while(timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);

        }
        canShoot = true; 
    }
}
