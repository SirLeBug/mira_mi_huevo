using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuOpciones : MonoBehaviour
{
    public Button buttonUsed;
    public Button buttonNotUsed1;
    public Button buttonNotUsed2;
    public GameObject gameObjectUsed;
    public GameObject gameObjectNotUsed1;
    public GameObject gameObjectNotUsed2;
    // Start is called before the first frame update
    void Start()
    {
        //buttonUsed.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void whenButtonClicked()
    {
        //buttonUsed.GetComponent<Image>().color = new Color(162, 223, 162);
        //buttonNotUsed1.GetComponent<Image>().color = new Color(43, 130, 43);
        //buttonNotUsed2.GetComponent<Image>().color = new Color(43, 130, 43);

        buttonUsed.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        buttonNotUsed1.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        buttonNotUsed2.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

        gameObjectUsed.SetActive(true);
        gameObjectNotUsed1.SetActive(false);
        gameObjectNotUsed2.SetActive(false);
    }
}
