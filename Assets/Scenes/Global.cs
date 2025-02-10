using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Global : MonoBehaviour {
    public GameObject objToSpawn;
    public float timer;
    public float spawnPeriod;
    public int numberSpawnedEachPeriod;
    public Vector3 originInScreenCoords;
    public int score;
    // Use this for initialization
    void Start() {
        score = 0;
        timer = -1;
        spawnPeriod = 3.0f;
        numberSpawnedEachPeriod = 3;
        originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
    }
    void Update() {
        if (timer > spawnPeriod || timer == -1) {
            timer = 0;
            float width = Screen.width;
            float height = Screen.height;
            for (int i = 0; i < numberSpawnedEachPeriod; i++) {
                float horizontalPos = Random.Range(0.0f, width);
                float verticalPos = Random.Range(0.0f, height);
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(horizontalPos, verticalPos, originInScreenCoords.z));
                spawnPosition.y = 0;
                Instantiate(objToSpawn, spawnPosition, Quaternion.identity);
            }
        }
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}