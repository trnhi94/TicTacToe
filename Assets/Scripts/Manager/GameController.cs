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
    [SerializeField] private TextMeshProUGUI[] _txtList;

    // GAME PLAY

    private string playerSide;
    private int moveCount;
    private float width;
    private float height;

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
        //_pnlGameOver.SetActive(false);
        

        moveCount = 0;
        playerSide = "X";
        
        _btnPlayAgain.onClick.AddListener(ButtonPlayAgainOnClick);
        
    }
    
    

    private void ButtonPlayAgainOnClick()
    {
    //    moveCount = 0;
    //    foreach (var item in _txtList)
    //    {
    //        item.text = "";
    //        item.GetComponentInParent<Button>().interactable = true;
    //    }
    //    //_pnlGameOver.SetActive(false);
    //    SetPlayerColors(_playerX, _playerO);
    }


    

    private void GameOver()
    {
        //foreach (var item in _txtList)
        //{
        //    item.GetComponentInParent<Button>().interactable = false;
        //}
        //_pnlGameOver.transform.position -= height * Vector3.up;
        //_pnlGameOver.SetActive(true);
        //_gameOverBoard.SetActive(false);
        //_pnlGameOver.transform.DOLocalMoveY(0f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    _gameOverBoard.transform.localScale = Vector3.zero;
        //    _gameOverBoard.SetActive(true);
        //    if(moveCount >= 9)
        //    {
        //        SetGameOverText("RAW!");
        //    }
        //    else
        //    {
        //        if (playerSide == "O")
        //        {
        //            SetGameOverText("Player 1 is a Winner!");
        //        }
        //        else
        //        {
        //            SetGameOverText("Player 2 is a Winner!");
        //        }
        //    }
        //    _gameOverBoard.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
        //});
    }

    private void ChangeSides()
    {
        //playerSide = (playerSide == "X") ? "O" : "X";
        //if(playerSide == "X")
        //{
        //    SetPlayerColors(_playerX, _playerO);
        //}
        //else
        //{
        //    SetPlayerColors(_playerO, _playerX);
        //}
    }

    private void SetGameOverText(string value)
    {
        _txtGameOverTitle.text = value;
    }

    private void OnDisable()
    {
        //_btnMenu.onClick.RemoveAllListeners();

        //_btnNewGame.onClick.RemoveAllListeners();
        //_btnMultiplayer.onClick.RemoveAllListeners();
        //_btnSetting.onClick.RemoveAllListeners();

        _btnPlayAgain.onClick.RemoveAllListeners();
    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----

    public string GetPlayerSide()
    {
        return playerSide;
    }

    //public void EndTurn()
    //{
    //    moveCount++;
    //    if (_txtList[0].text == playerSide && _txtList[1].text == playerSide && _txtList[2].text == playerSide)
    //    {
    //        GameOver();
    //    }
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
    //        ChangeSides();
    //    }
    //}

    #endregion
}
