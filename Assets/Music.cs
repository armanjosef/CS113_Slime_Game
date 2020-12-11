using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
}
