using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

#region ----- CLASSES -----
[System.Serializable]
public class Player
{
    public Image imgPlayer;
}

[System.Serializable]
public class PlayerColor
{
    public Color imgColor;
}

public class PlayerData
{
    public List<string> lstTextPlayerContent;
    public string playerSide;
    public int moveCount;
    public bool music;
    public bool sound;

    public PlayerData()
    {
        lstTextPlayerContent = new List<string>();
        playerSide = "X";
        moveCount = 0;
        music = true;
        sound = true;
    }

    public void ResetPlayerData()
    {
        lstTextPlayerContent.Clear();
        moveCount = 0;
        playerSide = "X";
    }
}
#endregion

#region ----- ENUM -----
public enum PlayMode
{
    single = 1,
    multi = 2,
}
#endregion