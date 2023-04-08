using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int attackDamage;
    public float attackSpeed;
    public float goldRate;
    public int playerGold;

    [SerializeField] private Text playerGoldText;

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
    }

    public void UpdatePlayerGold()
    {
        playerGoldText.text = "Gold: " + playerGold;
    }

}
