using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public void Interact()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }
}
