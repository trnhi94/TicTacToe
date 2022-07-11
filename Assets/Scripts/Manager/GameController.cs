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
    public bool isRaw
    {
        get;
        private set;
    }
    // GAME PLAY
    private string playerSide;
    private int moveCount;
    [SerializeField] private Player _playerX;
    [SerializeField] private Player _playerO;
    [SerializeField] private PlayerColor _activePlayerColor;
    [SerializeField] private PlayerColor _inactivePlayerColor;

    public EPlayMode ePlayMode;

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
    }

    private void Start()
    {
        Init();
        InitAudio();
    }

    private void Init()
    {
        isRaw = false;
        moveCount = 0;
        playerSide = "X";
        SetPlayerColors(playerSide);
    }

    private void InitAudio()
    {
        SoundManager.instance.StopMusic(!_playerData.music);
        SoundManager.instance.StopSound(!_playerData.sound);
        DataManager.instance.SaveData();
    }

    private void GameOver()
    {
        pnlManager.instance.GameOver();
    }

    public void SetPlayerColors(string playerSide)
    {
        if (playerSide == "X")
        {
            _playerX.imgPlayer.color = _activePlayerColor.imgColor;
            _playerO.imgPlayer.color = _inactivePlayerColor.imgColor;
        }
        else
        {
            _playerX.imgPlayer.color = _inactivePlayerColor.imgColor;
            _playerO.imgPlayer.color = _activePlayerColor.imgColor;
        }

    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----

    public void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        SetPlayerColors(playerSide);
        _playerData.playerSide = playerSide;
        DataManager.instance.SaveData();
    }

    public void EndTurn()
    {
        moveCount++;
        _playerData.moveCount = moveCount;
        
        if ((_lstText[0] == playerSide && _lstText[1] == playerSide && _lstText[2] == playerSide) ||
            (_lstText[3] == playerSide && _lstText[4] == playerSide && _lstText[5] == playerSide) ||
            (_lstText[6] == playerSide && _lstText[7] == playerSide && _lstText[8] == playerSide) ||
            (_lstText[0] == playerSide && _lstText[3] == playerSide && _lstText[6] == playerSide) ||
            (_lstText[1] == playerSide && _lstText[4] == playerSide && _lstText[7] == playerSide) ||
            (_lstText[2] == playerSide && _lstText[5] == playerSide && _lstText[8] == playerSide) ||
            (_lstText[0] == playerSide && _lstText[4] == playerSide && _lstText[8] == playerSide) ||                                               
            (_lstText[2] == playerSide && _lstText[4] == playerSide && _lstText[6] == playerSide))
        {
            GameOver();
            return;
        }
        else if (moveCount >= 9)
        {
            isRaw = true;
            GameOver();
        }
        else
        {
            ChangeSides();
        }
    }

    public string Raw()
    {
        return "RAW!";
    }

    public void PlayAgain()
    {
        pnlManager.instance.PlayAgain();
        Init();
    }

    #endregion
}
