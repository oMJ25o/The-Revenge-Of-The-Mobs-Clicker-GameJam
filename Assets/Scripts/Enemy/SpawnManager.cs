using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    [HideInInspector] public int enemyIndex;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[enemyIndex], enemyPrefabs[enemyIndex].transform.position, enemyPrefabs[enemyIndex].transform.rotation);
    }

}
