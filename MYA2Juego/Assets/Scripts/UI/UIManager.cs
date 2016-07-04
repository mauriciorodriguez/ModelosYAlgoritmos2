using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public Text youWinText, tieText, youLoseText, restartText, scoreText;

    public void GameOver(string s)
    {
        switch (s)
        {
            case K.FACADE_MSG_WIN:
                {
                    youWinText.gameObject.SetActive(true);

                }
                break;
            case K.FACADE_MSG_TIE:
                {
                    tieText.gameObject.SetActive(true);
                }
                break;
            case K.FACADE_MSG_LOSE:
                {
                    youLoseText.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
        if (s != K.FACADE_MSG_CONTROL)
        {
            restartText.gameObject.SetActive(true);
        }
    }    
}
