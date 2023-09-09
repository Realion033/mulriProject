using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public List<string> questions; // 5���� ������ ������ ����Ʈ
    private List<string> usedQuestions = new List<string>(); // �̹� ������ ������ �����ϴ� ����Ʈ

    void Start()
    {
        // �ʱ� ���� ����Ʈ�� ���� �߰� (��: "���� 1", "���� 2", ... "���� 5")
        questions.Add("���� 1");
        questions.Add("���� 2");
        questions.Add("���� 3");
        questions.Add("���� 4");
        questions.Add("���� 5");

        // ���� ���� ����
        for (int i = 0; i < 5; i++)
        {
            string randomQuestion = GetRandomQuestion();
            Debug.Log("������ ���� " + (i + 1) + ": " + randomQuestion);
        }
    }

    string GetRandomQuestion()
    {
        if (questions.Count == 0)
        {
            Debug.LogWarning("�� �̻� ������ �����ϴ�.");
            return "";
        }

        // ������ ���� ����
        int randomIndex = Random.Range(0, questions.Count);
        string randomQuestion = questions[randomIndex];

        // �̹� ������ �������� Ȯ���ϰ�, ������ ������ ����
        if (!usedQuestions.Contains(randomQuestion))
        {
            usedQuestions.Add(randomQuestion);
        }

        questions.RemoveAt(randomIndex);

        return randomQuestion;
    }
}
