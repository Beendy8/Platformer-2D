using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelExplosion : MonoBehaviour
{
    [SerializeField] CircleCollider2D circleCollider2D;

    public void MakeExplosion()
    {

        Collider2D[] arr = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        int size = circleCollider2D.OverlapCollider(filter, arr);
        for (int i = 0; i < size; i++)
        {
            if (arr[i].gameObject.name.Contains("Enemy"))
            {
                Enemy enemy = arr[i].gameObject.GetComponent<Enemy>();
                enemy.DieAnimation();
                Destroy(arr[i].gameObject);
            }
            else if (arr[i].gameObject.name.Contains("Hero"))
            {
                Hero hero = arr[i].gameObject.GetComponent<Hero>();
                Destroy(arr[i].gameObject);
            }

        }
    }
}
