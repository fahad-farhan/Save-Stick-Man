using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Text timerText;

    public Text questionTxt;

    public Text gemsTxt;

    public Text levelTxt;

    public float cownDownTimer;

    private float timer;

    public bool startTimer, isWin;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = false;
        isWin = false;
        timer = cownDownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startTimer)
            return;

        if (isWin)
            return;

        timer -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(timer).ToString();
        if(timer <= 0.0f)
        {
            isWin = true;
            timer = 0.0f;
            timerText.gameObject.SetActive(false);
            GameManager.instance.CheckResult();
        }
    }

    public void StartTimer()
    {
        startTimer = true;
        timerText.gameObject.SetActive(true);
    }

    public void ShowQuestion(string _question)
    {
        if (_question != "")
            questionTxt.text = _question;
    }

    public void Skip()
    {
        AdsControl.Instance.ShowRewardedAd(AdsControl.REWARD_TYPE.SKIP_LEVEL);
    }

    public void ShowHint()
    {
        if(GameManager.instance.gems >= 100)
        {
            AudioManager.instance.coinSfx.Play();
            GameManager.instance.gems -= 100;
            GameManager.instance.SaveGems();
            ShowGems(GameManager.instance.gems);
            GameManager.instance.ShowHint();
        }
        
    }

    public void ShowGems(int _value)
    {
        gemsTxt.text = _value.ToString();
    }

    public void ShowLevel(int _value)
    {
        levelTxt.text = "Level " + _value.ToString();
    }
}
