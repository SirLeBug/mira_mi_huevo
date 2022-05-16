using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    public void ReadStringInput(string s)
    {
        //Obtenemos el valor del input y lo guardamos en TempEmail para gastarlo luego para intentar hacer el login en la wallet
        input = s;
        Debug.Log(input);
        PlayerPrefs.SetString("TempEmail", input);
    } 
}
