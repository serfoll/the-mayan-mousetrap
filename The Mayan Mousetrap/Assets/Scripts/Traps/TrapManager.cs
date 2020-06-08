using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public Animator needleAnimator;
    public GameManager gameManager;

    public void ActivateNeedle(int d, GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().SetBool("Active", true);
        gameManager.TakeDamage(d);
        Debug.Log("U been spiked");
    }
}
