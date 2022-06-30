using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pnlGameOver : MonoBehaviour
{
    #region ----- VARIABLE -----

    [SerializeField] private GameObject _board;
    [SerializeField] private TextMeshProUGUI _txtTitle;
    [SerializeField] private Button _btnPlayAgain;
    private float width;
    private float height;
    #endregion

    #region ----- PRIVATE FUNCTIONS -----

    private void OnEnable()
    {
        width = GetComponent<RectTransform>()
    }

    private void OnButtonPlayAgainClick()
    {
        
    }

    private void OnDisable()
    {
        
    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----



    #endregion

    #region ----- ANIMATION -----

    private void MoveIn()
    {
        _pnlGameOver.transform.position -= height * Vector3.up;
        _pnlGameOver.SetActive(true);
        _gameOverBoard.SetActive(false);
        _pnlGameOver.transform.DOLocalMoveY(0f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _gameOverBoard.transform.localScale = Vector3.zero;
            _gameOverBoard.SetActive(true);
            if (moveCount >= 9)
            {
                SetGameOverText("RAW!");
            }
            else
            {
                if (playerSide == "O")
                {
                    SetGameOverText("Player 1 is a Winner!");
                }
                else
                {
                    SetGameOverText("Player 2 is a Winner!");
                }
            }
            _gameOverBoard.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
        });
    }

    private void MoveOut()
    {

    }

    #endregion
}
