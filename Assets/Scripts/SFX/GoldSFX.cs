using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSFX : MonoBehaviour
{
    [SerializeField] private AudioClip addGoldSFX;
    [SerializeField] private AudioClip reduceGoldSFX;
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayAddGoldSFX()
    {
        audioSource.PlayOneShot(addGoldSFX);
    }

    private void PlayReduceGoldSFX()
    {
        audioSource.PlayOneShot(reduceGoldSFX);
    }

}
