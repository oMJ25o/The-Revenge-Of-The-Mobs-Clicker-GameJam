using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarAlly : Ally
{
    // Start is called before the first frame update
    void Start()
    {
        allyAttack = allyStats.allyAttack;
        hireManager = GameObject.Find("HireAllies").GetComponent<HireManager>();
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void AttackEnemyMob()
    {
        while (enemyMob != null)
        {
            allyAnimator.Play("Attack");
            enemyMobController.enemyHealth -= (allyAttack * hireManager.boarAllyCount);
            enemyMobController.UpdateHealthUI();
            enemyMobController.CheckEnemyDead();
            StartCoroutine("AllyAttackCooldown");
        }
        FindTarget();
    }

    protected override void AttackEnemyAdventurer()
    {
        while (enemyAdventurer != null)
        {
            allyAnimator.Play("Attack");
            enemyAdventurerController.enemyHealth -= (allyAttack * hireManager.boarAllyCount);
            enemyAdventurerController.UpdateHealthUI();
            enemyAdventurerController.CheckEnemyDead();
            StartCoroutine("AllyAttackCooldown");
        }
        FindTarget();
    }

}
