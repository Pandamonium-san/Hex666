using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public Canvas canvas;
    public Transform dialogue;
    public Text textBox;
    public List<GameObject> avatars;
    public Vector3 posLeft, posRight;

    List<GameObject> instAvatars;
    GameObject curLeft, curRight;

    void Start()
    {
        instAvatars = new List<GameObject>();
        foreach (GameObject av in avatars)
        {
            GameObject newAv = Instantiate(av);
            instAvatars.Add(newAv);
            newAv.transform.parent = canvas.transform;
            newAv.SetActive(false);
        }
    }

    //debug
    void Update()
    {
        if (Input.GetKeyDown("1"))
            PlayMessage("hello this is the end of the beginning have you tried my new however what if you didn't but yes in the home");
        if (Input.GetKeyDown("2"))
        {
            if (curLeft != instAvatars[1])
                ShowAvatar(1, true);
            else
                HideAvatar(true);
        }
        if (Input.GetKeyDown("3"))
        {
            if (curRight != instAvatars[0])
                ShowAvatar(0, false);
            else
                HideAvatar(false);
        }
        if(Input.GetKeyDown("4"))
        {
            ShowAvatar(2, true);
        }
        if (Input.GetKeyDown("4"))
        {
            ShowAvatar(2, false);
        }
    }

    void PlayMessage(string message)
    {
        dialogue.gameObject.SetActive(true);
        TextScroll txScr = textBox.GetComponent<TextScroll>();
        if (!txScr.finished)
        {
            Debug.Log("Error: Message sent before previous finished");
            return;
        }
        textBox.text = message;
        txScr.StartTextScroll();
    }

    void ShowAvatar(int index, bool left)
    {
        Debug.Log("showing" + index);
        GameObject av = instAvatars[index];
        av.SetActive(true);
        if (left)
        {
            if (curLeft)
                curLeft.SetActive(false);
            av.transform.localPosition = posLeft;
            curLeft = av;
            //Mirror sprite
            //Vector3 scale = av.transform.localScale;
            //scale = new Vector3(scale.x * -1, scale.y, scale.z);
        }
        else
        {
            if (curRight)
                curRight.SetActive(false);
            av.transform.localPosition = posRight;
            curRight = av;
        }
    }

    void HideAvatar(bool left)
    {
        Debug.Log("hiding");
        if (left)
            curLeft.SetActive(false);
        else
            curRight.SetActive(false);
    }

    void DisableUI()
    {
        dialogue.gameObject.SetActive(false);
    }


}
