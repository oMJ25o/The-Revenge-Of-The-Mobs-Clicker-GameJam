using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyMobPrefabs;
    [SerializeField] GameObject[] enemyAdventurerPrefabs;
    public bool dayTime = false;

    [HideInInspector] public int enemyIndex;
    [HideInInspector] public int gameLevel = 1;

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
        enemyIndex = gameLevel - 1;
        if (!dayTime)
        {
            if (gameLevel >= 6)
            {
                enemyIndex = Random.Range(0, enemyMobPrefabs.Length);
                Instantiate(enemyMobPrefabs[enemyIndex], enemyMobPrefabs[enemyIndex].transform.position, enemyMobPrefabs[enemyIndex].transform.rotation);
            }
            else
            {
                Instantiate(enemyMobPrefabs[enemyIndex], enemyMobPrefabs[enemyIndex].transform.position, enemyMobPrefabs[enemyIndex].transform.rotation);
            }
        }
        else if (dayTime)
        {
            int randomAdventurer = Random.Range(0, enemyAdventurerPrefabs.Length);
            Instantiate(enemyAdventurerPrefabs[randomAdventurer], enemyAdventurerPrefabs[randomAdventurer].transform.position, enemyAdventurerPrefabs[randomAdventurer].transform.rotation);
        }
    }

}
