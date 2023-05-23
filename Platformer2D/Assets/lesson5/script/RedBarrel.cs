using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarrel : MonoBehaviour
{
    public GameObject Barrel;
    [SerializeField] BarrerExplosion barrerExplosion;
    float checkRadius = 0.3f;
    public LayerMask playerBulletMask;
   AudioService audioService;

    void Start()
    {
        audioService = FindObjectOfType<AudioService>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("playerBullet"))
        {
            barrerExplosion.MakeExplosion();
            Instantiate(Barrel, transform.position, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            audioService.PlayBarrelBomb();
        }

    }

}
