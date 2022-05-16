using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWriter : MonoBehaviour
{
    //public GameObject gameManager;

    [System.Serializable]
    public class Player
    {
        public int totalClicks;
        public int actualClicks;
        public int firstLogin;
        public List<string> listaHuevos;
        public List<string> listaCriaturas;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public Player myPlayer = new Player();
    public PlayerList myPlayerList = new PlayerList();

    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(myPlayer);

        File.WriteAllText(Application.dataPath + "/Scripts/Data/DataFiles/text.txt", strOutput);

        string strOutput2 = JsonUtility.ToJson(myPlayerList);

        File.WriteAllText(Application.dataPath + "/Scripts/Data/DataFiles/text2.txt", strOutput2);
    }

    public void fillPlayer()
    {
        myPlayer.actualClicks = PlayerPrefs.GetInt("ClickCoins");
        myPlayer.totalClicks = PlayerPrefs.GetInt("totalClickCoins");
        myPlayer.firstLogin = PlayerPrefs.GetInt("firstLogin");
        myPlayer.listaHuevos = GlobalVars.listaHuevos;
        myPlayer.listaCriaturas = new List<string>();
    }

    private void OnApplicationQuit()
    {
        fillPlayer();
        outputJSON();
    }
}
