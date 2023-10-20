using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(MainMenu), 38);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
