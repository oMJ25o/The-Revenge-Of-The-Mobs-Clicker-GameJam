using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject selectedIndicatorRight;
    [SerializeField] private GameObject selectedIndicatorLeft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressedStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnMouseEnter()
    {
        selectedIndicatorRight.SetActive(true);
        selectedIndicatorLeft.SetActive(true);
    }

    private void OnMouseExit()
    {
        selectedIndicatorRight.SetActive(false);
        selectedIndicatorLeft.SetActive(false);
    }

}
