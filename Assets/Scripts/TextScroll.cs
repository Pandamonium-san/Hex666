using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScroll : MonoBehaviour
{
    public bool finished = true;
    // Use this for initialization
    void Start()
    {
        StartTextScroll();
    }

    public void StartTextScroll()
    {
        StartCoroutine(ScrollText());
    }

    public IEnumerator ScrollText()
    {
        finished = false;
        Text text = GetComponent<Text>();
        string dialogue = text.text;
        for (int i = 0; i < dialogue.Length + 1; i++)
        {
            text.text = dialogue.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        finished = true;
    }
}
