using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pulpit : MonoBehaviour
{
    DoofusDiary dataManager;

    float currentTime;
    [SerializeField] float min_lifetime = 4;
    [SerializeField] float max_lifetime = 10;
    [SerializeField] float pulpit_spawn_timer = 2;

    pulpitManager manager;

    Vector3 nextSpawnPoint;

    public TMP_Text timerText;

    void Start()
    {
        // dataManager = GameObject.FindGameObjectWithTag("data").GetComponent<DoofusDiary>();
        // onCreation();

        // timerText = GetComponent<TMP_Text>();
        manager = GameObject.FindGameObjectWithTag("pulpitManager")?.GetComponent<pulpitManager>();
        currentTime = Random.Range(min_lifetime, max_lifetime);
    }

    void Update()
    {
        timerText.text = currentTime.ToString("F1");

        if (manager == null) return;

        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            Destroy(gameObject);
        }

        if (currentTime > 0 && currentTime < pulpit_spawn_timer)
        {
            pickRandomSpawnPoint();
            manager.spawnPoint = nextSpawnPoint;
            manager.canSpawnPulpit = true;
        }
    }

    void onCreation()
    {
        min_lifetime = DoofusDiary.Instance.data.pulpit_data.min_pulpit_destroy_time;
        max_lifetime = DoofusDiary.Instance.data.pulpit_data.max_pulpit_destroy_time;
        pulpit_spawn_timer = DoofusDiary.Instance.data.pulpit_data.pulpit_spawn_time;

        Debug.Log("Min lifetime data from JSON: " + min_lifetime);
        Debug.Log("Min lifetime data from JSON: " + min_lifetime);
        Debug.Log("Min lifetime data from JSON: " + min_lifetime);
    }

    void pickRandomSpawnPoint()
    {
        const float spawnOffset = 10f;
        List<Vector3> spawnPoints = new List<Vector3>();

        // Only spawn horizontally or vertically
        // x +- 10, z +- 10
        spawnPoints.Add(new Vector3(transform.position.x + spawnOffset, 0, transform.position.z));
        spawnPoints.Add(new Vector3(transform.position.x - spawnOffset, 0, transform.position.z));
        spawnPoints.Add(new Vector3(transform.position.x, 0, transform.position.z + spawnOffset));
        spawnPoints.Add(new Vector3(transform.position.x, 0, transform.position.z - spawnOffset));

        nextSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
}