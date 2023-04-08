using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundImages;
    [SerializeField] private Image backgroundImageUI;

    public int attackDamage;
    public float attackSpeed;
    public float goldRate;
    public int playerGold;

    [SerializeField] private Text playerGoldText;
    [SerializeField] private Text gameLevelText;
    [SerializeField] private Animator hitAnimation;
    [SerializeField] private AudioClip hitAudio;
    [SerializeField] private SpawnManager spawnManager;

    [HideInInspector] public bool isAttackCooldown = false;
    [HideInInspector] public int adventurerKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerGold();
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

    public void UpdatePlayerGold()
    {
        playerGoldText.text = "" + playerGold;
    }

    public void CheckToChangeTime()
    {
        if (playerGold >= (15 * spawnManager.gameLevel) && !spawnManager.dayTime)
        {
            spawnManager.dayTime = true;
            backgroundImageUI.sprite = backgroundImages[spawnManager.gameLevel];
        }
        else if (adventurerKilled >= (5 + spawnManager.gameLevel))
        {
            spawnManager.gameLevel++;
            gameLevelText.text = "Game Level: " + spawnManager.gameLevel;
            spawnManager.dayTime = false;
            backgroundImageUI.sprite = backgroundImages[spawnManager.gameLevel];
        }
    }


    IEnumerator AttackCooldown()
    {
        isAttackCooldown = true;
        yield return new WaitForSeconds(1 / attackSpeed);
        isAttackCooldown = false;
    }


}
