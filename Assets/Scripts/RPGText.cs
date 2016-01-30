using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RPGText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartText();
        StartCoroutine(TextScroll());
    }
	
    public void StartText()
    {
        Debug.Log("test");
    }

    public IEnumerator TextScroll()
    {
        Debug.Log("scroll");
        Text text = GetComponent<Text>();
        string dialogue = text.text;
        for (int i = 0; i < dialogue.Length; i++)
        {
            text.text = dialogue.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
