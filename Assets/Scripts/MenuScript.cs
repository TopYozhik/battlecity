using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Transform window;
    public CanvasGroup bgFade;

    public void ButtonPressed() {
        bgFade.LeanAlpha(0, 0.5f);
        window.LeanMoveLocalX(-Screen.width-1000, 0.8f).setEaseInExpo().setOnComplete(OnComplete); 
    }
    void OnComplete(){
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
