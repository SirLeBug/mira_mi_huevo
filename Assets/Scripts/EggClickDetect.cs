using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggClickDetect : MonoBehaviour
{
    private int clickCoins = 0;
    public TextMeshProUGUI txt_clickcoins;
    public Animator anim;
    public AudioClip clickClip;
    public AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //Recupera los ClickCoins que tiene el usuario para mostrarlos y partir de ahi en el contador al iniciar el juego
        clickCoins = PlayerPrefs.GetInt("ClickCoins");
        txt_clickcoins.text = clickCoins.ToString() + " ClickCoins";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Clicked(); 
                
            }
        }
    }

    //Al clickar el ratón encima del huevo
    private void Clicked()
    {
        //Acciona el trigger para la animación del huevo siendo clickado (work in progress)
        //anim.SetTrigger("Clicked");
        anim.Play("clickHuevo", -1, 0f);

        //Ejecuta el sonido al hacer click+
        //clickSound.Play();
        clickSound.PlayOneShot(clickClip);

        //Incrementa en 1 y guarda esta información para a su vez actualizarla en pantalla
        clickCoins++;
        PlayerPrefs.SetInt("ClickCoins", clickCoins);
        txt_clickcoins.text = clickCoins.ToString() + " ClickCoins";
        Debug.Log(this.gameObject.name);

        //subimos el valor de las clickcoins totales a 1 más (estadísticas)
        PlayerPrefs.SetInt("totalClickCoins", PlayerPrefs.GetInt("totalClickCoins") + 1);
    }
}
