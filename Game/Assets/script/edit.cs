using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class edit : MonoBehaviour
{
    public GameObject monster;
    public GameObject monstedr;

    public void exit()
    {
        Application.Quit();
    }
    public void restart()
    {
        SceneManager.LoadScene("Main");   
    }

    public void dasdfsdafadsfa()
    {
        monster.SetActive(false);
    }

    public void eixt()
    {
        monstedr.SetActive(true);
    }
}
