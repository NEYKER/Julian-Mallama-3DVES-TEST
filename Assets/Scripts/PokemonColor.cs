using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonColor : MonoBehaviour
{
    [SerializeField] List<Material> materials = new List<Material>();

    float randomR = 0;
    float randomB = 0;
    float randomG = 0;
    private void OnCollisionEnter(Collision collision)
    {
        randomR = Random.Range(0f, 1f);
        randomG = Random.Range(0f, 1f);
        randomB = Random.Range(0f, 1f);

        if (collision.gameObject.tag == "Sphere")
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].color = new Color(randomR,randomG,randomB);
            }
        }
    }

}
