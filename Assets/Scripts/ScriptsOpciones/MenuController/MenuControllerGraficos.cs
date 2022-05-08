using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuControllerGraficos : MonoBehaviour
{

    [Header("Brightness Setting")]
    [SerializeField] private TextMeshProUGUI brightnessTextValue = null;
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private float defaultBrightness = 1;

    [Header("Resolution Dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    [Header("Brightness GameObjects")]
    public GameObject Brightness;
    public GameObject Darkness;
    

    private int _qualityLevel;
    private bool _isFullscreen;
    private float _brightnessLevel;
    private Color32 brightColor;
    private Color32 darkColor;
    // Start is called before the first frame update
    private void Start()
    {
        //brightColor.a = 200;
        //Rellenando el dropdown list de resoluciones
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //Referenciando los colores para el brillo
        brightColor = Brightness.GetComponent<SpriteRenderer>().color;
        darkColor = Darkness.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness / 2 + 50;
        brightnessTextValue.text = _brightnessLevel.ToString("0");
        PlayerPrefs.SetFloat("masterBrightness", brightness);
        if(brightness > 0)
        {
            brightColor.a = (byte)brightness;
            darkColor.a = 0;
        } else if (brightness < 0)
        {
            darkColor.a = (byte)(brightness * -1);
            brightColor.a = 0;
        }
        Brightness.GetComponent<SpriteRenderer>().color = brightColor;
        Darkness.GetComponent<SpriteRenderer>().color = darkColor;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        _isFullscreen = isFullscreen;
        PlayerPrefs.SetInt("masterFullscreen", (_isFullscreen ? 1 : 0));
        Screen.fullScreen = _isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
