using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject EscPanel;
    public GameObject ProblemPanel;
    public bool UIactive = false;

    // Start is called before the first frame update
    void Start()
    {
        EscPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EscPanelSet();
    }

    public void EscPanelSet()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (UIactive)
            {
                EscPanel.SetActive(false);
                UIactive = false;
                Cursor.visible = false;
            }
            else
            {
                EscPanel.SetActive(true);
                UIactive = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void Problem()
    {
        ProblemPanel.SetActive(true);
    }
}