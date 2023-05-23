using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public bool clickedIS = false;

    void OnMouseDown()
    {
        clickedIS = true;
    }
    void OnMouseUp()
    {
        clickedIS = false;
    }
}
