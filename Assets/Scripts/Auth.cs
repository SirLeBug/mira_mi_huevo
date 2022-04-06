using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FusedVR.Web3;
using TMPro;
using UnityEngine.SceneManagement;

public class Auth : MonoBehaviour
{
    public TextMeshProUGUI email;
    // Start is called before the first frame update
    //async void Start()
    //{

    //}

    public async void Login()
    {
        Debug.Log("Funciona el click");
        if (await Web3Manager.Login("app id", PlayerPrefs.GetString("TempEmail")))
        {
            SceneManager.LoadScene("MainScene");

            string address = await Web3Manager.GetAddress();
            Debug.Log(address);

            string balance = await Web3Manager.GetNativeBalance("eth");
            Debug.Log(balance);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Funciona el click");
        SceneManager.LoadScene("MainScene");
    }
}
