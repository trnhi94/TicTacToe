using System.Collections.Generic;
using UnityEngine;
public class GameCache : MonoBehaviour
{
    public static GameCache instance;
    public string playerSide
    {
        get;
        private set;
    }

    public List<string> lstTextPlayerContent => DataManager.instance.GetListTextPlayerContent();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}

