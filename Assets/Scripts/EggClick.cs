using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EggClick : MonoBehaviour
{
    private int clickCoins = 0;
    public TextMeshProUGUI txt_clickcoins;
    public Animator anim;
    public AudioClip clickClip;
    public AudioSource clickSound;

    [Header("Variables para comprobar overlaping")]
    public GameObject menu_stats;
    public GameObject menu_options;
    public GameObject menu_info;
    public GameObject menu_market;

    [Header("Imagen del huevo")]
    public SpriteRenderer imgHuevo;
    public Sprite HuevoComun;
    public Sprite HuevoRaro;
    public Sprite HuevoMitico;
    public Sprite HuevoLegendario;

    public List<string> imgList;
    private int eggOpenning = 0;
    private string[] imgArr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //Recupera los ClickCoins que tiene el usuario para mostrarlos y partir de ahi en el contador al iniciar el juego
        clickCoins = PlayerPrefs.GetInt("ClickCoins");
        txt_clickcoins.text = clickCoins.ToString() + " ClickCoins";
        imgList = GameManager.player.listaHuevos;
        imgArr = imgList.ToArray();
        //Debug.Log(imgArr[1]);
    }

    void Update()
    {
        //if(imgList[0] != null)
        //{
        //switch (imgList[0])
        //{
        //case "huevoComun": imgHuevo.sprite = HuevoComun; eggOpenning = 25; break;

        //case "huevoRaro": imgHuevo.sprite = HuevoRaro; eggOpenning = 50; break;

        //case "huevoMitico": imgHuevo.sprite = HuevoMitico; eggOpenning = 75; break;

        //case "huevoLegendario": imgHuevo.sprite = HuevoLegendario; eggOpenning = 100; break;
        //}
        //}

        //string[] imgArr = imgList.ToArray();
        //Debug.Log(imgArr[0]);

        if (Input.GetMouseButtonDown(0))
        {
            if(!(menu_stats.activeInHierarchy || menu_options.activeInHierarchy || menu_info.activeInHierarchy || menu_market.activeInHierarchy))
            {
                Collider2D colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                if (colliderHit != null)
                {
                    if (colliderHit.gameObject.name == "huevo_clickable")
                    {
                        LeftClickFunc();
                    }
                    Debug.Log(colliderHit.gameObject.name);

                }
            }
        }
    }

    //Al clickar el ratón encima del huevo
    private void LeftClickFunc()
    {
        //Acciona el trigger para la animación del huevo siendo clickado (work in progress)
        //anim.SetTrigger("Clicked");
        anim.Play("clickHuevo", -1, 0f);

        //Ejecuta el sonido al hacer click+
        //clickSound.Play();
        clickSound.PlayOneShot(clickClip);

        //Incrementa en 1 y guarda esta información para a su vez actualizarla en pantalla
        clickCoins = PlayerPrefs.GetInt("ClickCoins");
        clickCoins++;
        PlayerPrefs.SetInt("ClickCoins", clickCoins);
        txt_clickcoins.text = clickCoins.ToString() + " ClickCoins";
        //Debug.Log(this.gameObject.name);

        //subimos el valor de las clickcoins totales a 1 más (estadísticas)
        PlayerPrefs.SetInt("totalClickCoins", PlayerPrefs.GetInt("totalClickCoins") + 1);

        //eggOpenning--;
        //if(eggOpenning == 0)
        //{
            //imgList.RemoveAt(0);
            //GameManager.player.listaHuevos = imgList;
            //Debug.Log(imgList[0]);
        //}
    }
}
