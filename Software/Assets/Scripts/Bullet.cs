
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    private float currentLifetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        currentLifetime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= maxLifeTime)
        {
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            AsteroidFragmentation ast = collision.gameObject.GetComponent<AsteroidFragmentation>();
            if (ast != null)
            {
                ast.Shatter(targetVector);
            }
            else
            {
                Destroy(collision.gameObject);
            }
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<TextMeshProUGUI>().text = "SCORE: " + Player.SCORE; 
    }
}
