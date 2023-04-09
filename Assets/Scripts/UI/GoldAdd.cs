using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldAdd : MonoBehaviour
{
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameObject.GetComponent<Text>().text = string.Format("+{0:0}", playerController.enemyGold);
        gameObject.GetComponent<Animator>().Play("AddPlayerGold");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddGold()
    {
        playerController.UpdatePlayerGold();
        Destroy(gameObject);
    }
}
