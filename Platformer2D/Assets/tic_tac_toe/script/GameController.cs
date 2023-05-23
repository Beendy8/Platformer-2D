using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public List<TextMeshProUGUI> gameField;
    [SerializeField]
    TicTacPlayer player1;
    [SerializeField]
    TicTacPlayer player2;
    public static int row=-1;
    public static int col;

    public static int turn = 0; //очередность хода
    

    void Start()
    {
        player1.SetGameField(gameField);
        player2.SetGameField(gameField);
        player1.MakeStep();
        player2.MakeStep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

   
}
