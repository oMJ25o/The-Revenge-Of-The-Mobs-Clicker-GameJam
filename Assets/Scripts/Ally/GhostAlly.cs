using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAlly : Ally
{
    // Start is called before the first frame update
    void Start()
    {
        allyAttack = allyStats.allyAttack;
        hitAnimator = GameObject.Find("GhostHitSprite").GetComponent<Animator>();
        hireManager = GameObject.Find("HireAllies").GetComponent<HireManager>();
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void AttackEnemyMob()
    {
        if (enemyMob != null)
        {
            allyAnimator.Play("Attack");
            enemyMobController.enemyHealth -= (allyAttack * hireManager.ghostAllyCount);
            enemyMobController.UpdateHealthUI();
            enemyMobController.CheckEnemyDead();
            Invoke("AttackEnemyMob", 1f);
        }
        else
        {
            FindTarget();
        }
    }

    protected override void AttackEnemyAdventurer()
    {
        if (enemyAdventurer != null)
        {
            allyAnimator.Play("Attack");
            enemyAdventurerController.enemyHealth -= (allyAttack * hireManager.ghostAllyCount);
            enemyAdventurerController.UpdateHealthUI();
            enemyAdventurerController.CheckEnemyDead();
            Invoke("AttackEnemyAdventurer", 1f);
        }
        else
        {
            FindTarget();
        }
    }
}
