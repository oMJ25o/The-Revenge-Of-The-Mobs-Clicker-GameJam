using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyStats enemyStats;
    [SerializeField] protected Animator enemyAnimation;

    protected GameObject enemyHealthBar;
    protected Text enemyHealthText;

    public float b_enemyGold;

    protected float enemyMaxHealth { get; set; }
    public float enemyHealth { get; set; }
    public float enemyGold
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

    }

    public virtual void UpdateHealthUI()
    {
        enemyHealthBar.transform.localScale = new Vector3(enemyHealth / enemyMaxHealth, 1, 1);
        enemyHealthText.text = " " + enemyHealth + " / " + enemyMaxHealth;
    }

    protected abstract void OnMouseDown();
    public abstract void CheckEnemyDead();
}
