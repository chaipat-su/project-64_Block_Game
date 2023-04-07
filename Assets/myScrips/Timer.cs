using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startTime;
    public TextMeshProUGUI[] timerText;
    private float elapsedTime = 0f;
    private bool isTimerEnded = false;

    void Start()
    {
        GameObject[] timeObjects = GameObject.FindGameObjectsWithTag("Time");
        timerText = timeObjects.Select(t => t.GetComponent<TextMeshProUGUI>()).ToArray();
        foreach (TextMeshProUGUI t in timerText)
        {
            t.SetText("Time: 00:00");
        }
        startTime = 300;
    }

    void Update()
    {
        if (!isTimerEnded)
        {
            elapsedTime = Time.timeSinceLevelLoad;
            float remainingTime = startTime - elapsedTime;
            string minutes = Mathf.Floor(remainingTime / 60).ToString("00");
            string seconds = Mathf.Floor(remainingTime % 60).ToString("00");
            string timeString = "Time: " + minutes + ":" + seconds;
            foreach (TextMeshProUGUI t in timerText)
            {
                t.text = timeString;
            }
            if (remainingTime <= 30)
            {
                foreach (TextMeshProUGUI t in timerText)
                {
                    t.color = Color.red;
                }
            }
            if (remainingTime <= 0)
            {
                isTimerEnded = true;
                Debug.Log("Time's up!");
                foreach (TextMeshProUGUI t in timerText)
                    {
                        t.SetText("Time: 00:00");
                    }
                    SceneManager.LoadScene(13);
                // draw
            }
        }
    }
}
