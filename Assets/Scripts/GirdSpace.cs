using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GirdSpace : MonoBehaviour
{
    [SerializeField] private Button _btnGirdSpace;
    [SerializeField] private TextMeshProUGUI _txtPlayer;

    private void Awake()
    {
        _btnGirdSpace.onClick.AddListener(SetSpace);
    }

    private void SetSpace()
    {
        _txtPlayer.text = GameController.instance.GetPlayerSide();
        _btnGirdSpace.interactable = false;
        //GameController.instance.EndTurn();
    }

    private void OnDisable()
    {
        _btnGirdSpace.onClick.RemoveAllListeners();
    }
}
