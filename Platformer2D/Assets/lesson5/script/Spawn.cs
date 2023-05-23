using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Enemy sourceEnemy;
    [SerializeField] Hero hero;
    public GameObject Portal;
    public LayerMask playerBulletMask;
    int distance = 10;
    bool canSpawn;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        Vector3 range = hero.transform.position - transform.position;
        if(range.magnitude <= distance)
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("playerBullet"))
        {
            Instantiate(Portal, transform.position, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
        }

    }


    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            if (canSpawn)
            {
                Enemy b = GameObject.Instantiate<Enemy>(sourceEnemy, sourceEnemy.transform.position, sourceEnemy.transform.rotation);
                b.gameObject.SetActive(true);
            }

        }
    }
}
