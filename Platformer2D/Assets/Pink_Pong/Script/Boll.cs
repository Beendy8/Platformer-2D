using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boll : MonoBehaviour
{
    [SerializeField] Restart restarn;
    [SerializeField] ShakeCamera shake;
    [SerializeField] GameObject center;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] GameObject gameover;

    public ClickScript[] controler;

    void Start()
    {
        
    }

    void Update()
    {
        
        if (controler[0].clickedIS == true)
        {
            transform.RotateAround(center.transform.position, Vector3.forward, -speed * Time.deltaTime);
        }
        else if (controler[1].clickedIS == true)
        {
            transform.RotateAround(center.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shake.Shake();

        int health = int.Parse(lives.text);
        health--;
        if (health == 0)
        {
            gameover.SetActive(true);
            restarn.Active();
        }
        lives.text = health.ToString();
        
        Destroy(collision.gameObject, 0.5f); //это надо сделать через 0.5 секунды

    }
}
