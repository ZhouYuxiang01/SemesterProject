using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class CountdownTrigger : MonoBehaviour
{
    public float countdownTime = 30f;
    private float timer; // 计时器
    private bool isCountingDown = false;
    public Canvas deathScreenCanvas; // 引用 Canvas
    private DeathScreen deathScreen;
    public TextMeshProUGUI timerText;
    public GameObject targetObject; // 特定的 GameObject
    public AudioSource audioSource;
    public AudioClip countdown;
    private bool countdownAudioPlayed = false; // 用于标记音频是否已经播放

    void Start()
    {
        deathScreen = deathScreenCanvas.GetComponentInChildren<DeathScreen>();
        if (deathScreen == null)
        {
            Debug.LogError("DeathScreen component not found on the canvas!");
        }
        timer = countdownTime; // 初始化计时器为倒计时时间
        timerText.enabled = false; // 开始时不显示计时器
    }

    void Update()
    {
        if (isCountingDown)
        {
            timer -= Time.deltaTime; // 计时器递减
            if (timer <= 0)
            {
                timer = 0; // 防止计时器出现负值
                deathScreen.ShowVictoryScreen();
                isCountingDown = false; // 停止计时
            }
            timerText.text = Mathf.Ceil(timer).ToString(); // 更新显示的时间为整数秒
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            isCountingDown = false;
            timerText.text = "Clear area";
            timerText.color = Color.red;
        }
        else if (other.gameObject == targetObject && !countdownAudioPlayed)
        {
            StartCoroutine(PlayAudioWithDelay(countdown, 1f)); // 播放音频并延迟1秒
            timerText.color = Color.white;
            isCountingDown = true;
            timerText.enabled = true; // 当特定 GameObject 进入触发区域，显示计时器
            countdownAudioPlayed = true; // 标记音频已经播放
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            audioSource.Stop();
            isCountingDown = false;
            timerText.enabled = false; // 当特定 GameObject 离开触发区域，隐藏计时器
            timer = countdownTime; // 重置计时器
            countdownAudioPlayed = false; // 重置音频播放标记
        }
    }

    private IEnumerator PlayAudioWithDelay(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定的时间
        if (audioSource != null && clip != null)
        {
            audioSource.Stop(); // 停止当前播放的音频
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
