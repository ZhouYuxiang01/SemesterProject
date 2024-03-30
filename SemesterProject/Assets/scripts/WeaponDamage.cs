using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damageAmount = 10; // 武器的伤害值

    // 当武器的触发器碰到其他触发器时调用
    private void OnTriggerEnter(Collider other)
    {
        // 检查碰撞的对象是否有Enemy标签
        if (other.CompareTag("Enemy"))
        {
            // 尝试获取敌人的健康组件
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // 对敌人造成伤害
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }
}