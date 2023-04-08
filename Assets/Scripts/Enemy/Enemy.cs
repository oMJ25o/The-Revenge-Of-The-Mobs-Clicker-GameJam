using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject enemyHealthBar;
    [SerializeField] protected EnemyStats enemyStats;

    protected float b_enemyMaxHealth;

    public float enemyHealth
    {
        get { return b_enemyMaxHealth; }
        set
        {
            if (value <= 0)
            {
                Debug.Log("Enemy Max Health cannot be negative or 0 value");
            }
            else
            {
                b_enemyMaxHealth = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected abstract void OnMouseDown();

}
