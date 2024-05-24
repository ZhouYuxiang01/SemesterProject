using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip click;
    public GameObject tipsPanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            PlayAudio(click);
            tipsPanel.SetActive(!tipsPanel.active);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayAudio(click);
            // Òþ²ØÌáÊ¾°å
            tipsPanel.SetActive(false);
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

}
