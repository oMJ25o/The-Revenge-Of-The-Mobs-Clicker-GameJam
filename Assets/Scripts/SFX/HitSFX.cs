using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSFX : MonoBehaviour
{
    [SerializeField] private AudioClip hitSFX;
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayHitSFX()
    {
        audioSource.PlayOneShot(hitSFX);
    }

}
