using UnityEngine;
using System.Collections;

public class SunSpawnear : MonoBehaviour
{
    [SerializeField]
    private LaneManager laneManager;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private float offsetY;
    [SerializeField]
    private GameObject sunPrefab;
    private bool IsActive;
    public void Activate(bool active)
    {
        IsActive = active;
        if(IsActive)
        {
            StartCoroutine(SpawnSuns());
        }
        else
        {
            StopCoroutine(SpawnSuns());
        }
    }
    private IEnumerator SpawnSuns()
    {
        while (IsActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            Lane lane = laneManager.GetRandomLane();
            Transform zone = lane.GetRandomZone();
            Vector3 spawnPosition = zone.position + new Vector3(0, offsetY, 0);
            PoolManager.Instance.GetObject(sunPrefab, spawnPosition);
        }
    }
    
}
