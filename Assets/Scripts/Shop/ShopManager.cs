using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int attackDamageUpgrade;
    [SerializeField] private float attackSpeedUpgrade;
    [SerializeField] private float goldRateUpgrade;
    [SerializeField] private int attackDamageUpgradeCost;
    [SerializeField] private int attackSpeedUpgradeCost;
    [SerializeField] private int goldRateUpgradeCost;
    [SerializeField] private Text attackDamageUpgradeText;
    [SerializeField] private Text attackSpeedDamageUpgradeText;
    [SerializeField] private Text goldRateUpgradeText;
    [SerializeField] private Text attackDamageCostText;
    [SerializeField] private Text attackSpeedDamageCostText;
    [SerializeField] private Text goldRateCostText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateShopCost();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckPlayerGold(int upgradeCost)
    {
        return playerController.playerGold >= upgradeCost;
    }

    public void UpdateShopCost()
    {
        attackDamageCostText.text = "" + (attackDamageUpgradeCost * (playerController.attackUpgraded + 1));
        attackSpeedDamageCostText.text = "" + (attackSpeedUpgradeCost * (playerController.speedUpgraded + 1));
        goldRateCostText.text = "" + (goldRateUpgradeCost * (playerController.goldRateUpgraded + 1));
    }

    public void UpgradePlayerStats(string upgradeName)
    {
        switch (upgradeName)
        {
            case "Attack":
                if (CheckPlayerGold(attackDamageUpgradeCost * (playerController.attackUpgraded + 1)))
                {
                    playerController.playerGold -= (attackDamageUpgradeCost * (playerController.attackUpgraded + 1));
                    playerController.attackDamage += attackDamageUpgrade;
                    playerController.attackUpgraded++;
                    UpdateShopCost();
                    playerController.UpdatePlayerGold();
                    playerController.UpdatePlayerStats();
                }
                return;
            case "Speed":
                if (CheckPlayerGold(attackSpeedUpgradeCost * (playerController.speedUpgraded + 1)))
                {
                    playerController.playerGold -= (attackSpeedUpgradeCost * (playerController.speedUpgraded + 1));
                    playerController.attackSpeed += attackSpeedUpgrade;
                    playerController.speedUpgraded++;
                    UpdateShopCost();
                    playerController.UpdatePlayerGold();
                    playerController.UpdatePlayerStats();
                }
                return;
            case "GoldRate":
                if (CheckPlayerGold(goldRateUpgradeCost * (playerController.goldRateUpgraded + 1)))
                {
                    playerController.playerGold -= (goldRateUpgradeCost * (playerController.goldRateUpgraded + 1));
                    playerController.goldRate += goldRateUpgrade;
                    playerController.goldRateUpgraded++;
                    UpdateShopCost();
                    playerController.UpdatePlayerGold();
                    playerController.UpdatePlayerStats();
                }
                return;
        }
    }

}
