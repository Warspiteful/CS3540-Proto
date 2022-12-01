using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChanger : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnLocations;

    [SerializeField] private IntVariable spawnIndex;

    [SerializeField] private GameObject ratCharacter;
    // Start is called before the first frame update
    void Start()
    {
        ratCharacter.SetActive(false);
        ratCharacter.transform.position = spawnLocations[spawnIndex.Value].position;
        ratCharacter.transform.rotation = spawnLocations[spawnIndex.Value].rotation;
        ratCharacter.SetActive(true);
    }

}
