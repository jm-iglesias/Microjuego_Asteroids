using UnityEngine;

public class FragmentMovement : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 moveDirection = Vector3.down;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 8f);
    }

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}
