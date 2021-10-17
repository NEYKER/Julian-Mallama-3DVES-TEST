using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;
public class GetInfo : MonoBehaviour
{
    [SerializeField] string urlPokemon = null;
    [SerializeField] TextMeshProUGUI textNamePokemon = null;

    [SerializeField] GameObject textPrefab = null;
    GameObject textinstanced = null;
    [SerializeField] RectTransform content = null;

    [SerializeField] Transform parentInstance = null;

    Quaternion initialRotation = new Quaternion(0, 0, 0, 0);

    public void Start() => StartCoroutine(GetApiDataCoroutine());
    IEnumerator GetApiDataCoroutine() 
    {
        textNamePokemon.text = "Loading...";

        UnityWebRequest request = UnityWebRequest.Get(urlPokemon);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            textNamePokemon.text = request.error;
            yield break;
        }

        //Name
        JSONNode dataRecive = JSON.Parse(request.downloadHandler.text);

        textNamePokemon.text = dataRecive["name"];

        //ID

        textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

        textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "ID:" + dataRecive["id"];

        //Base experience

        textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

        textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Base experience:" + dataRecive["base_experience"];

        //Order

        textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

        textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Order:" + dataRecive["order"];

        //Height

        textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

        textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Height:" + dataRecive["height"];

        //Weight

        textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

        textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Weight:" + dataRecive["weight"];

        //species

        textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

        textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Species:" + dataRecive["species"]["name"];


        //abilities
        JSONNode pokeAbilities = dataRecive["abilities"];
        
        for (int i = 0; i < pokeAbilities.Count; i++)
        {
            textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

            textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Ability:" +  pokeAbilities[i]["ability"]["name"];
        }

        //Types
        JSONNode pokeTypes = dataRecive["types"];

        for (int i = 0; i < pokeTypes.Count; i++)
        {
            textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation,parentInstance);

            textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Type:" + pokeTypes[i]["type"]["name"];
        }

        //Moves
        JSONNode pokeMoves = dataRecive["moves"];

        for (int i = 0; i < pokeMoves.Count; i++)
        {
            textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

            textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Move:" + pokeMoves[i]["move"]["name"];
        }

        //held items
        JSONNode pokeHeldItems = dataRecive["held_items"];

        for (int i = 0; i < pokeHeldItems.Count; i++)
        {
            textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

            textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Held Items:" + pokeHeldItems[i]["item"]["name"];
        }

        JSONNode pokeStats = dataRecive["stats"];

        for (int i = 0; i < pokeStats.Count; i++)
        {
            textinstanced = Instantiate(textPrefab, parentInstance.transform.position, initialRotation, parentInstance);

            textinstanced.GetComponentInChildren<TextMeshProUGUI>().text = "Stat-" + pokeStats[i]["stat"]["name"] + ":" + pokeStats[i]["base_stat"];
        }
    }
}
