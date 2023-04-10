using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject[] hireButtons;
    [SerializeField] private GameObject[] allyObjects;
    [SerializeField] private GameObject[] allyPrefabs;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private int slimeHireCost = 100;
    [SerializeField] private int boarHireCost = 300;
    [SerializeField] private int ghostHireCost = 750;
    [SerializeField] private int reptileHireCost = 1250;

    [HideInInspector] public int slimeAllyCount = 0;
    [HideInInspector] public int boarAllyCount = 0;
    [HideInInspector] public int ghostAllyCount = 0;
    [HideInInspector] public int reptileAllyCount = 0;
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

    public bool CheckPlayerGold(int upgradeCost)
    {
        return playerController.playerGold >= upgradeCost;
    }

    public void HireAlly(int allyIndex)
    {
        switch (allyIndex)
        {
            case 0:
                if (!CheckPlayerGold(slimeHireCost))
                {
                    return;
                }
                if (slimeAllyCount == 0)
                {
                    SpawnAlly(allyIndex);
                }
                slimeAllyCount++;
                playerController.playerGold -= slimeHireCost;
                playerController.UpdatePlayerGold();
                return;
            case 1:
                if (!CheckPlayerGold(boarHireCost))
                {
                    return;
                }
                if (boarAllyCount == 0)
                {
                    SpawnAlly(allyIndex);
                }
                playerController.playerGold -= boarHireCost;
                playerController.UpdatePlayerGold();
                boarAllyCount++;
                return;
            case 2:
                if (!CheckPlayerGold(ghostHireCost))
                {
                    return;
                }
                if (ghostAllyCount == 0)
                {
                    SpawnAlly(allyIndex);
                }
                playerController.playerGold -= ghostHireCost;
                playerController.UpdatePlayerGold();
                ghostAllyCount++;
                return;
            case 3:
                if (!CheckPlayerGold(reptileHireCost))
                {
                    return;
                }
                if (reptileAllyCount == 0)
                {
                    SpawnAlly(allyIndex);
                }
                playerController.playerGold -= reptileHireCost;
                playerController.UpdatePlayerGold();
                reptileAllyCount++;
                return;
        }
    }

    public void SpawnAlly(int allyIndex)
    {
        Instantiate(allyPrefabs[allyIndex], allyPrefabs[allyIndex].transform.position, allyPrefabs[allyIndex].transform.rotation);
    }
}