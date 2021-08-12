using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    [TextArea]
    public string shownText;


    private void OnTriggerEnter()
    {
        tutorialText.gameObject.SetActive(true);
        tutorialText.text = shownText;
    }

    private void OnTriggerExit(Collider other)
    {
        tutorialText.gameObject.SetActive(false);
    }


}
