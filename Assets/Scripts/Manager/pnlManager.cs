using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnlManager : MonoBehaviour
{
    #region ----- VARIABLE -----

    public static pnlManager instance;
    //SCENE mANAGER
    [SerializeField] private pnlMainMenu _pnlMainMenu;
    [SerializeField] private pnlGameScene _pnlGameScene;
    [SerializeField] private pnlGameOver _pnlGameOver;
    [SerializeField] private pnlSetting _pnlSetting;

    #endregion

    #region ----- PRIVATE FUNCTION -----
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

    private void OnEnable()
    {
        MainMenu();
    }

    private void Hide()
    {
        _pnlMainMenu.gameObject.SetActive(false);
        _pnlGameScene.gameObject.SetActive(false);
        _pnlGameOver.gameObject.SetActive(false);
        _pnlSetting.gameObject.SetActive(false);
    }

    private void OnDisable()
    {

    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----

    public void MainMenu()
    {
        Hide();
        _pnlMainMenu.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        Hide();
        _pnlGameScene.StartNewGame();
        _pnlGameScene.gameObject.SetActive(true);
    }

    public void Setting()
    {
        Hide();
        _pnlSetting.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        Hide();
        _pnlGameScene.gameObject.SetActive(true);
        _pnlGameScene.ResetBoardGame();
    }

    public void GameOver()
    {
        Hide();
        _pnlGameOver.gameObject.SetActive(true);
    }

    #endregion
}
