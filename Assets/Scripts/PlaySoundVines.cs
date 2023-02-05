using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXvineTrigger : MonoBehaviour
{
    AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void OnHitEvent()
    {
        source.Play();
    }
   
}
