using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100; // 主角的最大健康值
    private int currentHealth; // 主角的当前健康值
    private Animator animator; // 引用Animator组件

    void Start()
    {
        currentHealth = maxHealth; // 初始化时，主角的当前健康值等于最大健康值
        animator = GetComponent<Animator>(); // 获取Animator组件
    }

    void Update()
    {
        // 示例：使用按键触发行为和动画
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run();
        }

        // 添加更多按键检测来触发其他行为和动画
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt"); // 触发受击动画

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // 触发攻击动画
    }

    void Run()
    {
        animator.SetTrigger("Run"); // 触发跑步动画
    }

    // 添加其他行为的方法，例如Walk()和Die()

    void Die()
    {
        animator.SetTrigger("Die"); // 触发死亡动画
        // 实现死亡后的逻辑，例如禁用玩家控制
        Debug.Log("Player died.");
    }
}