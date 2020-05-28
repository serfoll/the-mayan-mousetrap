using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public bool finished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finished = true;
            //Debug.Log(finished);
        }
    }
}
