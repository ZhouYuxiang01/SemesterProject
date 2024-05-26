using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    List<string> contents = new List<string>();
    public TextMeshProUGUI textMeshPro;
    public AudioSource audioSource;
    public AudioClip buttonClick;
    int nowIndex;

    // Start is called before the first frame update
    void Start()
    {
        InitializeContents();
        DisplayContent(0);
    }

    // Update is called once per frame
    void Update()
    {
        // 强制每帧重新渲染TextMeshPro
        textMeshPro.ForceMeshUpdate();

        if (Input.GetKeyUp(KeyCode.Return))
        {
            PlayAudio(buttonClick);
            nowIndex++;
            if (nowIndex >= contents.Count)
            {
                Hide();
            }
            else
            {
                DisplayContent(nowIndex);
            }
        }
    }

    public void SetContents(List<string> newContents)
    {
        contents = new List<string>(newContents);
        nowIndex = 0;
        DisplayContent(nowIndex);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        DisplayContent(0);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void InitializeContents()
    {
        // 初始化内容
        contents.Add("Hello, and welcome to 'Last Hope' where we're going to give you some instructions on how to play the game.");
        contents.Add("Look around and you'll find soldiers with weapons of your color and some vials of blood, which you can pick up as you approach.");
        contents.Add("Also, you need to press 'Q' to make the soldiers follow you when you are close to them, press '1' to use the blood vials and for more information press 'i' to open the instruction manual. Have fun!");
    }

    private void DisplayContent(int index)
    {
        if (index >= 0 && index < contents.Count)
        {
            textMeshPro.text = contents[index];
        }
    }
}
