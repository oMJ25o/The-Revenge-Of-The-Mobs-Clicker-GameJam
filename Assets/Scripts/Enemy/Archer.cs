using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        SetUpEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void SetUpEnemy()
    {
        base.SetUpEnemy();
        enemyHealth = enemyStats.enemyHealth * spawnManager.gameLevel;
        enemyGold = enemyStats.enemyGold * (spawnManager.gameLevel);

        UpdateHealthUI();
    }

    protected override void UpdateHealthUI()
    {
        enemyHealthBar.transform.localScale = new Vector3(enemyHealth / (enemyStats.enemyHealth * spawnManager.gameLevel), 1, 1);
        enemyHealthText.text = " " + enemyHealth + " / " + enemyStats.enemyHealth;
    }

    protected override void OnMouseDown()
    {
        if (!playerController.isAttackCooldown)
        {
            enemyHealth -= playerController.attackDamage;
            UpdateHealthUI();
            playerController.PlayAttackAnimation();

            if (enemyHealth <= 0)
            {
                playerController.playerGold += (enemyGold * playerController.goldRate);
                playerController.UpdatePlayerGold();
                playerController.adventurerKilled++;
                playerController.CheckToChangeTime();
                spawnManager.SpawnEnemy();
                Destroy(gameObject);
            }
        }
    }
}
