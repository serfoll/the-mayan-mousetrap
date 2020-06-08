using UnityEngine;

public class TrapsController : MonoBehaviour
{


    public int damage;
    public AudioManager audioManager;
    public GameManager gameManager;
    public TrapManager trapManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Axe"))
        {
            damage = 100;
            gameManager.TakeDamage(damage);
            //audioManager.PlayOneShot("Die");

            Debug.Log(damage);
        }

        if(other.CompareTag("Player") && gameObject.CompareTag("NeedleTrap"))
        {
            damage = 15;
            trapManager.ActivateNeedle(damage, gameObject);
            audioManager.PlayOneShot("Grunt");
            Debug.Log(audioManager.sounds);

        }

        if (other.CompareTag("Player") && gameObject.CompareTag("SawBlade"))
        {
            damage = 40;
            audioManager.PlayOneShot("Grunt");
            gameManager.TakeDamage(damage);
        }
    }
}
