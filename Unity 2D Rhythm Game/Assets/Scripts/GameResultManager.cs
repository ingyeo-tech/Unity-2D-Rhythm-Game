using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
    public Text musicTitleUI;
    public Text scoreUI;
    public Text maxComboUI;

    void Start()
    {
        musicTitleUI.text = PlayerInformation.musicTitle;
        scoreUI.text = "" + PlayerInformation.score; //int 문자열로 변환하기! 
        maxComboUI.text = "" + PlayerInformation.maxCombo;

    }

    void Update()
    {
        
    }
}
