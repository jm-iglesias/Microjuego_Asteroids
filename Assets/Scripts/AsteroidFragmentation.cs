using UnityEngine;

public class AsteroidFragmentation : MonoBehaviour
{
    public GameObject fragmentPrefab;
    public int numberOfFragments = 2;
    public float explosionForce = 300f;

    public void Shatter (Vector3 bulletDirection)
    {
        Vector3 incomingDir = bulletDirection.normalized;
        for (int i = 0; i < numberOfFragments; i++)
        {
            float angleOffset = (i == 0) ? 45f : -45f;
            Vector3 fragmentDirection = Quaternion.Euler(0, 0, angleOffset) * incomingDir;
            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = fragment.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(fragmentDirection * explosionForce);
            }
        }
        Destroy(gameObject);
    }
}
