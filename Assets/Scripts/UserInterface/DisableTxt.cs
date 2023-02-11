using System.Collections;
using TMPro;
using UnityEngine;

namespace UserInterface
{
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
}
