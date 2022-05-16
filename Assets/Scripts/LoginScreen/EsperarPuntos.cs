using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EsperarPuntos : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private IEnumerator Start()
    {
        //void Start: dentro de la coroutina, la aprobecho para lanzar c�digo que por defecto se pondr�a en void Start, pero no puedes tener esa funci�n + la coroutina


        //Coroutine para augmentar los segundos mientras estas jugando
        while (true)
        {
            yield return new WaitForSeconds(1f);
            puntitocode();
        }
    }

    //La funci�n a�ade puntos a la frase de "Esperando confirmaci�n" para dar la sensaci�n de carga
    void puntitocode()
    {
        if(txt.text == "Esperando confirmaci�n...")
        {
            txt.text = "Esperando confirmaci�n";
        } else
        {
            txt.text = txt.text + ".";
        }
        
    }
}
