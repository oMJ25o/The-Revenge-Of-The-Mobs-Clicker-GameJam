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
    protected int b_enemyGold;
    protected bool isAttackCooldown = false;

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
    protected int enemyGold
    {
        get { return b_enemyGold; }
        set
        {
            if (value <= 0)
            {
                Debug.Log("Enemy Gold cannot be negative or 0");
            }
            else
            {
                b_enemyGold = value;
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
        enemyHealth = enemyStats.enemyHealth;
        enemyGold = enemyStats.enemyGold;
    }

    protected virtual void UpdateHealthUI()
    {
        enemyHealthBar.transform.localScale = new Vector3(enemyHealth / 10, 1, 1);
        enemyHealthText.text = " " + enemyHealth + " / " + enemyStats.enemyHealth;
    }

    protected virtual void OnMouseDown()
    {
        if (!isAttackCooldown)
        {
            enemyHealth -= playerController.attackDamage;
            UpdateHealthUI();
            playerController.PlayAttackAnimation();
            StartCoroutine("AttackCooldown");
        }
    }

    IEnumerator AttackCooldown()
    {
        isAttackCooldown = true;

        if (enemyHealth == 0)
        {
            playerController.playerGold += enemyGold;
            playerController.UpdatePlayerGold();
        }

        yield return new WaitForSeconds(1 / playerController.attackSpeed);
        isAttackCooldown = false;
    }


}
