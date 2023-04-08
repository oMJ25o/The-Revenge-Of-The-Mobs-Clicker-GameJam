using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStats enemyStats;

    protected GameObject enemyHealthBar;
    protected Text enemyHealthText;

    protected int b_enemyGold;

    protected float enemyHealth { get; set; }
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
    protected SpawnManager spawnManager { get; private set; }

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
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemyHealthBar = GameObject.Find("HealthBar");
        enemyHealthText = GameObject.Find("HealthText").GetComponent<Text>();
        enemyHealth = enemyStats.enemyHealth;
        enemyGold = enemyStats.enemyGold;

        UpdateHealthUI();
    }

    protected virtual void UpdateHealthUI()
    {
        enemyHealthBar.transform.localScale = new Vector3(enemyHealth / 10, 1, 1);
        enemyHealthText.text = " " + enemyHealth + " / " + enemyStats.enemyHealth;
    }

    protected virtual void OnMouseDown()
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
                spawnManager.SpawnEnemy();
                Destroy(gameObject);
            }

        }

    }

}
