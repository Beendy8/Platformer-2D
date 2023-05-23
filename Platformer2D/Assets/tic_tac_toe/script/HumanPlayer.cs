using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HumanPlayer : TicTacPlayer
{
   
    public override void MakeStep()
    {
        StartCoroutine(Step());
        
    }

    IEnumerator Step()
    {
        while (true)
        {
            if(GameController.turn % 2 == 0 && GameController.row!=-1)
            {
                int index = GameController.row * 3 + GameController.col;
                gameField[index].text = symbol;
                GameController.turn++;
                GameController.row = -1;
               
            }
            yield return new WaitForSeconds(1);
        }
    }
}
