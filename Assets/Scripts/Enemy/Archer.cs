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

    protected override void OnMouseDown()
    {
        if (!playerController.isAttackCooldown)
        {
            enemyHealth -= playerController.attackDamage;
            UpdateHealthUI();
            playerController.PlayAttackAnimation();

            if (enemyHealth <= 0)
            {
                playerController.playerGold += enemyGold;
                playerController.UpdatePlayerGold();
                playerController.adventurerKilled++;
                playerController.CheckToChangeTime();
                spawnManager.SpawnEnemy();
                Destroy(gameObject);
            }
        }
    }
}
