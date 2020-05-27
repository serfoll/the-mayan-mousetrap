using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public Text timerText;
    private float startTimer;
    public bool timerStop;

    // Start is called before the first frame update
    void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStop)
            return;

        float t = Time.time - startTimer;

        string minutes = ((int) t / 60).ToString("00");

        string  seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }
}
