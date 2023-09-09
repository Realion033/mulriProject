using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public List<string> questions; // 5개의 문제를 저장할 리스트
    private List<string> usedQuestions = new List<string>(); // 이미 선택한 문제를 추적하는 리스트

    void Start()
    {
        // 초기 문제 리스트에 문제 추가 (예: "문제 1", "문제 2", ... "문제 5")
        questions.Add("문제 1");
        questions.Add("문제 2");
        questions.Add("문제 3");
        questions.Add("문제 4");
        questions.Add("문제 5");

        // 문제 랜덤 선택
        for (int i = 0; i < 5; i++)
        {
            string randomQuestion = GetRandomQuestion();
            Debug.Log("선택한 문제 " + (i + 1) + ": " + randomQuestion);
        }
    }

    string GetRandomQuestion()
    {
        if (questions.Count == 0)
        {
            Debug.LogWarning("더 이상 문제가 없습니다.");
            return "";
        }

        // 랜덤한 문제 선택
        int randomIndex = Random.Range(0, questions.Count);
        string randomQuestion = questions[randomIndex];

        // 이미 선택한 문제인지 확인하고, 선택한 문제는 제거
        if (!usedQuestions.Contains(randomQuestion))
        {
            usedQuestions.Add(randomQuestion);
        }

        questions.RemoveAt(randomIndex);

        return randomQuestion;
    }
}
