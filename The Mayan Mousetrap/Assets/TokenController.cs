using UnityEngine;

public class TokenController : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && gameObject.tag == "HealthToken")
        {
            FindObjectOfType<CharacterConditionController>().HealthUp();
            Debug.Log(gameObject);

            Destroy(gameObject);
        }
    }
}
