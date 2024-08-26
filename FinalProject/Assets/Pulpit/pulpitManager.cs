using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pulpitManager : MonoBehaviour
{
    [SerializeField] GameObject pulpitPrefab;

    List<GameObject> pulpitList = new List<GameObject>();
    public bool canSpawnPulpit = true;
    public Vector3 spawnPoint;

    public int score;

    [SerializeField] TMP_Text scoreText;


    private void Awake()
    {
        spawnPulpit();
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();

        pulpitList.RemoveAll(pulpit => pulpit == null);

        // Only 2 pulpits can spawn at a time
        if (pulpitList.Count < 2 && canSpawnPulpit)
        {
            spawnPulpit();
        }
    }

    void spawnPulpit()
    {
        GameObject newPulpit = Instantiate(pulpitPrefab, spawnPoint, Quaternion.identity);
        pulpitList.Add(newPulpit);
        canSpawnPulpit = false;
    }
}