using UnityEngine;
using UnityEngine.UI;

public class CharacterCondition : MonoBehaviour
{
    public Slider healthSlider;
    public Slider staminaSlider;
    public Gradient healthGradient;
    public Image healthFill;

    public void SetCharacterCondition(int health, int stamina)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        healthFill.color = healthGradient.Evaluate(1f);

        staminaSlider.maxValue = stamina;
        staminaSlider.value = stamina;

    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;

        healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }

    public void SetStamina(int stamina)
    {
        staminaSlider.value = stamina;
        
    }
}

