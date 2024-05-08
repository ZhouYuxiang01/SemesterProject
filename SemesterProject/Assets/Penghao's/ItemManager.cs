using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.TopDownEngine;

public class ItemManager : MonoBehaviour
{
    public int healthCount = 3;
    public Health playerHp;
    public TextMeshProUGUI healthCountUI;
    public AudioSource audioSource; // AudioSource组件，需在Inspector中拖入对应的组件
    public AudioClip pickupSound; // 捡起物品的音效
    public AudioClip useSound; // 使用物品的音效

    private void Start()
    {
        healthCountUI.text = healthCount.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            TryUseHealthItem();
        }
    }

    public void SetHealthCount(int healthCount)
    {
        this.healthCount = healthCount;
        UpdateHealthUI();
    }

    public void AddHealthCount(int num)
    {
        healthCount += num;
        UpdateHealthUI();
        PlaySound(pickupSound);
    }

    private void TryUseHealthItem()
    {
        if (healthCount > 0)
        {
            playerHp.AddHealth(5);
            healthCount--;
            UpdateHealthUI();
            PlaySound(useSound);
        }
    }

    private void UpdateHealthUI()
    {
        healthCountUI.text = healthCount.ToString();
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
