using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public int priceItem;
    public Texture2D imageItem;
    public TMP_InputField inputItem;

    private int cantItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Collider2D colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (colliderHit != null)
            {
                if (colliderHit.gameObject.name == "Tick")
                {
                    LeftClickFunc();
                }
                Debug.Log(colliderHit.gameObject.name);

            }
            
        }
    }

    private void LeftClickFunc()
    {
        //Obtain the quantity of the item
        cantItem = int.Parse(inputItem.GetComponent<TMP_InputField>().text);

        int priceTotal = cantItem * priceItem;

        if (priceTotal <= PlayerPrefs.GetInt("ClickCoins"))
        {
            PlayerPrefs.SetInt("ClickCoins", PlayerPrefs.GetInt("ClickCoins") - priceTotal);

            //Accedemos a la variable global listaHuevos y añadimos

            for (int i = 0; i < cantItem; i++)
            {
                //quitamos la parte de "(Unity Texture2D)" del string
                string s = imageItem.ToString().Split(" (")[0];
                
                GameManager.player.listaHuevos.Add(s);
                //Debug.Log(GameManager.GlobalVars.listaHuevos);
            }

            Debug.Log(GameManager.player.listaHuevos.Count);
        }
    }

}
