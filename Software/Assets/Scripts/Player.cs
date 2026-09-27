
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 5f;
    public float rotationSpeed = 10f;
    public GameObject gun, bulletPrefab;
    private Rigidbody _rigid;

    public static int SCORE = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector3 thrustDirection = transform.right;
        _rigid.AddForce(thrustDirection * thrust * thrustForce);
        transform.Rotate(Vector3.forward, rotation * rotationSpeed);

        Camera cam = Camera.main;
        float verticalHeight = cam.orthographicSize;
        float horizontalWidth = verticalHeight * cam.aspect;
        float margen = 1f;
        Vector3 newPos = transform.position;
        if (newPos.x > horizontalWidth + margen)
        {
            newPos.x = -horizontalWidth -margen + 0.5f;
        }
        else if (newPos.x < -horizontalWidth -margen)
        {
            newPos.x = horizontalWidth +margen -0.5f;
        }
        else if (newPos.y > verticalHeight +margen)
        {
            newPos.y = -verticalHeight -margen +0.5f;
        }
        else if (newPos.y < -verticalHeight -margen)
        {
            newPos.y = verticalHeight +margen -0.5f;
        }
        transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("Colision con otra cosa");
        }
    }
}
