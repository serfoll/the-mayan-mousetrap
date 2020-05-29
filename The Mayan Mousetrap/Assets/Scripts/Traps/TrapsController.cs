using UnityEngine;

public class TrapsController : MonoBehaviour
{

    public int damage;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damage = 100;
            gameManager.TakeDamage(damage);
            Debug.Log("U dead");
        }
    }
}
