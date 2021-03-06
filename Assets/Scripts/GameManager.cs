﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public Canvas canvas;
    public Transform dialogue;
    public Text textBox;
    public List<GameObject> avatars;
    public float yPos;

    public int screenIndex;
    public int ending;

    List<GameObject> instAvatars;
    Queue<string> msgQueue;

    Player player;
    Inventory inventory;

    public bool MessageExists { get; private set; }

    void Start()
    {
        Item.InitializeItemDB();
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
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
            ShowEndScreen(2);
        }
        if (Input.GetKeyDown("6"))
        {
            HideDialogue();
        }
    }

    public void ShowMessage(string message)
    {
        MessageExists = true;
        dialogue.gameObject.SetActive(true);
        player.SetState(Player.State.Interacting);
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
        else if (message.StartsWith("AddItem"))
        {
            string[] split = message.Split();
            AddItem(int.Parse(split[1]));
            PlayNextMessage();
        }
        else if (message.StartsWith("ShowEndScreen"))
        {
            string[] split = message.Split();
            ShowEndScreen(int.Parse(split[1]));
        }
        else if (message.StartsWith("PlaySound"))
        {
            string[] split = message.Split();
            PlaySound(split[1]);
        }
        else
        {
            TextScroll txScr = textBox.GetComponent<TextScroll>();
            textBox.text = message;
            txScr.StartTextScroll();
        }
    }

    public void AddItem(int ID)
    {
        Item item = Item.GetItem(ID);
        if (item != null)
        {
            inventory.AddSlot(item);
            Debug.Log("Added " + item.Name);
        }
        else
            Debug.Log("Error: Item with ID " + ID + " was not found.");
    }

    public void PlaySound(string name)
    {
        AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("SFX/" + name), Camera.main.transform.position);
    }
    /// <summary>
    /// Shows a single message.
    /// </summary>
    public void PlayMessage(string message)
    {
        dialogue.gameObject.SetActive(true);
        player.SetState(Player.State.Interacting);

        msgQueue.Enqueue(message);

        PlayNextMessage();
    }

    /// <summary>
    /// Creates a continuous dialoguebox.
    /// </summary>
    public void PlayMessage(Queue<string> messages)
    {
        if (MessageExists)
        {
            Debug.Log("Queue overwritten");
        }
        dialogue.gameObject.SetActive(true);
        player.SetState(Player.State.Interacting);

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
            return;
        }
        ShowMessage(msgQueue.Dequeue());
    }
    /// <summary>
    /// Shows avatar above dialogue box.
    /// </summary>
    /// <param name="index">0 = Myyn, 1 = Nox, 2 = Wald (set in game manager)</param>
    /// <param name="xPos">X-position of avatar</param>
    /// <param name="mood">Myyn(Happy,Sad,Angry,Idle), Nox(Happy,Angry,Idle), Wald(Happy,Sad,Idle)</param>
    public void ShowAvatar(int index, float xPos, string mood)
    {
        GameObject av = instAvatars[index];
        av.transform.localPosition = new Vector2(xPos, yPos);
        Animator anim = av.GetComponent<Animator>();
        anim.SetTrigger(mood);
        av.SetActive(true);
    }

    public void HideAvatar(int index)
    {
        instAvatars[index].SetActive(false);
    }

    public void HideDialogue()
    {
        player.SetState(Player.State.Moving);
        textBox.GetComponent<TextScroll>().finished = true;
        foreach (var av in instAvatars)
        {
            av.SetActive(false);
        }
        dialogue.gameObject.SetActive(false);
        MessageExists = false;
    }

    public void ShowEndScreen(int index)
    {
        GameObject.Find("UI").SetActive(false);
        ending = index;
        screenIndex = 3;
        FindObjectOfType<MusicPlayer>().PlaySong("bgm_witchCraft");
        if (index == 5)
            FindObjectOfType<MusicPlayer>().PlaySong("bgm_citymusic");
    }


}
