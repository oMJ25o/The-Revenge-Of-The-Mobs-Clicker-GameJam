using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject goldText;
    [SerializeField] private GameObject goldPanel;
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

    [HideInInspector] public int playerUpgradeCost;
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
        playerController.UpdatePlayerGold();
        playerController.UpdatePlayerStats();
    }

    public void PlayReduceGoldAnimation(int cost)
    {
        playerUpgradeCost = cost;
        Instantiate(goldText, goldPanel.transform);
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
                    PlayReduceGoldAnimation(attackDamageUpgradeCost * (playerController.attackUpgraded + 1));
                    playerController.attackUpgraded++;
                    UpdateShopCost();
                }
                return;
            case "Speed":
                if (CheckPlayerGold(attackSpeedUpgradeCost * (playerController.speedUpgraded + 1)))
                {
                    playerController.playerGold -= (attackSpeedUpgradeCost * (playerController.speedUpgraded + 1));
                    playerController.attackSpeed += attackSpeedUpgrade;
                    PlayReduceGoldAnimation(attackSpeedUpgradeCost * (playerController.speedUpgraded + 1));
                    playerController.speedUpgraded++;
                    UpdateShopCost();
                }
                return;
            case "GoldRate":
                if (CheckPlayerGold(goldRateUpgradeCost * (playerController.goldRateUpgraded + 1)))
                {
                    playerController.playerGold -= (goldRateUpgradeCost * (playerController.goldRateUpgraded + 1));
                    playerController.goldRate += goldRateUpgrade;
                    PlayReduceGoldAnimation(goldRateUpgradeCost * (playerController.goldRateUpgraded + 1));
                    playerController.goldRateUpgraded++;
                    UpdateShopCost();
                }
                return;
        }
    }

}
