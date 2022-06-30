using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region ----- VARIABLE -----
    public static GameController instance;
    private PlayerData _playerData => DataManager.instance.playerData;
    private List<string> _lstText => GameCache.instance.lstTextPlayerContent;
    // GAME PLAY

    private string playerSide;
    private int moveCount;

    #endregion

    #region ----- PRIVATE FUNCTIONS -----

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Init();
    }
    
    private void Init()
    {
        moveCount = 0;
        playerSide = "X";
        _playerData.playerSide = playerSide;
        _playerData.moveCount = moveCount;
        DataManager.instance.SaveData();
    }

    private void GameOver()
    {
        pnlManager.instance.GameOver();
        
        //_pnlGameOver.transform.position -= height * Vector3.up;
        //_pnlGameOver.SetActive(true);
        //_gameOverBoard.SetActive(false);
        //_pnlGameOver.transform.DOLocalMoveY(0f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    _gameOverBoard.transform.localScale = Vector3.zero;
        //    _gameOverBoard.SetActive(true);
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //    
        //});
    }

    public void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        pnlGameScene.instance.SetPlayerColors(playerSide);
        _playerData.playerSide = playerSide;
        DataManager.instance.SaveData();
    }

   

    private void OnDisable()
    {
        //_btnMenu.onClick.RemoveAllListeners();

        //_btnNewGame.onClick.RemoveAllListeners();
        //_btnMultiplayer.onClick.RemoveAllListeners();
        //_btnSetting.onClick.RemoveAllListeners();

        //_btnPlayAgain.onClick.RemoveAllListeners();
    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;
        _playerData.moveCount = moveCount;

        if (_lstText[0] == playerSide && _lstText[1] == playerSide && _lstText[2] == playerSide)
        {
            GameOver();
        }
        //    else if (_txtList[3].text == playerSide && _txtList[4].text == playerSide && _txtList[5].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (_txtList[6].text == playerSide && _txtList[7].text == playerSide && _txtList[8].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (_txtList[0].text == playerSide && _txtList[3].text == playerSide && _txtList[6].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (_txtList[1].text == playerSide && _txtList[4].text == playerSide && _txtList[7].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (_txtList[2].text == playerSide && _txtList[5].text == playerSide && _txtList[8].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (_txtList[3].text == playerSide && _txtList[6].text == playerSide && _txtList[9].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (_txtList[0].text == playerSide && _txtList[4].text == playerSide && _txtList[8].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (_txtList[2].text == playerSide && _txtList[4].text == playerSide && _txtList[6].text == playerSide)
        //    {
        //        GameOver();
        //    }
        //    else if (moveCount >= 9)
        //    {
        //        GameOver();
        //    }
        //    else
        //    {
        
    //    }
    }

    public void PlayAgain()
    {
        moveCount = 0;
        //foreach (var item in _txtList)
        //{
        //    item.text = "";
        //    item.GetComponentInParent<Button>().interactable = true;
        //}
        //SetPlayerColors(_playerX, _playerO);
    }

    #endregion
}
