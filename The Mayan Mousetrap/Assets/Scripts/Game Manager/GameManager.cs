using System.Xml.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelComplete levelComplete;
    public TimerControl timerCtrl;
    public TrapsController trapsCtrl;
    public CharacterCondition characterCondition;
    public CharacterConditionController characterConditionCtrl;

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

    public void TakeDamage(int d)
    {
        characterConditionCtrl.currentHealth -= d;
        characterCondition.healthSlider.value = characterConditionCtrl.currentHealth;
        Debug.Log(characterConditionCtrl.currentHealth);
    }
}
