using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;

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

    public Player player = new Player();
    public PlayerList myPlayerList = new PlayerList();
    //public GlobalVars globalVars = new GlobalVars();



    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(textJSON.text);
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
        player = JsonUtility.FromJson<Player>(textJSON.text);
        //globalVars = JsonUtility.FromJson<GlobalVars>(textJSON.text);
        GlobalVars.listaHuevos = player.listaHuevos;
        GlobalVars.listaCriaturas = player.listaCriaturas;
        //GameManager.player = globalVars;
        //Debug.Log(GlobalVars.listaHuevos.Count);
        Debug.Log("/////////////////////////////////////");
        //Debug.Log(player.listaHuevos[1]);
    }

    public void Reader()
    {
        
    }
}
