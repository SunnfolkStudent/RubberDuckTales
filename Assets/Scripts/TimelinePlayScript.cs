using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelinePlayScript : MonoBehaviour
{
    public PlayableDirector playableDirector;

    private float _timer;
    private bool _timerOn = false;
    private void Update()
    {
        if (_timerOn)
        {
            _timer += Time.deltaTime;
            if (_timer > 4f)
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playableDirector.Play();
        _timerOn = true;
    }
}


