using Assets.lesson5;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootingStick : Joystick
{
    [SerializeField] public Bullet sfsdf;
    [SerializeField] public int bullet123;
    AudioService audioService;

    
    

    //public override void OnPointerDown(PointerEventData eventData)
    //{
    //    if (audioService == null)
    //    {
    //        audioService = FindObjectOfType<AudioService>();
    //    }
    //    Bullet b = GameObject.Instantiate<Bullet>(bullet, bullet.transform.position, bullet.transform.rotation);
    //    b.SetHorizontalDirection();
    //    b.gameObject.SetActive(true);
    //    b.move = true;
    //    GameObject.Destroy(b.gameObject, 3f); //объект пули уничтожится через 2 секунды после осздания
    //    audioService.PlayShoot();
    //}
}
