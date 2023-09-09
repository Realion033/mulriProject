using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Roding : MonoBehaviour
{
    public Slider proge;
    public Text loadte;
    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (proge.value < 1f)
            {
                proge.value = Mathf.MoveTowards(proge.value, 1f, Time.deltaTime);
            }
            else
            {
                loadte.text = "시작하려면 Space키를 누르세요...";
            }

            if(Input.GetKeyDown(KeyCode.Space) && proge.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
