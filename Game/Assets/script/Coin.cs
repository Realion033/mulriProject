using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ����� ����ϱ� ���� �߰�

public class Coin : MonoBehaviour
{
    public UIManager uimaa;

    
    void Start()
    {
        uimaa = FindObjectOfType<UIManager>();
        

    }
    
    void Awake()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �ٸ� ��ü�� "Player" �±׸� ������ �ִٰ� ����
        {
    
            gameObject.SetActive(false); // ���� ������ ��Ȱ��ȭ
            uimaa.Problem();
            uimaa.DecreaseCoinCount();
        }
            
    }

    // Start is called before the first frame update

    // Update is called once per frame
}
