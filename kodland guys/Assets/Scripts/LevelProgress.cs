using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    // Pozycja triggera startowego
    [SerializeField] Transform startPoint;
    // Pozycja triggera końcowego
    [SerializeField] Transform finishPoint;
    // Odniesienie do obrazu wypełniającego pasek postępu
    [SerializeField] Image progressBar;
    // Zmienna do przechowywania długości poziomu
    float levelLength;
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    bool timerRunning = false;
    float timer = 0f;
    float levelLenght;
    // Referencja do tekstu rekordu
[SerializeField] TextMeshProUGUI bestTimeText;
    // Zmienna dla rekordu
    float bestTime = Mathf.Infinity;
    void Start()
    {
        levelLength = finishPoint.position.z - startPoint.position.z;
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
        else
        {
            bestTimeText.text = "Best Time: --";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = transform.position.z - startPoint.position.z;
        float progress = Mathf.Clamp01(distance / levelLength);
        progressBar.fillAmount= progress;

        if(timerRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "Time:" + timer.ToString("F2");
             
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("BestTime");
            bestTime = Mathf.Infinity;
            bestTimeText.text = ("BestTime:--");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start") && !timerRunning)
        {
            timerRunning = true;
        }

        if (other.CompareTag("Finish") && timerRunning)
        {
            timerRunning = false;
            if( timer < bestTime)
            {
                bestTime = timer;
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save();
                bestTimeText.text = "BestTime:   " + bestTime.ToString("F2");

            }
        }
    }
}
