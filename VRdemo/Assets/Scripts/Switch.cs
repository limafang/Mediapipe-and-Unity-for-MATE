using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        exe = new Process();
        f = new Handler(StarGame);
        exe.StartInfo = new ProcessStartInfo(mediapipe_exe_path, arguments);
    }

    // Update is called once per frame
    void Update()
    {

    }

    string mediapipe_exe_path = @".\dist\main.exe";
    string arguments = "--connect";
    Process exe;

    public void OnClick() {
        f();
    }
    
    private delegate void Handler();
    public TextMeshProUGUI Text;
    private void StarGame() {
        Text.text = "End";
        UnityEngine.Debug.Log("Start");

        exe.Start();

        f = new Handler(EndGame);
    }

    private void EndGame() {
        Text.text = "Start";
        UnityEngine.Debug.Log("End");

        exe.Kill();
        Application.Quit();
        f = new Handler(StarGame);
    }

    private Handler f;
}
