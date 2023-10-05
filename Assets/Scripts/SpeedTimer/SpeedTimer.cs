using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpeedTimer : MonoBehaviour
{
    private TMP_Text _text;
    private float timer;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _text = GetComponentInChildren<TMP_Text>();
    }
    

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex is 1 or 2 or 3)
        {
            timer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
        
        //print(timer);
        _text.text = System.Math.Round(timer, 2).ToString(CultureInfo.InvariantCulture);
    }
}
