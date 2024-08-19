using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public UIGame uiGame;

    public UIWin uiWin;

    public ParticleSystem winFx1, winFx2;

    public Transform winTick, failTick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWin()
    {
        StartCoroutine(ShowWinIE());
    }

    public void ShowFail()
    {
        StartCoroutine(ShowFailIE());
    }

    IEnumerator ShowWinIE()
    {
        AudioManager.instance.levelWinSfx.Play();
        winFx1.Play();
        winFx2.Play();
        winTick.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        winTick.gameObject.SetActive(false);
        uiWin.gameObject.SetActive(true);
    }

    IEnumerator ShowFailIE()
    {
       
        failTick.gameObject.SetActive(true);
        AudioManager.instance.levelFailSfx.Play();
        yield return new WaitForSeconds(1.5f);
        failTick.gameObject.SetActive(false);
        GameManager.instance.Replay();
    }

}
