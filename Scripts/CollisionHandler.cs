using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject playerVFX;

    private void OnTriggerEnter(Collider other) {
        FindFirstObjectByType<GameSceneManager>().Initiate();
        Destroy(gameObject);
        Instantiate(playerVFX, transform.position, Quaternion.identity);
    }
 
}
