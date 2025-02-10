using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {
    private GUIStyle buttonStyle, titleStyle;
    // Use this for initialization
    void Start() {
        buttonStyle = new GUIStyle();
        buttonStyle.normal.textColor = Color.white;
        buttonStyle.fontSize = 75;
        buttonStyle.alignment = TextAnchor.MiddleCenter; 
        buttonStyle.padding = new RectOffset(20, 20, 20, 20);

        titleStyle = new GUIStyle();
        titleStyle.normal.textColor = Color.white;
        titleStyle.fontSize = 200;
        titleStyle.alignment = TextAnchor.MiddleCenter; 
    }

    // Update is called once per frame
    void Update() {
    }

    void OnGUI() {
        // title
        GUI.Label(new Rect(0, 75, Screen.width, 100), "Asteroids", titleStyle);

        GUILayout.BeginArea(new Rect(10, Screen.height / 2 + 100, Screen.width - 10, 300));
        // Load the main scene
        // The scene needs to be added into build setting to be loaded!
        if (GUILayout.Button("New Game", buttonStyle)) {
            SceneManager.LoadScene("GameplayScene");
        }
        // if (GUILayout.Button("High Score", buttonStyle)) {
        //     Debug.Log("You should implement a high score screen.");
        // }
        if (GUILayout.Button("Exit", buttonStyle)) {
            Application.Quit();
            Debug.Log("Application.Quit() only works in build, not in editor");
        }
        GUILayout.EndArea();
    }
}
