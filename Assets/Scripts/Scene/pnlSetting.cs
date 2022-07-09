using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pnlSetting : MonoBehaviour
{
    #region ----- VARIABLE -----
    [SerializeField] private GameObject _background;
    [SerializeField] private Toggle _tgMusic;
    [SerializeField] private Toggle _tgSound;
    [SerializeField] private Button _btnBack;

    #endregion

    #region ----- PRIVATE FUNCTION -----
    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _background.gameObject.SetActive(false);
        _tgMusic.isOn = DataManager.instance.playerData.music;
        _tgSound.isOn = DataManager.instance.playerData.sound;

        _tgMusic.onValueChanged.AddListener(delegate 
        {
            OnMusicToggleChange(_tgMusic);
        });

        _tgSound.onValueChanged.AddListener(delegate 
        {
            OnSoundToggleChange(_tgSound);
        });

        _btnBack.onClick.AddListener(OnButtonBackClick);

        MoveIn();
    }

    private void OnMusicToggleChange(Toggle value)
    {
        if(_tgMusic.isOn)
        {
            SoundManager.instance.PlayButtonClickSound();
            SoundManager.instance.StopMusic(false);
            DataManager.instance.playerData.music = true;
        }
        else
        {
            SoundManager.instance.StopMusic(true);
            DataManager.instance.playerData.music = false;
        }
        DataManager.instance.SaveData();
    }

    private void OnSoundToggleChange(Toggle value)
    {
        if(_tgSound.isOn)
        {
            SoundManager.instance.StopSound(false);
            SoundManager.instance.PlayButtonClickSound();
            DataManager.instance.playerData.sound = true;
        }
        else
        {
            SoundManager.instance.StopSound(true);
            DataManager.instance.playerData.sound = false;
        }
        DataManager.instance.SaveData();
    }

    private void OnButtonBackClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        MoveOut();
    }

    private void OnDisable()
    {
        _btnBack.onClick.RemoveAllListeners();
        _tgMusic.onValueChanged.RemoveAllListeners();
        _tgSound.onValueChanged.RemoveAllListeners();
    }

    #endregion

    #region ---- PUBLIC FUNCTION -----


    #endregion

    #region ----- AINMATION -----
    private void MoveIn()
    {
        _background.transform.localScale = Vector3.zero;
        _background.SetActive(true);
        _background.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.Linear);
    }

    private void MoveOut()
    {
        _background.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _background.SetActive(true);
            pnlManager.instance.MainMenu();
        });
    }

    #endregion
}
