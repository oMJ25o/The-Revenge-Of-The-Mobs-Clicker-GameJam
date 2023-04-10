using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobs : Enemy
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
        enemyHealth = enemyStats.enemyHealth;
        enemyMaxHealth = enemyHealth;
        enemyGold = enemyStats.enemyGold;

        UpdateHealthUI();
    }

    protected override void OnMouseDown()
    {
        if (!playerController.isAttackCooldown)
        {
            enemyHealth -= playerController.attackDamage;
            UpdateHealthUI();
            playerController.PlayAttackAnimation();
            enemyAnimation.Play("TakeDamage");
            CheckEnemyDead();
        }
    }

    public override void CheckEnemyDead()
    {
        if (enemyHealth <= 0)
        {
            playerController.playerGold += (enemyGold * playerController.goldRate);
            playerController.mobsKilled++;
            playerController.PlayAddPlayerGoldAnimation(enemyGold * playerController.goldRate);
            playerController.CheckToChangeTime();
            spawnManager.SpawnEnemy();
            Destroy(gameObject);
        }
    }
}
