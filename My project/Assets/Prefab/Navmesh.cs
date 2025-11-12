using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabEnemies;
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
            int randomIndex = Random.Range(0, navMeshData.vertices.Length);
            Vector2 randomPoint = navMeshData.vertices[randomIndex];

            int randomenemyIndex = Random.Range(0, prefabEnemies.Count);
            Instantiate(prefabEnemies[randomenemyIndex], randomPoint, Quaternion.identity);
        }
    }
}
