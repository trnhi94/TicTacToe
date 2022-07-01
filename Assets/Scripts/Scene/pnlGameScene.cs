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
        Init();
    }

    private void Init()
    {
        _playerData.ResetPlayerData();
        width = _background.GetComponent<RectTransform>().rect.width;
        height = _background.GetComponent<RectTransform>().rect.height;
        _pnlBoard.gameObject.SetActive(false);
        _btnMenu.gameObject.SetActive(false);
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

    private void OnButtonMenuOnClick()
    {
        pnlManager.instance.GameOver();
        //pnlManager.instance.MainMenu();
    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----

    public void StartNewGame()
    {
        MoveIn();
    }

    public void ResetBoardGame()
    {
        _pnlBoard.gameObject.SetActive(true);
    }

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

            _playerX.transform.position -= width * Vector3.right;
            _playerX.transform.DOLocalMove(new Vector3(-450f, 1040f), 1f).SetEase(Ease.Linear);

            _playerO.transform.position += width * Vector3.right;
            _playerO.transform.DOLocalMove(new Vector3(450f, 1040f), 1f).SetEase(Ease.Linear);

            _btnMenu.transform.position += width * Vector3.right;
            _btnMenu.gameObject.SetActive(true);
            _btnMenu.transform.DOLocalMove(new Vector3(740f, 1500f), 1f).SetEase(Ease.Linear);
        });
    }

    #endregion
}
