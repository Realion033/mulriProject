using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class OXQuestion
{
    public string questionText; // OX 문제 텍스트
    public bool isCorrect; // 정답 여부 (true: O, false: X)
}

public class UIManager : MonoBehaviour
{
    public MonsterController ms;
    public bool isMovementEnabled = true;
    public GameObject EscPanel;
    public GameObject ProblemPanel;
    public GameObject exit;
    public Text coinText;
    public Text ooo;
    public Text xxx;
    private int remainingCoins = 5;

    public List<OXQuestion> oxQuestions = new List<OXQuestion>();
    public Text questionText;
    private List<OXQuestion> usedQuestions = new List<OXQuestion>();

    private bool isUIActive = false;

    void Start()
    {
        ms = FindObjectOfType<MonsterController>();
        EscPanel.SetActive(false);
        ProblemPanel.SetActive(false);
        UpdateCoinText();
        ooo.enabled = false;
        xxx.enabled = false;
    }

    void Update()
    {
        EscPanelSet();
    }

    public void EscPanelSet()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isUIActive = !isUIActive;
            EscPanel.SetActive(isUIActive);

            if (isUIActive)
            {
                // EscPanel이 활성화될 때 마우스 커서를 활성화하고 고정 해제
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                // EscPanel이 비활성화될 때 마우스 커서를 비활성화하고 고정
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }


    public void Problem()
    {
        ProblemPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ShowRandomOXQuestion();
        Time.timeScale = 0;
        // 움직임 비활성화
    }

    public void ShowRandomOXQuestion()
    {
        if (remainingCoins > 0)
        {
            // 이미 선택한 문제를 제외한 문제 목록 생성
            List<OXQuestion> availableQuestions = oxQuestions.Except(usedQuestions).ToList();

            if (availableQuestions.Count > 0)
            {
                int randomIndex = Random.Range(0, availableQuestions.Count);
                OXQuestion randomQuestion = availableQuestions[randomIndex];

                usedQuestions.Add(randomQuestion);

                questionText.text = randomQuestion.questionText;

                // 이 부분에서 정답 여부에 따라 처리를 할 수 있습니다.
                // 예를 들어, randomQuestion.isCorrect를 확인하여 정답인지 여부를 알려주고,
                // 그에 따라 코인 등을 조작할 수 있습니다.
            }
            else
            {
                // 모든 문제를 표시했을 때 처리 (예: 게임 종료 또는 초기화)
            }
        }
    }

    public void DecreaseCoinCount()
    {
        if (remainingCoins > 0)
        {
            remainingCoins--;
            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = "남은 문제 : " + remainingCoins;
        if (remainingCoins == 0)
        {
            exit.SetActive(true);
            coinText.text = "탈출구가 열렸습니다!";
            ms.IncreaseSpeed();
        }
    }

    // 이벤트 핸들러: O 버튼을 눌렀을 때 호출됩니다.
    public void OnOButtonClicked()
    {
        bool isCorrect = GetCurrentQuestionIsCorrect();
        // 정답 확인
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CheckAnswer(isCorrect);
        ProblemPanel.SetActive(false);
        Time.timeScale = 1;
        // 움직임 활성화
    }

    public void OnXButtonClicked()
    {
        bool isCorrect = !GetCurrentQuestionIsCorrect();
        // 정답 확인
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CheckAnswer(isCorrect);
        ProblemPanel.SetActive(false);
        Time.timeScale = 1;
        // 움직임 활성화
    }

    private bool GetCurrentQuestionIsCorrect()
    {
        OXQuestion currentQuestion = usedQuestions.LastOrDefault();
        if (currentQuestion != null)
        {
            return currentQuestion.isCorrect;
        }
        return false;
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            // 정답 처리: 예를 들어, 점수를 올리거나 다음 단계로 진행합니다.
            Debug.Log("정답!");
            ooo.enabled = true;

            // 2초 후에 정답 UI 비활성화
            Invoke("HideCorrectUI", 2.0f);
        }
        else
        {
            // 오답 처리: 예를 들어, 게임 오버 화면을 표시하거나 다시 시도할 수 있도록 합니다.
            Debug.Log("오답!");
            ms.IncreaseSpeed();
            xxx.enabled = true;

            // 2초 후에 오답 UI 비활성화
            Invoke("HideWrongUI", 2.0f);
        }
    }

    private void HideCorrectUI()
    {
        ooo.enabled = false;
    }

    private void HideWrongUI()
    {
        xxx.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
