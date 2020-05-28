using System.Collections;
using UnityEngine;

public class CharacterConditionController : MonoBehaviour
{
    public CharacterCondition characterCondition;

    public int maxHealth = 100;
    public int maxStamina = 100;
    public int currentStamina;
    public int currentHealth;

    bool sprinting;

    WaitForSeconds regenTime = new WaitForSeconds(0.1f);
    Coroutine regen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina  = maxStamina;
        characterCondition.SetCharacterCondition(maxHealth, maxStamina);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
            characterCondition.SetHealth(currentHealth);
        }
    }

    void TakeDamage(int d)
    {
        currentHealth -= d;
    }

    public void HealthUp()
    {
        currentHealth += 30;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        characterCondition.SetHealth(currentHealth);
    }

    public void StaminaDrain()
    {
        if (regen != null)
            StopCoroutine(regen);

        sprinting = true;
        StartCoroutine(UsingStamina());
    }

    public void StaminaRegen()
    {
        sprinting = false;
        regen = StartCoroutine(RegenerateStamina());
    }

  

    IEnumerator UsingStamina()
    {
        yield return new WaitForSeconds(0.7f);
        
        while(currentStamina > 0 && sprinting)
        {
            currentStamina -= maxStamina / 100;
            characterCondition.SetStamina(currentStamina);
            yield return regenTime;
        }
    }// end IEnumerator UsingStamina()

    IEnumerator RegenerateStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            characterCondition.SetStamina(currentStamina);
            yield return regenTime;
        }
        regen = null;
    }// end IEnumerator RegenerateStamina()
}
