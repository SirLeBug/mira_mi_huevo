using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RainbowEffect : MonoBehaviour
{
    //public variables from unity
    public TMP_InputField input;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI email;
    public TextMeshProUGUI esperando;
    public Button button;
    public float rainbowSpeed;

    //private variables
    private Material matInput;
    private Material matButton;
    //
    private float hue;
    private float saturation;
    private float brightness;

    // Start is called before the first frame update
    void Start()
    {
        matInput = input.image.material;
        matButton = input.image.material;
        //matTmp;
    }

    // Update is called once per frame
    void Update()
    {
        //Transformamos el color RGB a HSV
        Color.RGBToHSV(matInput.color, out hue, out saturation, out brightness);

        //Cambiamos los parametros antes de volverlos a asignar
        hue += rainbowSpeed / 10000;
        if(hue >= 1)
        {
          hue = 0;
        }
        saturation = 1;
        brightness = 1;

        //Devolvemos de HSV a RGB
        matInput.color = Color.HSVToRGB(hue, saturation, brightness);
        tmp.color = matInput.color;
        email.color = matInput.color;
        esperando.color = matInput.color;


    }
}
