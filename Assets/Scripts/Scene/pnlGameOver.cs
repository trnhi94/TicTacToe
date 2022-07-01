using DG.Tweening;
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
        Init();
    }

    private void Init()
    {
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;
        _board.SetActive(false);
        _btnPlayAgain.onClick.AddListener(OnButtonPlayAgainClick);
        if(GameController.instance.isRaw)
        {
            SetGameOverText("RAW!");
        }
        else
        {
            SetGameOverText(DataManager.instance.playerData.playerSide + " is a Winner!");
        }
        MoveIn();
    }
    private void OnButtonPlayAgainClick()
    {
        GameController.instance.PlayAgain();
    }

    private void OnDisable()
    {
        
    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----
    public void SetGameOverText(string value)
    {
        _txtTitle.text = value;
    }


    #endregion

    #region ----- ANIMATION -----

    private void MoveIn()
    {
        _board.transform.localScale = Vector3.zero;
        _board.SetActive(true);
        _board.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
    }

    private void MoveOut()
    {

    }

    #endregion
}
