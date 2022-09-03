using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject mainBall;
    public GameObject subBall;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnMain());
        StartCoroutine(SpawnSub());
    }

    IEnumerator SpawnMain()
    {
        yield return new WaitForSeconds(1f);
        if (GameObject.FindGameObjectsWithTag("Main").Length < 3)
        {
            Instantiate(mainBall, new Vector3(Random.Range(-6, 6), 0.5f, Random.Range(-6, 6)), mainBall.transform.rotation);
        }
        StartCoroutine(SpawnMain());
    }

    IEnumerator SpawnSub()
    {
        yield return new WaitForSeconds(1f);
        if (GameObject.FindGameObjectsWithTag("Sub").Length < 2)
        {
            Instantiate(subBall, new Vector3(Random.Range(-6, 6), 0.5f, Random.Range(-6, 6)), subBall.transform.rotation);
        }
        StartCoroutine(SpawnSub());
    }
}
