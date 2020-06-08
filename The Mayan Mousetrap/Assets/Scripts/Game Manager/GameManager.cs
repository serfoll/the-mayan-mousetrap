using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStatus { Over, Complete }

    private GameStatus gameStatus;

    public AudioManager audioManager;

    public LevelComplete levelComplete;
    public TimerControl timerCtrl;
    public TrapsController trapsCtrl;
    public CharacterCondition characterCondition;
    public CharacterConditionController characterConditionCtrl;

    //GameComponents
    public GameObject gOUI, gCUI;

    bool restart;

    void Start()
    {
        audioManager.Play("Bg_Music");
    }

    // Update is called once per frame
    void Update()
    {
        if (levelComplete.finished)
        {
            StartCoroutine(LevelFinished());
        }

        if (characterConditionCtrl.currentHealth <= 0)
        {
            SetGameStatus(GameStatus.Over);
        }

        if (restart)
        {
            Time.timeScale = 1;
        }

    }

    public void TakeDamage(int d)
    {
        characterConditionCtrl.currentHealth -= d;
        characterCondition.healthSlider.value = characterConditionCtrl.currentHealth;
        Debug.Log(characterConditionCtrl.currentHealth);
        if(characterConditionCtrl.currentHealth <= 0)
        {
            audioManager.PlayOneShot("Die");
        }
    }

    public void SetGameStatus( GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Over:
                {
                    Time.timeScale = 0;
                    gOUI.SetActive(true);
                    break;
                }
            case GameStatus.Complete:
                {
                    Time.timeScale = 0;
                    gCUI.SetActive(true);
                    break;
                }
        }
    }

    public void RestartGame()
    {
        restart = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log(scene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LevelFinished()
    {
        yield return new WaitForSeconds(1f);
        timerCtrl.timerStop = true;
        SetGameStatus(GameStatus.Complete);
    }
}
