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
        _pnlGameScene.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        Hide();
        _pnlGameOver.gameObject.SetActive(true);
    }

    #endregion
}
