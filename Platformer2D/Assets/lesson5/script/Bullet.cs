using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.lesson5
{
    public class Bullet : MonoBehaviour
    {
        public bool move;
        [HideInInspector] public bool goToRight=true;
        Vector2 bulletVelocity; 
        [SerializeField] int bulletSpeed=3;
        bool isEnemyShooting; 
        Rigidbody2D rb;
        Vector2 bulletDirection;
   
        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            
            StartCoroutine(MakeBulletVisible());
        }

        public void SetBulletVelocity(Vector2 velocity)
        {
            bulletVelocity = velocity;
            isEnemyShooting = true;
        }
        

        public void SetHorizontalDirection()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            bulletDirection = new Vector2(bulletSpeed, rb.velocity.y);
        }
        public void SetUpDirection()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            bulletDirection = new Vector2(0,bulletSpeed);
        }
        public void SetDownDirection()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            bulletDirection = new Vector2(0,-bulletSpeed);
        }

        private IEnumerator MakeBulletVisible()
        {
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().enabled = true;
        }


        private void Update()
        {
            
            if (isEnemyShooting)
            {
                
                rb.velocity = bulletVelocity * bulletSpeed;
            }
            else
            {
               

                if (goToRight)
                {


                    if (bulletDirection.x != 0)
                    {
                        bulletDirection.x = bulletSpeed;
                    }
                    
                }
                else
                {
                    if (bulletDirection.x != 0)
                    {
                        bulletDirection.x = -bulletSpeed;
                    }
                }
                
                rb.velocity = bulletDirection;
            }
        }
       
       


    }
}
