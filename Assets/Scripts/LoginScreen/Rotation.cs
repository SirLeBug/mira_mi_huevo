using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector2 rotatevec;
    

    // Update is called once per frame
    void Update()
    {
        //rota el fondo de la pantalla en el eje X
        this.transform.Rotate(new Vector2(0f, 1f), rotatevec.y * Time.deltaTime);
    }
}
