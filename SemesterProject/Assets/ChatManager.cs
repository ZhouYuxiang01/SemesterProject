using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChatManager : MonoBehaviour
{
    List<string> contents = new List<string>();
    public TextMeshProUGUI textMeshPro;
    int nowIndex;
    // Start is called before the first frame update
    void Start()
    {
        contents.Add("Hello, and welcome to 'Last Hope' where we're going to give you some instructions on how to play the game.");
        contents.Add("Look around and you'll find soldiers with weapons of your color and some vials of blood, which you can pick up as you approach.");
        contents.Add("Also, you need to press 'Q' to make the soldiers follow you when you are close to them, press '1' to use the blood vials and for more information press 'i' to open the instruction manual. Have fun!");
        textMeshPro.text = contents[0];

    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.activeSelf) { 
            if (Input.GetKeyUp(KeyCode.Return))
            {
                //当按下了回车 下一句内容
                //当nowindex==contents.size 则隐藏当前面板
                nowIndex++;
                if(nowIndex == contents.Count)
                {
                    Hide();
                }
                else
                {
                    textMeshPro.text = contents[nowIndex];
                }
            }
        //}
    }
    public void SetContents(List<string> contents)
    {
        this.contents = contents;
        nowIndex = 0;
    }
    public void Show()
    {
        this.gameObject.SetActive(true);
        textMeshPro.text = contents[0];
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
