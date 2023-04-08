using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject enemyHealthBar;
    [SerializeField] protected Text enemyHealthText;
    [SerializeField] protected EnemyStats enemyStats;

    protected float b_enemyMaxHealth;

    protected float enemyHealth
    {
        get { return b_enemyMaxHealth; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Enemy Max Health cannot be negative or 0 value");
            }
            else
            {
                b_enemyMaxHealth = value;
            }
        }
    }
    protected PlayerController playerController { get; private set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void SetUpEnemy()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    protected abstract void OnMouseDown();

}
