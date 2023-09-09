using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class OXQuestion
{
    public string questionText; // OX ���� �ؽ�Ʈ
    public bool isCorrect; // ���� ���� (true: O, false: X)
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
                // EscPanel�� Ȱ��ȭ�� �� ���콺 Ŀ���� Ȱ��ȭ�ϰ� ���� ����
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                // EscPanel�� ��Ȱ��ȭ�� �� ���콺 Ŀ���� ��Ȱ��ȭ�ϰ� ����
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
        // ������ ��Ȱ��ȭ
    }

    public void ShowRandomOXQuestion()
    {
        if (remainingCoins > 0)
        {
            // �̹� ������ ������ ������ ���� ��� ����
            List<OXQuestion> availableQuestions = oxQuestions.Except(usedQuestions).ToList();

            if (availableQuestions.Count > 0)
            {
                int randomIndex = Random.Range(0, availableQuestions.Count);
                OXQuestion randomQuestion = availableQuestions[randomIndex];

                usedQuestions.Add(randomQuestion);

                questionText.text = randomQuestion.questionText;

                // �� �κп��� ���� ���ο� ���� ó���� �� �� �ֽ��ϴ�.
                // ���� ���, randomQuestion.isCorrect�� Ȯ���Ͽ� �������� ���θ� �˷��ְ�,
                // �׿� ���� ���� ���� ������ �� �ֽ��ϴ�.
            }
            else
            {
                // ��� ������ ǥ������ �� ó�� (��: ���� ���� �Ǵ� �ʱ�ȭ)
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
        coinText.text = "���� ���� : " + remainingCoins;
        if (remainingCoins == 0)
        {
            exit.SetActive(true);
            coinText.text = "Ż�ⱸ�� ���Ƚ��ϴ�!";
            ms.IncreaseSpeed();
        }
    }

    // �̺�Ʈ �ڵ鷯: O ��ư�� ������ �� ȣ��˴ϴ�.
    public void OnOButtonClicked()
    {
        bool isCorrect = GetCurrentQuestionIsCorrect();
        // ���� Ȯ��
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CheckAnswer(isCorrect);
        ProblemPanel.SetActive(false);
        Time.timeScale = 1;
        // ������ Ȱ��ȭ
    }

    public void OnXButtonClicked()
    {
        bool isCorrect = !GetCurrentQuestionIsCorrect();
        // ���� Ȯ��
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CheckAnswer(isCorrect);
        ProblemPanel.SetActive(false);
        Time.timeScale = 1;
        // ������ Ȱ��ȭ
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
            // ���� ó��: ���� ���, ������ �ø��ų� ���� �ܰ�� �����մϴ�.
            Debug.Log("����!");
            ooo.enabled = true;

            // 2�� �Ŀ� ���� UI ��Ȱ��ȭ
            Invoke("HideCorrectUI", 2.0f);
        }
        else
        {
            // ���� ó��: ���� ���, ���� ���� ȭ���� ǥ���ϰų� �ٽ� �õ��� �� �ֵ��� �մϴ�.
            Debug.Log("����!");
            ms.IncreaseSpeed();
            xxx.enabled = true;

            // 2�� �Ŀ� ���� UI ��Ȱ��ȭ
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
