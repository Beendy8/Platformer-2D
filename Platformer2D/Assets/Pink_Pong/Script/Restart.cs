using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject leftSquare;
    [SerializeField] GameObject rightSquare;
    

    
    void Start()
    {
        StartCoroutine(CreateSquares());
    }

    
    void Update()
    {
        
    }

    IEnumerator CreateSquares()
    {
        int counter = 0;
        while (true)
        {
            GameObject clone;
            if (counter % 2 == 0)
            {
                clone = Instantiate(leftSquare, leftSquare.transform.position, Quaternion.identity);
            }
            else
            {
                clone = Instantiate(rightSquare, rightSquare.transform.position, Quaternion.identity);
            }
            clone.SetActive(true);
            counter++;
            yield return new WaitForSeconds(1);
        }
    }

  


    public void Active()
    {
        button.SetActive(true);
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    
}
