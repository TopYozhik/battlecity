using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    public Transform window;
    public void ButtonPressed() {
        window.LeanMoveLocalX(-Screen.width-1000, 0.8f).setEaseInExpo().setOnComplete(OnComplete); 
    }
    void OnComplete(){
        gameObject.SetActive(false);
    }
}
