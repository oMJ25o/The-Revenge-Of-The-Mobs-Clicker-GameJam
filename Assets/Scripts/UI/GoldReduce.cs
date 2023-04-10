using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldReduce : MonoBehaviour
{
    private PlayerController playerController;
    private ShopManager shopManager;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        shopManager = GameObject.Find("Shop").GetComponent<ShopManager>();
        gameObject.GetComponent<Text>().text = string.Format("+{0:0}", shopManager.playerUpgradeCost);
        gameObject.GetComponent<Animator>().Play("ReducePlayerGold");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReduceGold()
    {
        gameObject.GetComponent<Text>().text = string.Format("-{0:0}", shopManager.playerUpgradeCost);
        playerController.UpdatePlayerGold();
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
