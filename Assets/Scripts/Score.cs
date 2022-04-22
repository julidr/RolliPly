using UnityEngine;

public class Score : MonoBehaviour
{
    public int value = 10;
    public GameObject explosionPrefab;
    public GameObject ballPrefab;
    public float minimumDistance = 1f;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameManager.gm != null)
            {
                GameManager.gm.Collect(value);
                GameManager.gm.addBall(ballPrefab, minimumDistance);
            }

            // Explodes if Specified
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // Destroy after Collection
            Destroy(gameObject);
        }
    }

}
