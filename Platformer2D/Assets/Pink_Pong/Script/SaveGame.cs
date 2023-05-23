using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public const string fileName = "pingpong.dat";
    [SerializeField] TextMeshProUGUI point;
    [SerializeField] TextMeshProUGUI health;

    private void Awake()
    {
        Load();
    }

    void Start()
    {
        Debug.Log(Application.persistentDataPath+"/"+fileName);
        
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + fileName);
        sw.WriteLine(point.text);
        sw.WriteLine(health.text);
        sw.Close();
    }

    public void Load()
    {
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/" + fileName);
        point.text = sr.ReadLine();
        health.text = sr.ReadLine();
        sr.Close();
        int x = int.Parse(health.text);
        if (x <= 0)
        {
            x = 10;
            health.text = x.ToString();
            int y = int.Parse(point.text);
            y = 0;
            point.text = y.ToString();
        }

    }


    void Update()
    {
        
    }
}
