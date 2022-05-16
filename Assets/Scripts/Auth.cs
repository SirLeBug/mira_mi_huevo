using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FusedVR.Web3;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using System;

public class Auth : MonoBehaviour
{
    public TextMeshProUGUI email;

    CancellationTokenSource _tokenSource = null;
    // Start is called before the first frame update
    //async void Start()
    //{

    //}

    public async void Login()
    {
        _tokenSource = new CancellationTokenSource();

        try
        {
            //hacemos login con el valor de la caja de texto (guardado en local) y pasamos a la siguiente escena (en la consola muestro la dirección de la cartera y el balance en ETH como ejemplo)
            if (await Web3Manager.Login("app id", PlayerPrefs.GetString("TempEmail")))
            {
                SceneManager.LoadScene("MainScene");

                string address = await Web3Manager.GetAddress();
                Debug.Log(address);

                string balance = await Web3Manager.GetNativeBalance("eth");
                Debug.Log(balance);
            }

        } catch (OperationCanceledException e)
        {
            //no tiene pinta de funcionar
            Debug.Log("Operación abortada:" + e);
        }
        
    }

    public void CancelLogin()
    {
        _tokenSource.Cancel();
    }
}
