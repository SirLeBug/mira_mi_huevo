using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public List<string> listaHuevos = new List<string>();
    public int testint;

    public PlayerData(GlobalVars player)
    {
        listaHuevos = player.listaHuevos;
        //testint = player.test;
    }
}
