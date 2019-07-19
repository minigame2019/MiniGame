using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Text progressText;
    public Slider slider;
    private float pValue;
    private AsyncOperation async = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadS");
    }

    private IEnumerator LoadS()
    {
        async = SceneManager.LoadSceneAsync("DemoScene");
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            pValue = async.progress;

            slider.value = pValue;
            progressText.text = (int)(slider.value * 100) + "%";

            if (pValue >= 0.9f)
            {
                slider.value = 1f;
                progressText.text = "按任意键继续";
                if (Input.anyKeyDown)
                {
                    async.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    
}
