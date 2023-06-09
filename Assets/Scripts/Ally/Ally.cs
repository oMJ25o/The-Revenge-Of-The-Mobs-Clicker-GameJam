using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ally : MonoBehaviour
{
    [SerializeField] protected AllyStats allyStats;
    [SerializeField] protected Animator allyAnimator;
    protected Animator hitAnimator;
    protected HireManager hireManager;
    protected GameObject enemyMob;
    protected GameObject enemyAdventurer;
    protected Mobs enemyMobController;
    protected Adventurers enemyAdventurerController;
    protected int allyAttack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void FindTarget()
    {
        enemyMob = GameObject.FindWithTag("EnemyMob");
        enemyAdventurer = GameObject.FindWithTag("EnemyAdventurer");

        if (enemyMob != null)
        {
            enemyMobController = enemyMob.GetComponent<Mobs>();
            Invoke("AttackEnemyMob", 0f);
        }
        else if (enemyAdventurer != null)
        {
            enemyAdventurerController = enemyAdventurer.GetComponent<Adventurers>();
            Invoke("AttackEnemyAdventurer", 0f);
        }
    }

    protected virtual void PlayHitAnimation()
    {
        hitAnimator.Play("Hit");
    }

    protected abstract void AttackEnemyMob();

    protected abstract void AttackEnemyAdventurer();

}
