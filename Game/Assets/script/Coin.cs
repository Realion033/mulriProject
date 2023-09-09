using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ����� ����ϱ� ���� �߰�

public class Coin : MonoBehaviour
{
    public UIManager uimaa;

    public AudioClip audio;
    private AudioSource aaaa;
    void Start()
    {
        uimaa = FindObjectOfType<UIManager>();
        aaaa = GetComponent<AudioSource>();

        aaaa.clip = audio;
        aaaa.playOnAwake = false;
    }
    
    void Awake()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �ٸ� ��ü�� "Player" �±׸� ������ �ִٰ� ����
        {
            aaaa.Play();
            gameObject.SetActive(false); // ���� ������ ��Ȱ��ȭ
            uimaa.Problem();
            uimaa.DecreaseCoinCount();
        }
            
    }

    // Start is called before the first frame update

    // Update is called once per frame
}
