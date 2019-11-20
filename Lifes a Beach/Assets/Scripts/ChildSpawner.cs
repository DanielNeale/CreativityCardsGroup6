using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    public GameObject[] spawners;

    public GameObject childPrefab;

    void Start()
    {
        StartCoroutine(spawn());
    }


    void Update()
    {

    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(50f);
        int random = Random.Range(0, 4);
        Vector3 _position = spawners[random].transform.position;
        Instantiate(childPrefab, _position, Quaternion.identity);
        StartCoroutine(spawn());
    }
}