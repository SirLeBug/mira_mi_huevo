using Newtonsoft.Json.Linq;
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

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(textJSON.text);
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
        player = JsonUtility.FromJson<Player>(textJSON.text);
        GameManager.player.listaHuevos = player.listaHuevos;
        GameManager.player.listaCriaturas = player.listaCriaturas;
        //Debug.Log(player.totalClicks);
    }
}
