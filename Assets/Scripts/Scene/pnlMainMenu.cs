using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pnlMainMenu : MonoBehaviour
{
    #region ----- VARIABLE -----
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _txtTitle;
    [SerializeField] private GameObject _pnlOptionBoard;
    [SerializeField] private Button _btnSingle;
    [SerializeField] private Button _btnMultiplayer;
    [SerializeField] private Button _btnSetting;
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
        pnlManager.instance.IgnoreCast(true);
        _btnSingle.onClick.AddListener(OnButtonSigleClick);
        _btnMultiplayer.onClick.AddListener(OnButtonMultiplayerClick);
        _btnSetting.onClick.AddListener(OnButtonSettingClick);

        width = _background.GetComponent<RectTransform>().rect.width;
        height = _background.GetComponent<RectTransform>().rect.height;

        for (int i = 0; i < _pnlOptionBoard.transform.childCount; i++)
        {
            _pnlOptionBoard.transform.GetChild(i).gameObject.SetActive(false);
            _pnlOptionBoard.transform.GetChild(i).transform.localScale = Vector3.zero;
        }
        MoveIn();
    }

    private void OnButtonSigleClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        GameController.instance.ePlayMode = EPlayMode.single;
        pnlManager.instance.StartGame();
    }

    private void OnButtonMultiplayerClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        GameController.instance.ePlayMode = EPlayMode.multi;
        pnlManager.instance.StartGame();
    }

    private void OnButtonSettingClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        pnlManager.instance.Setting();
    }

    private void OnDisable()
    {
        _btnSingle.onClick.RemoveAllListeners();
        _btnMultiplayer.onClick.RemoveAllListeners();
        _btnSetting.onClick.RemoveAllListeners();
        StopAllCoroutines();
    }
    #endregion

    #region ----- ANIMATION -----

    private void MoveIn()
    {
        _txtTitle.transform.position += height * Vector3.up;
        _txtTitle.transform.DOLocalMoveY(500f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            StartCoroutine(IEMoveIn());
        });
    }

    private IEnumerator IEMoveIn()
    {
        for (int i = 0; i < _pnlOptionBoard.transform.childCount; i++)
        {
            _pnlOptionBoard.transform.GetChild(i).gameObject.SetActive(true);
            _pnlOptionBoard.transform.GetChild(i).transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        pnlManager.instance.IgnoreCast(false);
    }

    private void MoveOut()
    {

    }

    #endregion

    #region ----- PUBLIC FUNCTIONS -----



    #endregion
}
