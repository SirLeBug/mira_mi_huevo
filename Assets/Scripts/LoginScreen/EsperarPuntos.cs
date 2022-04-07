using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EsperarPuntos : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private IEnumerator Start()
    {
        //void Start: dentro de la coroutina, la aprobecho para lanzar código que por defecto se pondría en void Start, pero no puedes tener esa función + la coroutina


        //Coroutine para augmentar los segundos mientras estas jugando
        while (true)
        {
            yield return new WaitForSeconds(1f);
            puntitocode();
        }
    }

    void puntitocode()
    {
        if(txt.text == "Esperando confirmación...")
        {
            txt.text = "Esperando confirmación";
        } else
        {
            txt.text = txt.text + ".";
        }
        
    }
}
