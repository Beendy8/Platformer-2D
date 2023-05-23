using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerPlayer : TicTacPlayer
{

    
    public override void MakeStep()
    {
        StartCoroutine(Step());
    }

  
    IEnumerator Step()
    {
        while (true)
        {
            if (GameController.turn % 2 == 1 && GetEmptyCells()>0)
            {
                bool stop = false;
                int index = 0;
                while (!stop)
                {
                    index = Random.Range(0, gameField.Count);
                    if(gameField[index].text == "")
                    {
                        stop = true;
                    }
                }
                gameField[index].text = symbol;
                GameController.turn++;

            }
            yield return new WaitForSeconds(1);
        }
    }

    public int GetEmptyCells()
    {
        int count = 0;
        foreach(TextMeshProUGUI btn in gameField)
        {
            if(btn.text == "")
            {
                count++;
            }
        }
        return count;
    }
}
