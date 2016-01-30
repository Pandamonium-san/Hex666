using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public Transform dialogue;
    public Text textBox;
    public List<GameObject> avatars;
    public Vector3 posLeft, posRight;

    List<GameObject> instAvatars;
    Queue<string> msgQueue;
    Player player;
    GameObject curLeft, curRight;

    void Start()
    {
        player = FindObjectOfType<Player>();
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
        if (Input.GetKeyDown("5"))
        {
            ShowAvatar(2, false);
        }
        if (Input.GetKeyDown("6"))
        {
            HideDialogue();
        }
    }

    public void PlayMessage(string message)
    {
        dialogue.gameObject.SetActive(true);
        player.state = Player.State.Interacting;
        TextScroll txScr = textBox.GetComponent<TextScroll>();
        if (!txScr.finished)
        {
            Debug.Log("Error: Message sent before previous finished");
            return;
        }
        textBox.text = message;
        txScr.StartTextScroll();
    }

    public void PlayMessage(Queue<string> messages)
    {
        dialogue.gameObject.SetActive(true);
        player.state = Player.State.Interacting;
        msgQueue = messages;
        PlayNextMessage();
    }

    public void PlayNextMessage()
    {
        if (!textBox.GetComponent<TextScroll>().finished)
            return;
        if (msgQueue.Count <= 0)
        {
            HideDialogue();
        }
        PlayMessage(msgQueue.Dequeue());
    }

    public void ShowAvatar(int index, bool left)
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

    public void HideAvatar(bool left)
    {
        Debug.Log("hiding");
        if (left)
            curLeft.SetActive(false);
        else
            curRight.SetActive(false);
    }

    public void HideDialogue()
    {
        dialogue.gameObject.SetActive(false);
        textBox.GetComponent<TextScroll>().finished = true;
        foreach (var av in instAvatars)
        {
            av.SetActive(false);
        }
        player.state = Player.State.Moving;
    }


}
