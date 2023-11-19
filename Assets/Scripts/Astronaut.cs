using UnityEngine;

public class Astronaut : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Planet"))
        {
            _gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}