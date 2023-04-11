using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject hireUI;
    [SerializeField] private Text slimeHireCountText;
    [SerializeField] private Text boarHireCountText;
    [SerializeField] private Text ghostHireCountText;
    [SerializeField] private Text reptileHireCountText;
    [SerializeField] private Image slimeHireCountImage;
    [SerializeField] private Image boarHireCountImage;
    [SerializeField] private Image ghostHireCountImage;
    [SerializeField] private Image reptileHireCountImage;
    [SerializeField] private GameObject[] allyPrefabs;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private int slimeHireCost = 100;
    [SerializeField] private int boarHireCost = 300;
    [SerializeField] private int ghostHireCost = 750;
    [SerializeField] private int reptileHireCost = 1250;
    [SerializeField] private Text slimeHireCostText;
    [SerializeField] private Text boarHireCostText;
    [SerializeField] private Text ghostHireCostText;
    [SerializeField] private Text reptileHireCostText;
    [SerializeField] private Button slimeHireButton;
    [SerializeField] private Button boarHireButton;
    [SerializeField] private Button ghostHireButton;
    [SerializeField] private Button reptileHireButton;

    [HideInInspector] public int slimeAllyCount = 0;
    [HideInInspector] public int boarAllyCount = 0;
    [HideInInspector] public int ghostAllyCount = 0;
    [HideInInspector] public int reptileAllyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHireCost();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeButtonInteractable();
    }

    public void ChangeButtonInteractable()
    {
        slimeHireButton.interactable = (playerController.playerGold >= slimeHireCost);
        boarHireButton.interactable = (playerController.playerGold >= boarHireCost);
        ghostHireButton.interactable = (playerController.playerGold >= ghostHireCost);
        reptileHireButton.interactable = (playerController.playerGold >= reptileHireCost);
    }

    public void DisplayHire()
    {
        switch (spawnManager.gameLevel)
        {
            case 1:
                slimeHireButton.gameObject.SetActive(true);
                return;
            case 2:
                boarHireButton.gameObject.SetActive(true);
                return;
            case 3:
                ghostHireButton.gameObject.SetActive(true);
                return;
            case 4:
                reptileHireButton.gameObject.SetActive(true);
                return;
        }
    }

    public void UpdateHireCount()
    {
        hireUI.SetActive(true);
        if (slimeAllyCount >= 1)
        {
            slimeHireCountImage.gameObject.SetActive(true);
            slimeHireCountText.gameObject.SetActive(true);
            slimeHireCountText.text = "" + slimeAllyCount;
        }

        if (boarAllyCount >= 1)
        {
            boarHireCountImage.gameObject.SetActive(true);
            boarHireCountText.gameObject.SetActive(true);
            boarHireCountText.text = "" + boarAllyCount;
        }

        if (ghostAllyCount >= 1)
        {
            ghostHireCountImage.gameObject.SetActive(true);
            ghostHireCountText.gameObject.SetActive(true);
            ghostHireCountText.text = "" + ghostAllyCount;
        }

        if (reptileAllyCount >= 1)
        {
            reptileHireCountImage.gameObject.SetActive(true);
            reptileHireCountText.gameObject.SetActive(true);
            reptileHireCountText.text = "" + reptileAllyCount;
        }
    }

    public bool CheckPlayerGold(int upgradeCost)
    {
        return playerController.playerGold >= upgradeCost;
    }

    private void UpdateHireCost()
    {
        UpdateHireCount();
        slimeHireCostText.text = "" + slimeHireCost;
        boarHireCostText.text = "" + boarHireCost;
        ghostHireCostText.text = "" + ghostHireCost;
        reptileHireCostText.text = "" + reptileHireCost;
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
                playerController.playerGold -= slimeHireCost;
                playerController.UpdatePlayerGold();
                slimeAllyCount++;
                slimeHireCost += (35 * slimeAllyCount);
                break;
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
                boarHireCost += (60 * boarAllyCount);
                break;
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
                ghostHireCost += (95 * boarAllyCount);
                break;
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
                reptileHireCost += (110 * reptileAllyCount);
                break;
        }
        UpdateHireCost();
    }

    public void SpawnAlly(int allyIndex)
    {
        UpdateHireCount();
        Instantiate(allyPrefabs[allyIndex], allyPrefabs[allyIndex].transform.position, allyPrefabs[allyIndex].transform.rotation);
    }
}