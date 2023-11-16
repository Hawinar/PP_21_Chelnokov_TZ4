using UnityEngine;

public class ArcController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        float size = Random.Range(0.1f, 1f);
        transform.localScale = new Vector3(size, size);
        float rotation = Random.Range(0, 360);
        _rigidbody2D.SetRotation(rotation);
    }

    private void Update()
    {
        _rigidbody2D.transform.position = Vector3.Lerp(_rigidbody2D.position, new Vector3(0, 0, 0), Time.deltaTime * 0.05f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Planet":
                Destroy(this.gameObject);
                GameManager.Score++;
                break;
            case "Player":
                Destroy(collision.gameObject);
                if (GameManager.BestScore < GameManager.Score)
                    GameManager.BestScore = GameManager.Score;
                break;
        }
    }
}