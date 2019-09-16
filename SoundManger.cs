using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManger : MonoBehaviour
{
    public GameObject soundMangerObject;

    public AudioSource source;

    public AudioClip touchSound;

    private void Awake()
    {
        soundMangerObject = transform.gameObject;
        DontDestroyOnLoad(soundMangerObject);
    }

    private void Update()
    {
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
        }
        else
        {
            source.PlayOneShot(touchSound);
        }
    }
}