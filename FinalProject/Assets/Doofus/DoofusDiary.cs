using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class DoofusDiary : MonoBehaviour
{
    public static DoofusDiary Instance { get; private set; }
    public DoofusDiaryData data {  get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json"))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string jsonData = webRequest.downloadHandler.text;
                data = JsonUtility.FromJson<DoofusDiaryData>(jsonData);
            }
            else
            {
                Debug.LogError("Error: " + webRequest.error);
            }
        }
    }
}

[System.Serializable]
public class DoofusDiaryData
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}


