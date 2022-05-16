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

            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //if (hit.collider != null)
            //{
            //if (hit.collider.gameObject.name == "Tick" || hit.collider.gameObject.name == "huevo_bienvenida")
            //{
            //LeftClickFunc();
            //}
            //Debug.Log(hit.collider.gameObject.name);

            //}

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);
            foreach (var hit in hits)
            {
                if (hit.collider.name == name)
                {
                    LeftClickFunc();
                }
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
                
                GlobalVars.listaHuevos.Add(s);
                //Debug.Log(GameManager.GlobalVars.listaHuevos);
            }

            Debug.Log(GlobalVars.listaHuevos.Count);
        }
    }

}
