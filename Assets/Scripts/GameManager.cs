using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Seccion para las variables del menu de estad�sticas
    [Header("Stats Variables")]
    public TextMeshProUGUI var_tiempototal;
    public TextMeshProUGUI var_clickcoinstotales;
    public TextMeshProUGUI var_clickcoinsactuales;
    public TextMeshProUGUI var_potenciaclickcoins;

    //Seccion para las variables del menu de opciones
    [Header("Options Variables")]
    public Slider slider_master;
    public Slider slider_music;
    public Slider slider_effects;
    public Slider slider_brightness;
    public Toggle toggle_fullscreen;
    public TMP_Dropdown dropdown_quality;

    //Seccion para la tienda/mercado/inventario
    [Header("Market Variables")]
    public TextMeshProUGUI var_clickcoinsactuales_market;

    //Seccion para guardar las variables del juego
    [Header("Game Variables")]
    public int test;
    public List<string> listaHuevos;
    public static GlobalVars player = new GlobalVars();

    //Seccion para arreglar bugs
    [Header("Unity Fixer")]
    public GameObject Brightness;
    private Color32 brightColor;

    //Variables utilizadas para calculo de tiempo en las estad�sticas
    int seconds = 0;
    int minutes = 0;
    int hours = 0;
    int days = 0;
    // Start is called before the first frame update

    //Coroutina, utilizada para el calculo a tiempo real de el tiempo jugado desde el primer lanzamiento del juego
    private IEnumerator Start()
    {
        //void Start: dentro de la coroutina, la aprobecho para lanzar c�digo que por defecto se pondr�a en void Start, pero no puedes tener esa funci�n + la coroutina
        startingcode();

        //Coroutine para augmentar los segundos mientras estas jugando
        while (true)
        {
            yield return new WaitForSeconds(1f);
            TimeUpdate();
        }
    }

    void startingcode()
    {
        LoadPlayer();
        TimeStart();
        setaudio();
        setgraphics();
    }

    //Funci�n para calcular el tiempo desde el primer login
    void TimeStart()
    {

        //tiempo total
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
        seconds = 0;
        minutes = 0;
        hours = 0;
        days = 0;
        if (PlayerPrefs.HasKey("firstLogin"))
        {
            seconds = cur_time - PlayerPrefs.GetInt("firstLogin");
            while (seconds >= 60 || minutes >= 60 || hours >= 24)
            {
                if (seconds >= 60)
                {
                    seconds = seconds - 60;
                    minutes++;
                }
                if (minutes >= 60)
                {
                    minutes = minutes - 60;
                    hours++;
                }
                if (hours >= 24)
                {
                    hours = hours - 24;
                    days++;
                }
                var_tiempototal.text = days + "d " + hours + "h " + minutes + "m";
            }
        } else
        {
            PlayerPrefs.SetInt("firstLogin", cur_time);
            var_tiempototal.text = days + "d " + hours + "h " + minutes + "m";
        }

        //Total ClickCoins obtenidas
        if (PlayerPrefs.HasKey("totalClickCoins"))
        {
            var_clickcoinstotales.text = PlayerPrefs.GetInt("totalClickCoins") + " CC";
        } else
        {
            PlayerPrefs.SetInt("totalClickCoins", PlayerPrefs.GetInt("ClickCoins"));
            var_clickcoinstotales.text = PlayerPrefs.GetInt("totalClickCoins") + " CC";
        }

        if (PlayerPrefs.HasKey("ClickCoins"))
        {
            var_clickcoinsactuales.text = PlayerPrefs.GetInt("ClickCoins") + " CC";
            var_clickcoinsactuales_market.text = PlayerPrefs.GetInt("ClickCoins") + " CC";
        }
        else
        {
            PlayerPrefs.SetInt("ClickCoins", 0);
            var_clickcoinsactuales.text = PlayerPrefs.GetInt("ClickCoins") + " CC";
            var_clickcoinsactuales_market.text = PlayerPrefs.GetInt("ClickCoins") + " CC";            
        }
    }

    //Setea el audio con las preferencias del usuario
    void setaudio()
    {
        slider_master.value = PlayerPrefs.GetFloat("masterVolume");
        slider_music.value = PlayerPrefs.GetFloat("musicVolume");
        slider_effects.value = PlayerPrefs.GetFloat("effectsVolume");
    }

    //Setea los gr�ficos con las preferencias del usuario
    void setgraphics()
    {

        slider_brightness.value = PlayerPrefs.GetFloat("masterBrightness");
        toggle_fullscreen.isOn = (PlayerPrefs.GetInt("masterFullscreen") == 1 ? true : false);
        dropdown_quality.value = PlayerPrefs.GetInt("masterQuality");

        brightColor = Brightness.GetComponent<SpriteRenderer>().color;
        brightColor.r = 255;
        brightColor.g = 255;
        brightColor.b = 255;
        Brightness.GetComponent<SpriteRenderer>().color = brightColor;
    }

    //Funci�n para incrementar en 1 segundo por cada segundo mientras estas jugando (se ejecuta en la coroutina)
    private void TimeUpdate()
    {
        seconds++;
        while (seconds >= 60 || minutes >= 60 || hours >= 24)
        {
            if (seconds >= 60)
            {
                seconds = seconds - 60;
                minutes++;
            }
            if (minutes >= 60)
            {
                minutes = minutes - 60;
                hours++;
            }
            if (hours >= 24)
            {
                hours = hours - 24;
                days++;
            }
            var_tiempototal.text = days + "d " + hours + "h " + minutes + "m";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Esta informaci�n se refresca cada frame
        var_clickcoinstotales.text = PlayerPrefs.GetInt("totalClickCoins") + " CC";
        var_clickcoinsactuales.text = PlayerPrefs.GetInt("ClickCoins") + " CC";
        var_clickcoinsactuales_market.text = PlayerPrefs.GetInt("ClickCoins") + " CC";
    }

    public void SavePlayer(GlobalVars player)
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();


        listaHuevos = data.listaHuevos;
        test = data.testint;
    }

    private void OnApplicationQuit()
    {
        SavePlayer(player);
    }
}
