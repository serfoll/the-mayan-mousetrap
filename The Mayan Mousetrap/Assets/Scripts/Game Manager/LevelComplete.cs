using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject finalFlame;

    public bool finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finished = true;
            finalFlame.SetActive(true);
        }
    }
}
