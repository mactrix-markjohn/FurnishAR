using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScript : MonoBehaviour
{

    public Button getStartButton;
    public Text startedText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplashScreenWait());
        getStartButton.onClick.AddListener(() =>
        {
            startedText.text = "Get Started ..";
            SceneManager.LoadScene(ConstantStringStore.HomeScene);
        });
        //getStartButton.gameObject.transform.localScale = new Vector3(0.95f,0.95f,0.95f);
        //getStartButton.gameObject.LeanScale(Vector3.one, 2f).setLoopType(LeanTweenType.pingPong);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetStartedClick()
    {
        startedText.text = "Get Started ..";
        SceneManager.LoadScene(ConstantStringStore.HomeScene);
    }


    IEnumerator SplashScreenWait()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(ConstantStringStore.HomeScene);
        
    }


}
