using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pnlGameScene : MonoBehaviour
{
    #region ----- VARIABLE -----
    [SerializeField] private List<TextMeshProUGUI> _lstText;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _pnlBoard;
    [SerializeField] private TextMeshProUGUI _txtTitle;
    [SerializeField] private Button _btnMenu;
    [SerializeField] private GameObject _playerX;
    [SerializeField] private GameObject _playerO;
    private PlayerData _playerData => DataManager.instance.playerData;

    private float width;
    private float height;

    #endregion

    #region ----- PRIVATE FUNCTIONS -----

    private void OnEnable()
    {
    }

    private void InitMultiPlayerMode()
    {
        width = _background.GetComponent<RectTransform>().rect.width;
        height = _background.GetComponent<RectTransform>().rect.height;
        _playerData.ResetPlayerData();
        _btnMenu.onClick.AddListener(OnButtonMenuOnClick);
        _lstText ??= new List<TextMeshProUGUI>();
        for (int i = 0; i < _lstText.Count; i++)
        {
            if(_lstText[i].text != "")
            {
                _lstText[i].text = "";
                _lstText[i].transform.parent.GetComponent<GirdSpace>().ResetState();
            }
            _playerData.lstTextPlayerContent.Add(_lstText[i].text);
        }
        DataManager.instance.SaveData();
    }

    private void InitSingleMode()
    {
        _btnMenu.onClick.AddListener(OnButtonMenuOnClick);
    }

    private void OnButtonMenuOnClick()
    {
        pnlManager.instance.MainMenu();
    }

    private void OnDisable()
    {
        SoundManager.instance.PlayButtonClickSound();
        _btnMenu.onClick.RemoveAllListeners();
    }
    #endregion

    #region ----- PUBLIC FUNCTIONS -----

    public void StartNewGame()
    {
        MoveIn();
        if(GameController.instance.ePlayMode == EPlayMode.single)
        {
            InitSingleMode();
        }
        else
        {
            InitMultiPlayerMode();
        }
    }

    public void ResetBoardGame()
    {
        _pnlBoard.gameObject.SetActive(true);
        _btnMenu.gameObject.SetActive(true);
        _playerX.SetActive(true);
        _playerO.SetActive(true);
    }

    #endregion.

    #region ----- ANIMATION -----
    private void MoveIn()
    {
        _pnlBoard.gameObject.SetActive(false);
        _btnMenu.gameObject.SetActive(false);
        _playerX.SetActive(false);
        _playerO.SetActive(false);
        _txtTitle.transform.localScale = Vector3.zero;
        _txtTitle.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            _pnlBoard.transform.localScale = Vector3.zero;
            _pnlBoard.gameObject.SetActive(true);
            _pnlBoard.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);

            _playerX.transform.localScale = Vector3.zero;
            _playerX.SetActive(true);
            _playerX.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);

            _playerO.transform.localScale = Vector3.zero;
            _playerO.SetActive(true);
            _playerO.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);

            _btnMenu.transform.localScale = Vector3.zero;
            _btnMenu.gameObject.SetActive(true);
            _btnMenu.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
        });
    }

    #endregion
}
