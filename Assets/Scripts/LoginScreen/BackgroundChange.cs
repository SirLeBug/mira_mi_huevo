using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public Material morning;
    public Material noon;
    public Material afternoon;
    public Material night;
    private int index = 0;
    //private Cubemap[] arrCubes = new Cubemap[4] { morning, noon, afternoon, night };
    // Start is called before the first frame update

    private IEnumerator Start()
    {
        //void Start: dentro de la coroutina, la aprobecho para lanzar código que por defecto se pondría en void Start, pero no puedes tener esa función + la coroutina

        startingcode();

        //Coroutine para augmentar los segundos mientras estas jugando
        while (true)
        {
            yield return new WaitForSeconds(60f);
            startingcode();
        }
    }

    void startingcode()
    {
        Material[] arrMats = new Material[4] { morning, noon, afternoon, night };
        RenderSettings.skybox = arrMats[index];
        index += 1;
        if(index >= arrMats.Length)
        {
            index = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
