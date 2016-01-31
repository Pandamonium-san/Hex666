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
    //public Vector3 posLeft, posRight;
    public float yPos;

    public int screenIndex;

    List<GameObject> instAvatars;
    Queue<string> msgQueue;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
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
            ShowAvatar(0, 500);
        }
        if (Input.GetKeyDown("3"))
        {
        }
        if (Input.GetKeyDown("4"))
        {
        }
        if (Input.GetKeyDown("5"))
        {
            ShowAvatar(2, -500);
        }
        if (Input.GetKeyDown("6"))
        {
            HideDialogue();
        }
    }

    /// <summary>
    /// Shows a single message.
    /// </summary>
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
        if (!textBox.GetComponent<TextScroll>().finished)
            return;
        if (msgQueue.Count <= 0)
        {
            HideDialogue();
        }
        PlayMessage(msgQueue.Dequeue());
    }

    /// <summary>
    /// Shows avatar above dialogue box.
    /// </summary>
    /// <param name="index">0 = Myyn, 1 = Nox, 2 = Wald (set in game manager)</param>
    /// <param name="xPos">X-position of avatar</param>
    public void ShowAvatar(int index, float xPos)
    {
        Debug.Log("showing" + index);
        GameObject av = instAvatars[index];
        av.transform.localPosition = new Vector2(xPos, yPos);
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
