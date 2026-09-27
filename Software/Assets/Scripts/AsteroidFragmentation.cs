using UnityEngine;
using UnityEngine.Rendering;

public class AsteroidFragmentation : MonoBehaviour
{
    public GameObject fragmentPrefab;
    public int numberOfFragments = 2;
    public float explosionForce = 300f;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    private float currentSpeed;
    private Vector3 moveDirection = Vector3.down;

    void Start()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    public void SetDirection (Vector3 dir)
    {
        moveDirection = dir;
    }

    public void Update()
    {
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
    }

    public void Shatter (Vector3 bulletDirection)
    {
        Vector3 dir = this.moveDirection;
        for (int i = 0; i < numberOfFragments; i++)
        {
            float angleOffset = (i == 0) ? 45f : -45f;
            Vector3 fragmentDirection = Quaternion.Euler(0, 0, angleOffset) * dir;
            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Quaternion.identity);
            FragmentMovement fragMove = fragment.GetComponent<FragmentMovement>();
        
            if (fragMove != null)
            {
                fragMove.SetDirection(fragmentDirection);
            }
        }
        Destroy(gameObject);
    }
}
