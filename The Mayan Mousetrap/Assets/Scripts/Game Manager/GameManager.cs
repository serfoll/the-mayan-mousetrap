using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelComplete levelComplete;
    public TimerControl timerCtrl;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (levelComplete.finished)
        {
            timerCtrl.timerStop = true;
        }
    }
}
