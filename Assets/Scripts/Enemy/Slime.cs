using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyStats.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnMouseDown()
    {
        enemyHealth -= 1;
        enemyHealthBar.transform.localScale = new Vector3(enemyHealth / 10, 1, 1);
        Debug.Log(enemyHealth);
    }

}
