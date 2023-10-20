using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).buildIndex+1);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quit");
    }
}
