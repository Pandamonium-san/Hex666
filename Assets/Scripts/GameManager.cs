using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Canvas canvas;
    public Transform dialogue;
    public Text textBox;
    public List<GameObject> avatars;
    //public Vector3 posLeft, posRight;
    public float yPos;

    public bool lastMessage;
    public int screenIndex;

    List<GameObject> instAvatars;
    Queue<string> msgQueue;

    void Start()
    {
        instAvatars = new List<GameObject>();
        foreach (GameObject av in avatars)
        {
            GameObject newAv = Instantiate(av);
            instAvatars.Add(newAv);
            newAv.transform.parent = dialogue.transform;
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
        }
        if (Input.GetKeyDown("3"))
        {
        }
        if (Input.GetKeyDown("4"))
        {
        }
        if (Input.GetKeyDown("5"))
        {
        }
        if (Input.GetKeyDown("6"))
        {
            HideDialogue();
        }
    }

    public void ShowMessage(string message)
    {
        dialogue.gameObject.SetActive(true);
        player.state = Player.State.Interacting;
        TextScroll txScr = textBox.GetComponent<TextScroll>();
        if (!txScr.finished)
        {
            Debug.Log("Error: Message sent before previous finished");
            return;
        }
        if (message.StartsWith("ShowAvatar"))
        {
            string[] split = message.Split();
            ShowAvatar(int.Parse(split[1]), float.Parse(split[2]), split[3]);
            PlayNextMessage();
        }
        else if (message.StartsWith("HideAvatar"))
        {
            string[] split = message.Split();
            HideAvatar(int.Parse(split[1]));
            PlayNextMessage();
        }
        else
        {
            textBox.text = message;
            txScr.StartTextScroll();
        }
    }

    /// <summary>
    /// Shows a single message.
    /// </summary>
    public void PlayMessage(string message)
    {
        dialogue.gameObject.SetActive(true);
        player.state = Player.State.Interacting;

        msgQueue.Enqueue(message);

        PlayNextMessage();
    }

    /// <summary>
    /// Creates a continuous dialoguebox.
    /// </summary>
    public void PlayMessage(Queue<string> messages)
    {
        dialogue.gameObject.SetActive(true);
        player.state = Player.State.Interacting;

        msgQueue = messages;

        PlayNextMessage();
    }

    public void PlayNextMessage()
    {
        TextScroll ts = textBox.GetComponent<TextScroll>();
        if (!ts.finished)
        {
            ts.SkipScroll();
            return;
        }
        if (msgQueue.Count <= 0)
        {
            HideDialogue();
        }
        ShowMessage(msgQueue.Dequeue());
    }

    public void NextMessage()
    {
    }

    /// <summary>
    /// Shows avatar above dialogue box.
    /// </summary>
    /// <param name="index">0 = Myyn, 1 = Nox, 2 = Wald (set in game manager)</param>
    /// <param name="xPos">X-position of avatar</param>
    /// <param name="mood">Myyn(Happy,Sad,Angry,Idle), Nox(Happy,Angry,Idle), Wald(Happy,Sad,Idle)</param>
    public void ShowAvatar(int index, float xPos, string mood)
    {
        Debug.Log("showing" + index);
        GameObject av = instAvatars[index];
        av.transform.localPosition = new Vector2(xPos, yPos);
        av.GetComponent<Animator>().SetTrigger(mood);
        av.SetActive(true);
    }

    public void HideAvatar(int index)
    {
        Debug.Log("hiding");
        instAvatars[index].SetActive(false);
    }

    public void HideDialogue()
    {
        player.state = Player.State.Moving;
        textBox.GetComponent<TextScroll>().finished = true;
        foreach (var av in instAvatars)
        {
            av.SetActive(false);
        }
        dialogue.gameObject.SetActive(false);
    }


}
