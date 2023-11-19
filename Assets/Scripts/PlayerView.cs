using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _bestScoreTMP;

    [SerializeField] private GameObject _gameOverUI;
    private void Start()
    {
        _gameOverUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        _scoreTMP.text = GameManager.Score.ToString();
        _bestScoreTMP.text = GameManager.BestScore.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SaveResults.Save();
        GameManager.Score = 0;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SaveResults.Save();
        GameManager.Nickname = "";
        GameManager.Score = 0;
        GameManager.BestScore = 0;
    }
}