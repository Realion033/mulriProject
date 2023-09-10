using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Text tipText; // ���� ǥ���� Text UI ������Ʈ

    public string[] tips; // ���⿡ ���� ������ �迭�� ����ϴ�.

    private void Start()
    {
        // �� �ؽ�Ʈ �ʱ�ȭ
        UpdateTipText();
    }

    // ������ ���� �������� �Լ�
    private string GetRandomTip()
    {
        if (tips.Length == 0)
        {
            return "No tips available.";
        }

        int randomIndex = Random.Range(0, tips.Length);
        return tips[randomIndex];
    }

    // �� �ؽ�Ʈ ������Ʈ �Լ�
    private void UpdateTipText()
    {
        string randomTip = GetRandomTip();
        tipText.text = "Tip: " + randomTip;
    }
}
