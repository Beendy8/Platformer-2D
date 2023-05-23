using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    public static string filePath = "C:/Users/user/AppData/LocalLow/DefaultCompany/My project/platformer.dat";


    static int levelNumber = 1;
    public static float X, Y;
    [SerializeField] GameObject levelChoiceObj;
    TextMeshProUGUI userDialogText;
    [SerializeField] TMP_InputField inputField;
  
    void Start()
    {
        Debug.Log(filePath);
        (float x, float y) = LoadSavedData();
        if(x != 0 && y != 0)
        {
            X = x;
            Y = y;
        }
    }

    
    public static (float x, float y) LoadSavedData()
    {
        try
        {
            StreamReader sr = new StreamReader(filePath);
            levelNumber = int.Parse(sr.ReadLine());
            float x = float.Parse(sr.ReadLine());
            float y = float.Parse(sr.ReadLine());
            sr.Close();
            return (x, y);
            Debug.Log("Loaded");
        }catch(Exception e)
        {
            Debug.Log(e.GetType()+": "+e.Message);
            return (0,0);
        }
    }

    public static void SaveGame(int levelNumber, Hero hero)
    {
        StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(levelNumber);
        sw.WriteLine(hero.gameObject.transform.position.x);
        sw.WriteLine(hero.gameObject.transform.position.y);
        sw.Close();
    }

    public void StartGame()
    {
        if (levelChoiceObj.activeSelf)
        {
            //https://stackoverflow.com/
            
            string str = inputField.text;
            SceneManager.LoadScene(int.Parse(str));
        }
        else
        {
            if (levelNumber == 1)
            {
                SceneManager.LoadScene(levelNumber);
            }
            else
            {
                levelChoiceObj.SetActive(true);
                userDialogText = GameObject.Find("userDialogText").GetComponent<TextMeshProUGUI>();
                userDialogText.text = "Select level between 1 and " + levelNumber;
            }
        }
        
    }

    public void showLevelChoice()
    {
        
    }
}
