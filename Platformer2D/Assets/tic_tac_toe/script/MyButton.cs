using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.tic_tac_toe.script
{
    class MyButton : MonoBehaviour
    {
        [SerializeField] int row;
        [SerializeField] int col;


        public void Click()
        {
            GameController.row = row;
            GameController.col = col;
        }
    }
}
