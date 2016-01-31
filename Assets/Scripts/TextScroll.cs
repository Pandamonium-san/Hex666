using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScroll : MonoBehaviour
{
    Text text;
    string dialogue;
    public bool finished = true;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        StartTextScroll();
    }

    public void StartTextScroll()
    {
        StartCoroutine(ScrollText());
    }

    public IEnumerator ScrollText()
    {
        finished = false;
        dialogue = text.text;
        for (int i = 0; i < dialogue.Length + 1; i++)
        {
            if (finished)
                yield break;
            text.text = dialogue.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        finished = true;
    }

    public void SkipScroll()
    {
        if (finished == true)
            return;
        text.text = dialogue;
        finished = true;
    }
}
