using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Text tipText; // 팁을 표시할 Text UI 컴포넌트

    public string[] tips; // 여기에 팁을 저장할 배열을 만듭니다.

    private void Start()
    {
        // 팁 텍스트 초기화
        UpdateTipText();
    }

    // 랜덤한 팁을 가져오는 함수
    private string GetRandomTip()
    {
        if (tips.Length == 0)
        {
            return "No tips available.";
        }

        int randomIndex = Random.Range(0, tips.Length);
        return tips[randomIndex];
    }

    // 팁 텍스트 업데이트 함수
    private void UpdateTipText()
    {
        string randomTip = GetRandomTip();
        tipText.text = "Tip: " + randomTip;
    }
}
