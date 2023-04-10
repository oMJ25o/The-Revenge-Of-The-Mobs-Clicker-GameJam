using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    [SerializeField] private AllyStats allyStats;
    [SerializeField] private Animator allyAnimator;
    private GameObject enemyMob;
    private GameObject enemyAdventurer;
    private Mobs enemyMobController;
    private Adventurers enemyAdventurerController;
    private int allyAttack;
    // Start is called before the first frame update
    void Start()
    {
        allyAttack = allyStats.allyAttack;
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindTarget()
    {
        enemyMob = GameObject.FindWithTag("EnemyMob");
        enemyAdventurer = GameObject.FindWithTag("EnemyAdventurer");

        if (enemyMob != null)
        {
            enemyMobController = enemyMob.GetComponent<Mobs>();
            StartCoroutine("AllyAttackEnemyMob");
        }
        else if (enemyAdventurer != null)
        {
            enemyAdventurerController = enemyAdventurer.GetComponent<Adventurers>();
            StartCoroutine("AllyAttackEnemyAdventurer");
        }
    }

    IEnumerator AllyAttackEnemyMob()
    {
        while (enemyMob != null)
        {
            allyAnimator.Play("Attack");
            enemyMobController.enemyHealth -= allyAttack;
            enemyMobController.UpdateHealthUI();
            enemyMobController.CheckEnemyDead();
            yield return new WaitForSeconds(1);
        }
        FindTarget();
    }

    IEnumerator AllyAttackEnemyAdventurer()
    {
        while (enemyAdventurer != null)
        {
            allyAnimator.Play("Attack");
            enemyAdventurerController.enemyHealth -= allyAttack;
            enemyAdventurerController.UpdateHealthUI();
            enemyAdventurerController.CheckEnemyDead();
            yield return new WaitForSeconds(1);
        }
        FindTarget();
    }

}
