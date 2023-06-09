using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] nightBackgroundImages;
    [SerializeField] private Sprite[] dayBackgroundImages;
    [SerializeField] private GameObject hireUI;
    [SerializeField] private GameObject goldPanel;
    [SerializeField] private GameObject goldAddPrefab;
    [SerializeField] private Image backgroundImageUI;
    [SerializeField] private Text attackDamageStatsText;
    [SerializeField] private Text attackSpeedStatsText;
    [SerializeField] private Text goldRateStatsText;

    public int attackDamage;
    public float attackSpeed;
    public float goldRate;
    public float playerGold;
    public int attackUpgraded;
    public int speedUpgraded;
    public int goldRateUpgraded;

    [SerializeField] private Text playerGoldText;
    [SerializeField] private Text gameLevelText;
    [SerializeField] private Animator hitAnimation;
    [SerializeField] private AudioClip hitAudio;
    [SerializeField] private SpawnManager spawnManager;

    [HideInInspector] public bool isAttackCooldown = false;
    [HideInInspector] public int adventurerKilled = 0;
    [HideInInspector] public int mobsKilled = 0;
    [HideInInspector] public float enemyGold;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerGold();
        UpdatePlayerStats();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetUpPlayer()
    {

    }

    public void PlayAttackAnimation()
    {
        gameObject.GetComponent<Animator>().Play("PlayerAttack");
        gameObject.GetComponent<AudioSource>().PlayOneShot(hitAudio);
        StartCoroutine("AttackCooldown");
    }

    public void PlayHitAnimation()
    {
        hitAnimation.Play("hitAnimation");
    }

    public void PlayAddPlayerGoldAnimation(float gold)
    {
        enemyGold = gold;
        Instantiate(goldAddPrefab, goldPanel.transform);
    }

    public void UpdatePlayerGold()
    {
        playerGoldText.text = string.Format("{0:0}", playerGold);
    }

    public void UpdatePlayerStats()
    {
        attackDamageStatsText.text = string.Format("{0:0.0###}", attackDamage);
        attackSpeedStatsText.text = string.Format("{0:0.0###}", attackSpeed);
        goldRateStatsText.text = string.Format("{0:0}%", (goldRate * 100f));
    }

    public void CheckToChangeTime()
    {
        if (mobsKilled >= (20 * spawnManager.gameLevel) && !spawnManager.dayTime && spawnManager.gameLevel <= 6)
        {
            spawnManager.dayTime = true;
            backgroundImageUI.sprite = dayBackgroundImages[spawnManager.gameLevel - 1];
            hireUI.SetActive(true);
            hireUI.GetComponent<HireManager>().DisplayHire();
        }
        else if (adventurerKilled >= (15 * spawnManager.gameLevel) && spawnManager.gameLevel <= 6)
        {
            spawnManager.dayTime = false;
            backgroundImageUI.sprite = nightBackgroundImages[spawnManager.gameLevel];
            spawnManager.gameLevel++;
            gameLevelText.text = "Game Level: " + spawnManager.gameLevel;
        }
        else if (spawnManager.gameLevel > 6)
        {
            spawnManager.dayTime = true;
            if (adventurerKilled >= (15 * spawnManager.gameLevel))
            {
                spawnManager.gameLevel++;
            }
            gameLevelText.text = "Game Level: " + spawnManager.gameLevel;
        }
    }


    IEnumerator AttackCooldown()
    {
        isAttackCooldown = true;
        yield return new WaitForSeconds(1 / attackSpeed);
        isAttackCooldown = false;
    }


}
