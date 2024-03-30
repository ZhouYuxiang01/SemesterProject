using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTreeColliders : MonoBehaviour
{
    public Terrain terrain; // 指定地形
    public float colliderHeight = 2.0f; // 碰撞体的高度

    void Start()
    {
        foreach (TreeInstance tree in terrain.terrainData.treeInstances)
        {
            Vector3 treePosition = Vector3.Scale(tree.position, terrain.terrainData.size) + terrain.transform.position;
            GameObject treeCollider = new GameObject("TreeCollider");
            treeCollider.transform.position = treePosition;
            treeCollider.transform.parent = terrain.transform;

            CapsuleCollider collider = treeCollider.AddComponent<CapsuleCollider>();
            collider.height = colliderHeight;
            collider.center = new Vector3(0, colliderHeight / 2, 0);
            collider.radius = 0.5f; // 根据实际情况调整碰撞体的半径
        }
    }
}