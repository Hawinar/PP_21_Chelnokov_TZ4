using TMPro;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private TextMeshProUGUI _leaderboardTMP;
    private void Start()
    {
        _leaderboardTMP.text = "";
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetString($"Nickname_{i}") != "")
                _leaderboardTMP.text += $"{i + 1}. {PlayerPrefs.GetString($"Nickname_{i}")} - {PlayerPrefs.GetInt($"Score_{i}")}\n";
        }
        if (_leaderboardTMP.text == "")
            _leaderboardTMP.text = "��� ����� �� ����� � ��� ����.\n����� ����� ������!";
    }
    public void GoToMainMenu()
    {
        _mainUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}