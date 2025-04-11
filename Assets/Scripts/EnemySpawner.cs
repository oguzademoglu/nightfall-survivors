using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyWave
    {
        public EnemyData enemyData;
        public float spawnInterval = 2f;
        public int spawnCount = 5;
    }

    public EnemyWave[] waves;
    // public Transform[] spawnPoints;

    private int currentWave = 0;
    private float timer = 0f;
    private int spawnedInWave = 0;

    Vector2 GetCameraBounds()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        return new Vector2(width, height);
    }

    Vector3 GetSpawnPositionOutsideCamera(float offset = 4f)
    {
        Vector2 camBounds = GetCameraBounds();
        Vector3 camPos = Camera.main.transform.position;

        // Kenarlardan birini seç (üst, alt, sol, sağ)
        int side = Random.Range(0, 4);
        Vector3 spawnPos = Vector3.zero;

        switch (side)
        {
            case 0: // Üst
                spawnPos = new Vector3(
                    camPos.x + Random.Range(-camBounds.x / 2f, camBounds.x / 2f),
                    camPos.y + camBounds.y / 2f + offset,
                    0f);
                break;

            case 1: // Alt
                spawnPos = new Vector3(
                    camPos.x + Random.Range(-camBounds.x / 2f, camBounds.x / 2f),
                    camPos.y - camBounds.y / 2f - offset,
                    0f);
                break;

            case 2: // Sol
                spawnPos = new Vector3(
                    camPos.x - camBounds.x / 2f - offset,
                    camPos.y + Random.Range(-camBounds.y / 2f, camBounds.y / 2f),
                    0f);
                break;

            case 3: // Sağ
                spawnPos = new Vector3(
                    camPos.x + camBounds.x / 2f + offset,
                    camPos.y + Random.Range(-camBounds.y / 2f, camBounds.y / 2f),
                    0f);
                break;
        }

        return spawnPos;
    }


    void Update()
    {
        if (currentWave >= waves.Length) return;

        timer += Time.deltaTime;
        EnemyWave wave = waves[currentWave];

        if (timer >= wave.spawnInterval && spawnedInWave < wave.spawnCount)
        {
            SpawnEnemy(wave.enemyData);
            timer = 0f;
            spawnedInWave++;
        }

        if (spawnedInWave >= wave.spawnCount)
        {
            // Wave tamamlandı → bir sonraki için bekleme veya otomatik geçiş yapılabilir
            currentWave++;
            spawnedInWave = 0;
        }
    }

    void SpawnEnemy(EnemyData data)
    {
        // int index = Random.Range(0, spawnPoints.Length);
        // Vector3 spawnPos = spawnPoints[index].position;
        Vector3 spawnPos = GetSpawnPositionOutsideCamera();

        GameObject enemyGO = Instantiate(data.prefab, spawnPos, Quaternion.identity);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Initialize(data);
    }
}

