using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombiePrefabs; // Array de prefabs de zombis
    public float spawnRadius = 10f;    // Radio donde se generarán los zombis
    public float spawnInterval = 2f;   // Intervalo entre apariciones
    public int maxZombies = 10;         // Número máximo de zombis a generar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el trigger se activó por un objeto específico, por ejemplo, el jugador
        if (other.CompareTag("HEROPLAYER"))
        {
            // Empieza a generar zombis al entrar al área del trigger
            StartCoroutine(SpawnZombies());
        }
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
            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

            // Espera un intervalo antes de generar el siguiente zombi
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
