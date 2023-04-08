using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int attackDamageUpgrade;
    [SerializeField] private float attackSpeedUpgrade;
    [SerializeField] private float goldRateUpgrade;
    [SerializeField] private int attackDamageUpgradeCost;
    [SerializeField] private int attackSpeedUpgradeCost;
    [SerializeField] private int goldRateUpgradeCost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckPlayerGold(int upgradeCost)
    {
        return playerController.playerGold >= upgradeCost;
    }

    public void UpgradePlayerStats(string upgradeName)
    {
        switch (upgradeName)
        {
            case "Attack":
                if (CheckPlayerGold(attackDamageUpgradeCost))
                {
                    playerController.playerGold -= attackDamageUpgradeCost;
                    playerController.attackDamage += attackDamageUpgrade;
                    playerController.UpdatePlayerGold();
                }
                return;
            case "Speed":
                if (CheckPlayerGold(attackSpeedUpgradeCost))
                {
                    playerController.playerGold -= attackSpeedUpgradeCost;
                    playerController.attackSpeed += attackSpeedUpgrade;
                    playerController.UpdatePlayerGold();
                }
                return;
            case "GoldRate":
                if (CheckPlayerGold(goldRateUpgradeCost))
                {
                    playerController.playerGold -= goldRateUpgradeCost;
                    playerController.goldRate += goldRateUpgrade;
                    playerController.UpdatePlayerGold();
                }
                return;
        }

    }

}
