using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI lives;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int point = int.Parse(text.text);
        point++;
        if (point > 10)
        {
            int health = int.Parse(lives.text);
            health++;
            lives.text = health.ToString();
        }
        text.text = point.ToString();
    }

    void Update()
    {
        
    }
}
