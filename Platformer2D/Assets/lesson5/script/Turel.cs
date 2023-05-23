using Assets.lesson5;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turel : MonoBehaviour
{

    [SerializeField] LayerMask playerMask;
    [SerializeField] Bullet bullet;
    [SerializeField] TurrelExplosion turrelExplosion;
    public LayerMask playerBulletMask;
    public GameObject Boom;
    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    float checkRadius = 0.3f;
    int rayLength = 10;
    bool canShoot = true;
    Animator anim;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2[] rayVectors = { Vector2.left, new Vector2(-1, 1), Vector2.up, new Vector2(1, 1), Vector2.right, new Vector2(1, -1), Vector2.down, new Vector2(-1, -1) };
        if (canShoot)
        {
            for (int i = 0; i < rayVectors.Length; i++)
            {

                Vector2 rayVector = rayVectors[i];
                RaycastHit2D hit = Physics2D.Raycast(transform.position, rayVector, rayLength, playerMask);
                Debug.DrawRay(transform.position, rayVector * rayLength, Color.red, 0.2f);

                if (hit.collider != null)
                {

                    spriteRenderer.sprite = sprites[i];
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("playerBullet"))
        {
            turrelExplosion.MakeExplosion();
            Instantiate(Boom, transform.position, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
        }

    }

    IEnumerator CoolDown()
    {
        int timer = 2;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);

        }
        canShoot = true; 
    }
    
}
