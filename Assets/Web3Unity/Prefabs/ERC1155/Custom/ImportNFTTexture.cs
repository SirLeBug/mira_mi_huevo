using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImportNFTTexture : MonoBehaviour
{
    //private Sprite Asprite;
    public string chain;
    public string network;
    public string contract;
    public string tokenId;
    public class Response {
        public string image;
    }

    async void Start()
    {
        //string chain = "ethereum";
        //string network = "rinkeby";
        //string contract = "0x3a8A85A6122C92581f590444449Ca9e66D8e8F35";
        //string tokenId = "5";

        // fetch uri from chain
        string uri = await ERC1155.URI(chain, network, contract, tokenId);
        print("uri: " + uri);

        // fetch json from uri
        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        await webRequest.SendWebRequest();
        Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

        // parse json to get image uri
        string imageUri = data.image;
        print("imageUri: " + imageUri);

        // fetch image and display in game
        //UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUri);
        //await textureRequest.SendWebRequest();
        StartCoroutine(GetTexture(imageUri));
        //Asprite = Resources.Load<Sprite>(imageUri);
        //this.gameObject.GetComponent<Image>().sprite = Asprite;
        //this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
    }

    IEnumerator GetTexture(string imageUri)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUri);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            this.gameObject.GetComponent<Image>().sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
        }
    }
}
