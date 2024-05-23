using UnityEngine;
using MoreMountains.TopDownEngine;

public class ChangeAIDistanceOnTrigger : MonoBehaviour
{
    public float newDistance = 10f; // The new distance value you want to set

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeEnemyAIDistance(newDistance);
        }
    }

    private void ChangeEnemyAIDistance(float distance)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            AIDecisionDetectTargetRadius3D aiDecision = enemy.GetComponent<AIDecisionDetectTargetRadius3D>();

            if (aiDecision != null)
            {
                aiDecision.Radius = distance;
            }
        }
    }
}
