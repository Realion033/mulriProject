using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 기능을 사용하기 위해 추가

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
        if (other.CompareTag("Player")) // 다른 객체가 "Player" 태그를 가지고 있다고 가정
        {
    
            gameObject.SetActive(false); // 현재 코인을 비활성화
            uimaa.Problem();
            uimaa.DecreaseCoinCount();
        }
            
    }

    // Start is called before the first frame update

    // Update is called once per frame
}
