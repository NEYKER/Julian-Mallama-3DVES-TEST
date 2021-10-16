using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GetInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textNamePokemon = null;

    public void Start() => StartCoroutine(GetApiDataCoroutine());

    IEnumerator GetApiDataCoroutine() 
    {
        textNamePokemon.text = "Loading...";
        string url = "https://pokeapi.co/api/v2/pokemon/ditto";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                textNamePokemon.text = request.error;
            else
                textNamePokemon.text = request.downloadHandler.text;
        }
    }
}
