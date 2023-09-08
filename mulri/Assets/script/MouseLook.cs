using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    private UIManager uiManager;
    private float rotationX = 0;

    //private bool isSwitchOn = false;
    //public GameObject Switch;
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ... (이전 코드)

    private void Update()
    {
        if (!uiManager.UIactive) // UI가 활성화되지 않은 상태에서만 마우스 움직임 처리
        {
            float rotationY = Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = Mathf.Clamp(rotationX, -90, 90);

            transform.parent.Rotate(0, rotationY, 0);
            transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }

        
    }
}