using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SaveResults
{
    public static void Save()
    {
        int limitedCount = 10; // ����� ������� ���-{limitedCount} �������

        List<ResultItem> results = new List<ResultItem>();

        // �������� ��� �� ������ PlayerPrefs
        for (int i = 0; i < limitedCount; i++)
        {
            if (PlayerPrefs.GetString($"Nickname_{i}") != "")
            {
                results.Add(new ResultItem() { nickname = PlayerPrefs.GetString($"Nickname_{i}"), score = PlayerPrefs.GetInt($"Score_{i}") });
            }
        }

        // ���������� 1
        results = results.OrderByDescending(x => x.score).ToList();

        RemoveDublicate();

        // ��������� ��������� �������� ������
        results.Add(new ResultItem() { nickname = GameManager.Nickname, score = GameManager.Score });

        //���������� 2
        results = results.OrderByDescending(x => x.score).ToList();

        RemoveDublicate();

        // ���������� ������.
        // � ���� ���������� 2 � ������� ����������,
        // ��������� ������ ����� � �� ������� � ������ �������, ���� ��������� �� �������������� ����������,
        // ��������, ������� ���� ����� �������.

        for (int i = results.Count - 1; i >= limitedCount; i--)
        {
            results.Remove(results[i]);
        }


        //��������� � PlayerPrefs
        for (int i = 0; i < results.Count; i++)
        {
            PlayerPrefs.SetString($"Nickname_{i}", results[i].nickname);
            PlayerPrefs.SetInt($"Score_{i}", results[i].score);
        }
        void RemoveDublicate()
        {
            // �� ��������� ���������� ���������, ��������� ������ ������ ��������� ������
            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 0; j < results.Count; j++)
                {
                    if (i != j && results[i].nickname == results[j].nickname)
                        results.Remove(results[j]);
                }
            }
        }
    }


    class ResultItem
    {
        public string nickname { get; set; }
        public int score { get; set; }
    }
}