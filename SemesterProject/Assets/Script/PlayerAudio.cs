using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource walkSource;      // 走路声音的AudioSource
    public AudioSource actionSource;    // 翻滚和攻击的AudioSource
    public AudioClip walkClip;          // 走路声音的AudioClip
    public AudioClip rollClip;          // 翻滚声音的AudioClip
    //public AudioClip attackClip;        // 攻击声音的AudioClip
    public AudioClip jumpClip;          // 跳跃声音的AudioClip

    private float lastAttackTime = 0;   // 上一次攻击声音播放的时间
    private bool canRoll = true;        // 是否可以播放翻滚声音
    private bool canJump = true;        // 是否可以播放跳跃声音

    void Update()
    {
        HandleWalking();
        HandleRolling();
        HandleJumping();
        //HandleAttacking();
    }

    void HandleWalking()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!walkSource.isPlaying)
            {
                walkSource.clip = walkClip;
                walkSource.loop = true;
                walkSource.Play();
            }
        }
        else
        {
            if (walkSource.isPlaying)
            {
                walkSource.Stop();
            }
        }
    }

    void HandleRolling()
    {
        if (Input.GetKeyDown(KeyCode.F) && canRoll)
        {
            PlaySoundLimited(rollClip, 1f);
            canRoll = false;
            StartCoroutine(ActionCooldown(() => canRoll = true, 0.5f));
        }
    }

    void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            PlaySoundLimited(jumpClip, 1f);
            canJump = false;
            StartCoroutine(ActionCooldown(() => canJump = true, 0.5f));
        }
    }

    /*void HandleAttacking()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= 2.0f)
        {
            actionSource.PlayOneShot(attackClip);
            lastAttackTime = Time.time;
        }
    }*/

    void PlaySoundLimited(AudioClip clip, float duration)
    {
        actionSource.PlayOneShot(clip);
        StartCoroutine(StopSoundAfterDuration(actionSource, duration));
    }

    IEnumerator StopSoundAfterDuration(AudioSource source, float duration)
    {
        yield return new WaitForSeconds(duration);
        source.Stop();
    }

    IEnumerator ActionCooldown(System.Action onComplete, float delay)
    {
        yield return new WaitForSeconds(delay);
        onComplete();
    }
}
