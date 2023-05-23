using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TicTacPlayer : MonoBehaviour
{
    [HideInInspector]
    public List<TextMeshProUGUI> gameField;
    [SerializeField]
    public string symbol;
    

    public void SetGameField(List<TextMeshProUGUI> gameField)
    {
        this.gameField = gameField;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void MakeStep()
    {

    }

    


}
