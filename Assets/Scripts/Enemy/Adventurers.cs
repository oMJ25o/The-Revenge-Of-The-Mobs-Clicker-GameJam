using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurers : Enemy
{
    public bool isDead = false;
    public int direction;
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
        enemyHealth = enemyStats.enemyHealth * spawnManager.gameLevel + (playerController.adventurerKilled * 28);
        enemyMaxHealth = enemyHealth;
        enemyGold = enemyStats.enemyGold * spawnManager.gameLevel;
        UpdateHealthUI();
    }

    public override void UpdateHealthUI()
    {
        enemyHealthBar.transform.localScale = new Vector3(enemyHealth / enemyMaxHealth, 1, 1);
        enemyHealthText.text = " " + enemyHealth + " / " + enemyMaxHealth;
    }

    protected override void OnMouseDown()
    {
        if (!playerController.isAttackCooldown)
        {
            enemyHealth -= playerController.attackDamage;
            UpdateHealthUI();
            playerController.PlayAttackAnimation();
            CheckEnemyDead();
        }
    }

    public override void CheckEnemyDead()
    {
        if (enemyHealth <= 0 && !isDead)
        {
            isDead = true;
            playerController.playerGold += (enemyGold * playerController.goldRate);
            playerController.PlayAddPlayerGoldAnimation((enemyGold * playerController.goldRate));
            playerController.adventurerKilled++;
            playerController.CheckToChangeTime();
            spawnManager.SpawnEnemy();
            Destroy(gameObject);
        }
    }
}
