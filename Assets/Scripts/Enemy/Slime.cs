using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyStats.enemyHealth;
        enemyGold = enemyStats.enemyGold;
        SetUpEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
