using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GirdSpace : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Button _btnGirdSpace;
    [SerializeField] private TextMeshProUGUI _txtPlayer;

    private void OnEnable()
    {
        _btnGirdSpace.onClick.AddListener(SetSpace);
    }

    private void SetSpace()
    {
        _txtPlayer.text = DataManager.instance.playerData.playerSide;
        if(_txtPlayer.text == "X")
        {
            _txtPlayer.color = Color.blue;
        }
        else
        {
            _txtPlayer.color = Color.red;
        }
        DataManager.instance.playerData.lstTextPlayerContent[id] = _txtPlayer.text;
        _btnGirdSpace.interactable = false;
        DataManager.instance.SaveData();
        GameController.instance.EndTurn();
    }

    private void OnDisable()
    {
        _btnGirdSpace.onClick.RemoveAllListeners();
    }

    public void ResetState()
    {
        //_btnGirdSpace.interactable = true;

    }
}
