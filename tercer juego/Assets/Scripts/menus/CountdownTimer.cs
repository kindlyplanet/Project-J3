using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float startingTime = 10f;
    private float currentTime;
    public TextMeshProUGUI countdownText;
    public PlayerHealth playerHealth;

    private void Start()
    {
        currentTime = startingTime;
        UpdateCountdownText();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();
        }
        else
        {
            playerHealth.Die();
            Debug.Log("End level");
            this.enabled = false;
        }
    }

    private void UpdateCountdownText()
    {
        // * minutos ** segundos ** 2 miliseg
        float minutos = (int)(currentTime / 60);
        float segundos = (int)currentTime - ((minutos) * 60);
        float miliSeg = (int)((currentTime % 1) * 100);

        // 0 : 1 : 1
        string minutosT = "" + minutos;
        string segundosT = "" + (segundos < 10 ? "0" + segundos : "" + segundos);
        string miliSegT = "" + (miliSeg < 10 ? "0" + miliSeg : "" + miliSeg);

        countdownText.text = minutosT + " : " + segundosT + " : " + miliSegT;
    }
}

