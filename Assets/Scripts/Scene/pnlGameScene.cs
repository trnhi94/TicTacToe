using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pnlGameScene : MonoBehaviour
{
    #region ----- VARIABLE -----

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _pnlBoard;
    [SerializeField] private TextMeshProUGUI _txtTitle;
    [SerializeField] private Button _btnMenu;
    [SerializeField] private Player _playerX;
    [SerializeField] private Player _playerO;
    [SerializeField] private PlayerColor _activePlayerColor;
    [SerializeField] private PlayerColor _inactivePlayerColor;

    private float width;
    private float height;

    #endregion

    #region ----- PRIVATE FUNCTIONS -----

    private void OnEnable()
    {
        width = _background.GetComponent<RectTransform>().rect.width;
        height = _background.GetComponent<RectTransform>().rect.height;
        _pnlBoard.gameObject.SetActive(false);
        _btnMenu.gameObject.SetActive(false);
        _btnMenu.onClick.AddListener(OnButtonMenuOnClick);
        MoveIn();
    }

    private void OnButtonMenuOnClick()
    {
        pnlManager.instance.MainMenu();
    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----



    #endregion.

    #region ----- ANIMATION -----
    private void MoveIn()
    {
        _txtTitle.transform.position += height * Vector3.up;
        _txtTitle.transform.DOLocalMoveY(1040, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _pnlBoard.gameObject.SetActive(true);
            _pnlBoard.transform.localScale = Vector3.zero;
            _pnlBoard.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);

            _playerX.imgPlayer.transform.position -= width * Vector3.right;
            _playerX.imgPlayer.transform.DOLocalMove(new Vector3(-450f, 1040f), 1f).SetEase(Ease.Linear);

            _playerO.imgPlayer.transform.position += width * Vector3.right;
            _playerO.imgPlayer.transform.DOLocalMove(new Vector3(450f, 1040f), 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                SetPlayerColors(_playerX, _playerO);
            });

            _btnMenu.transform.position += width * Vector3.right;
            _btnMenu.gameObject.SetActive(true);
            _btnMenu.transform.DOLocalMove(new Vector3(740f, 1500f), 1f).SetEase(Ease.Linear);
        });
    }

    private void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.imgPlayer.color = _activePlayerColor.imgColor;
        oldPlayer.imgPlayer.color = _inactivePlayerColor.imgColor;
    }

    #endregion
}
