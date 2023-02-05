using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisableTxt : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float waitTime = 10f;

    public void TurnOffTxt()
    {
        StartCoroutine(WaitThenDisable());
    }
    private IEnumerator WaitThenDisable()
    {
        text.enabled = true;
        yield return new WaitForSeconds(waitTime);
        text.enabled = false;
    }
}
