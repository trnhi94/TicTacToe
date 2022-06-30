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
    public PlayerData()
    {
        lstTextPlayerContent = new List<string>();
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