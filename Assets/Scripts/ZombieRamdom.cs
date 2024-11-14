using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombiePrefabs; // Array de prefabs de zombis
    public float spawnRadius = 20f;    // Radio donde se generarán los zombis
    public float spawnInterval = 6f;   // Intervalo entre apariciones
    public int maxZombies = 1;         // Número máximo de zombis a generar

    public void Spawnear()
    {
        StartCoroutine(SpawnZombies());
    }

    private System.Collections.IEnumerator SpawnZombies()
    {
        for (int i = 0; i < maxZombies; i++)
        {
            // Elige un prefab de zombi aleatorio del array
            GameObject zombiePrefab = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
            
            // Genera la posición aleatoria dentro del radio de spawn
            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius), 
                0f, 
                Random.Range(-spawnRadius, spawnRadius)
            );

            // Instancia el zombi en la posición generada
            GameObject zom = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

            zom.GetComponent<NavMeshAgent>().enabled = true;

            // Espera un intervalo antes de generar el siguiente zombi
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
