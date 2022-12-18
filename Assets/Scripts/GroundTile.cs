using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] GameObject tallobstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f;

    [SerializeField] GameObject flyingobstaclePrefab;
    [SerializeField] float flyingObstacleChance = 0.3f;
    
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject,2);
    }

    public void SpawnObstacle()
    {
        //choose which obstacle to spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
            if(random < tallObstacleChance){
                obstacleToSpawn =tallobstaclePrefab;
            } else if (random < flyingObstacleChance){
                obstacleToSpawn = flyingobstaclePrefab;
            }

        //choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn the obstacle at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins(){
        int coinsToSpawn = 10;
        for(int i = 0; i<coinsToSpawn;i++){
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        //failsafe incase a point is accidentally called outside of the collider
        //this hopefully shouldnt be used
        if(point != collider.ClosestPoint(point)){
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }
}
