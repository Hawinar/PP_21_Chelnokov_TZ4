    using UnityEngine;

    public class ArcController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private void Start()
        {
            float rotation = Random.Range(0, 360);
            _rigidbody2D.SetRotation(rotation);
        }

        private void Update()
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.5f * Time.deltaTime, transform.localScale.y - 0.5f * Time.deltaTime);
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
                    if (GameManager.BestScore < GameManager.Score)
                        GameManager.BestScore = GameManager.Score;
                    break;
            }
        }
    }