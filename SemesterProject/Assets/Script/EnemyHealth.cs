using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // 敌人的最大健康值
    private int currentHealth; // 敌人的当前健康值

    void Start()
    {
        // 初始化时，敌人的当前健康值等于最大健康值
        currentHealth = maxHealth;
    }

    // 从外部调用以对敌人造成伤害
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // 如果健康值降到0或以下，敌人死亡
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 实现敌人死亡的逻辑，例如播放死亡动画，销毁对象等
        Debug.Log("Enemy died.");
        Destroy(gameObject); // 销毁敌人对象
    }
}