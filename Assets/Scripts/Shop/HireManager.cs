using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireManager : MonoBehaviour
{
    [SerializeField] private GameObject[] hireButtons;
    [SerializeField] private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayHire()
    {
        hireButtons[spawnManager.gameLevel - 1].SetActive(true);
    }
}