using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueScript : MonoBehaviour
{
    Queue<string> intro;
    static GameManager gm;

    void Start()
    {
        if (!gm)
            gm = FindObjectOfType<GameManager>();

        intro = new Queue<string>();
        intro.Enqueue("ShowAvatar 0 -400 Idle");
        intro.Enqueue("Myyn: Today is the first full moon of the year.");
        intro.Enqueue("Myyn: I don't have anything particular I need, but I guess I should take advantage of the extra strong magics in the air tonight and cast some kind of spell.");
        intro.Enqueue("Myyn: It would be a waste not to.");
        intro.Enqueue("Myyn: But what should I do..?");
        intro.Enqueue("ShowAvatar 0 -400 Sad");
        intro.Enqueue("Myyn: ...");
        intro.Enqueue("ShowAvatar 0 -400 Happy");
        intro.Enqueue("Myyn: Maybe I'll be able to figure something if I just go out gathering some ingredients.");
        StartCoroutine(Intro1());
    }

    public IEnumerator Intro1()
    {
        yield return new WaitForSeconds(0.5f);
        gm.PlayMessage(intro);
    }
    #region NoxWaldDialogue
    public static void TalkingToWald()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("ShowAvatar 2 400 Happy");
        q.Enqueue("Wald: Hello, witch!");
        q.Enqueue("Myyn:  My name is Myyn, Wald.");
        q.Enqueue("ShowAvatar 2 400 Idle");
        q.Enqueue("Wald: I know, I haven’t forgotten.");
        q.Enqueue("ShowAvatar 2 400 Sad");
        q.Enqueue("Wald: But I’m in a bit of a predicament and I don’t really have time to chat much.");
        q.Enqueue("Wald: I need to study for a test.");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: I didn’t know you studied anything?");
        q.Enqueue("ShowAvatar 2 400 Happy");
        q.Enqueue("Wald: I’m studying how toad-racing and betting affects society at large and also the individual toad breeders.");
        q.Enqueue("Wald: Right now I’m looking after around fifteen toads.");
        q.Enqueue("ShowAvatar 0 -400 Angry");
        q.Enqueue("Myyn: That must be so noisy!");
        q.Enqueue("ShowAvatar 2 400 Idle");
        q.Enqueue("Wald: No, not really, but my best toad has gotten a cold and I’m worried it won’t be able to race the day after tomorrow, so I’m out trying to find some herbs for medicine.");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Would you like some help?");
        q.Enqueue("ShowAvatar 2 400 Happy");
        q.Enqueue("Wald: Oh! Right! You ARE a witch! Would you make me a potion my precious toad? I’d owe you one!");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Sure, I could make one.");
        q.Enqueue("Wald: You are a lifesaver!");
        q.Enqueue("ShowAvatar 2 400 Sad");
        q.Enqueue("Wald: I just want my toads to be happy…");
        q.Enqueue("Wald: Here, have this candle, it can help you with your magic.");
        q.Enqueue("AddItem 10");
        q.Enqueue("Obtained Purple Candle.");
        gm.PlayMessage(q);
    }
    public static void TalkingToNox()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 1 400 Angry");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Hello, Nox.");
        q.Enqueue("Nox: Hi, Myyn…");
        q.Enqueue("ShowAvatar 0 -400 Sad");
        q.Enqueue("Myyn: Is something wrong?");
        q.Enqueue("Nox: Wald has taken up toad breeding.");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn:  Oh. You don’t like it?");
        q.Enqueue("Nox: What is there to like? They are slimy and gross, and Wald calls them their “babies”! Also some of them might be poisonous, Wald could get hurt.");
        q.Enqueue("ShowAvatar 0 -400 Sad");
        q.Enqueue("Myyn: Yes, that would be bad…");
        q.Enqueue("ShowAvatar 1 400 Idle");
        q.Enqueue("Nox: Right?");
        q.Enqueue("ShowAvatar 1 400 Angry");
        q.Enqueue("Nox: But Wald won’t listen to me, won’t even consider just having a couple less toads.");
        q.Enqueue("Nox: What do they even need that MANY toads for this study anyway, wouldn’t it be enough to just go visit some real breeders?");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Well, some things you can’t really understand until you’ve tried it yourself.");
        q.Enqueue("Nox: But this is just going to unnecessary lengths! Wald is just being stubborn!");
        q.Enqueue("ShowAvatar 1 400 Happy");
        q.Enqueue("Nox: Myyn! You could make a spell to make the toads not poisonous anymore!");
        q.Enqueue("Nox: Messing with toads through magic disqualifies them from competitions, but it’s not like Wald was going to compete with them anyway, "); 
        q.Enqueue("and they could be sold as house pets when Wald is done with the study.");
        q.Enqueue("Nox: Please, Myyn!");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Well, I was planning on doing something tonight anyway.");
        q.Enqueue("ShowAvatar 1 400 Happy");
        q.Enqueue("Nox: Thanks! Take this candle, I got some extra and I know you need them.");
        q.Enqueue("AddItem 11");
        q.Enqueue("Obtained Green Candle.");
        gm.PlayMessage(q);
    }
    public static void TalkingToNox1()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 1 400 Idle");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Nox: Did you need anything else?");
        q.Enqueue("Myyn: I was just wondering if you had anything else that could help me out.");
        q.Enqueue("Nox: What? That candle wasn't enough? Sorry, but I don't think I have anything useful.");
        q.Enqueue("Myyn: Okay then. Thank you anyway.");
        gm.PlayMessage(q);
    }
    public static void TalkingToNox2()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 1 400 Idle");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Is there anything else going around?");
        q.Enqueue("Nox: Hmm, now that you mention it, have you seen a note around here? I dropped it somewhere.");
        q.Enqueue("ShowAvatar 0 -400 Sad");
        q.Enqueue("Myyn: Oh, that's unfortunate. Was it important?");
        q.Enqueue("Nox: I don't remember. That's what it was for. You know how I forget things sometimes. I just hope Wald doesn't find it");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: I'll be on the lookout for it.");
        q.Enqueue("ShowAvatar 1 400 Happy");
        q.Enqueue("Nox: Thanks, Myyn!");
        gm.PlayMessage(q);
    }
    public static void TalkingToNox3NoNote()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 1 400 Idle");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Nox: Did you find it?");
        q.Enqueue("Myyn: No, sorry.");
        q.Enqueue("ShowAvatar 1 400 Angry");
        q.Enqueue("Nox: I know it can't be that far away?");
        gm.PlayMessage(q);
    }
    public static void TalkingToNox3Note()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 1 400 Idle");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Hey! Is this yours?");
        q.Enqueue("ShowAvatar 1 400 Happy");
        q.Enqueue("Nox: Yeah! That's it! You really found it for me! Thanks a lot, Myyn.");
        q.Enqueue("Nox: Let's see what it says...");
        q.Enqueue("ShowAvatar 1 400 Angry");
        q.Enqueue("Nox: You... didn't read it, did you?");
        q.Enqueue("Nox: You... didn't read it, did you?");

        gm.PlayMessage(q);
    }
    #endregion
    #region Endings
    //[green potion]
    public static void WaldGoodEnd()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 2 400 Idle");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Here you are, Wald, this potion will make your toads feel better in no time.");
        q.Enqueue("ShowAvatar 2 400 Happy");
        q.Enqueue("Wald: Thank you, Myyn, I love you so much! I knew I could count on you!");
        q.Enqueue("Myyn: No problem, I’m glad I could be of help.");
        q.Enqueue("Wald: Now Mister Binky will be hopping around and singing again, I’m so glad!");
        q.Enqueue("ShowAvatar 2 400 Sad");
        q.Enqueue("Wald: Singing…");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Did you say something?");
        q.Enqueue("ShowAvatar 2 400 Idle");
        q.Enqueue("Wald: No, nothing!");
        q.Enqueue("ShowEndScreen 0");
        gm.PlayMessage(q);
    }

    public static void WaldBadEnd()
    {
        Queue<string> q = new Queue<string>();

        //[produces a yellow potion, makes the toad and anything it touches swell up as balloons and bounce around the room floating for a couple of hours]
        q.Enqueue("ShowAvatar 2 400 Idle");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Here, Wald, the potion for your toads.");
        q.Enqueue("ShowAvatar 2 400 Happy");
        q.Enqueue("Wald: Thank you, Myyn, oh, I can’t wait for Mister Binksy to feel better again, I’ll run give this potion to him right away!");
        q.Enqueue("Myyn: Yes, do that.");
        q.Enqueue("HideAvatar 0");
        q.Enqueue("HideAvatar 2");
        q.Enqueue("Thirty minutes later Wald’s room is filled of bloated toads flying around the room, bouncing gently off each other");
        q.Enqueue("ShowEndScreen 1");
        gm.PlayMessage(q);
    }

    //[blue potion]
    public static void NoxGoodEnd()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 1 400 Happy");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Here is the potion. Put it on the toads and they’ll lose their poison.");
        q.Enqueue("Nox: Great! This will make me a lot less worried about Wald.");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Sure, it will help me sleep easier, too.");
        q.Enqueue("ShowAvatar 1 400 Idle");
        q.Enqueue("Nox: Thank you, Myyn. I’ll see you Wednesday, as usual?");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn (neutral): Yep, see you Wednesday.");
        q.Enqueue("ShowEndScreen 2");
        gm.PlayMessage(q);
    }

    //[red potion]
    public static void NoxBadEnd()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 1 400 Happy");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Here’s the potion.");
        q.Enqueue("Nox: Thank you so much! This will help me stop worrying about Wald.");
        q.Enqueue("Myyn: No problem.");
        q.Enqueue("Sneaking up on Wald’s toads, Nox carefully got the potion bottle out of their pocket. However, as soon as they opened the bottle an explosion of colourful fumes erupted from it and enveloped Nox completely.");
        q.Enqueue("ShowAvatar 1 400 Angry");
        q.Enqueue("Nox: Myyyyyyyyyn!!");
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Yes, Nox?");
        q.Enqueue("Nox: It’s been an entire week and my nose STILL hasn’t stopped being runny from your stupid prank!");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Well, maybe stop sticking it into things that aren’t your business, then. See you next Wednesday!");
        q.Enqueue("ShowEndScreen 3");
        gm.PlayMessage(q);
    }

    public static void GameOver()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Sad");
        q.Enqueue("something something ran out of time moon is not bright enough");
        q.Enqueue("ShowEndScreen 4");
        gm.PlayMessage(q);
    }
    #endregion
    #region PortalHints
    public static void PortalFull()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("There is no space to place this item.");
        gm.PlayMessage(q);
    }

    public static void PotionToPortal()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: I shouldn't use this potion in the ritual. I could give it to someone.");
        gm.PlayMessage(q);
    }

    public static void HairToPortal()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Getting this hair catalyst wasn't easy. This is going to be fun... ");
        gm.PlayMessage(q);
    }

    public static void CandleToPortal()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("Myyn: Good thing I got this magic candle as a catalyst. I hope it will make something helpful.");
        gm.PlayMessage(q);
    }

    // INCOMPLETE DIALOGUE BELOW
    public static void ExaminePortalNoIngsOrCata()
    {
        Debug.Log("twice");
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("something something u need 5 ingredients and a catalyst something");
        gm.PlayMessage(q);
    }
    public static void ExaminePortalNoIngs()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("u need 5 ingredients");
        gm.PlayMessage(q);
    }
    public static void ExaminePortalNoCata()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("u need a catalyst");
        gm.PlayMessage(q);
    }
    public static void ExaminePortalHasCataAndIngs()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("u need to start the ritual by using a flask to put the potion in");
        gm.PlayMessage(q);
    }
    #endregion
    #region CreatePotion
    /// CREATE POTION DIALOGUE
    /// <summary>
    /// Wald good end
    /// </summary>
    public static void CreateBluePotion()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("something something give this to wald");
        q.Enqueue("AddItem 14");
        q.Enqueue("Obtained Blue Potion.");
        gm.PlayMessage(q);
    }
    /// <summary>
    /// Wald bad end
    /// </summary>
    public static void CreateYellowPotion()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("something something give this to wald");
        q.Enqueue("AddItem 16");
        q.Enqueue("Obtained Yellow Potion.");
        gm.PlayMessage(q);
    }
    /// <summary>
    /// Nox good end
    /// </summary>
    public static void CreateGreenPotion()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("something something give this to nox");
        q.Enqueue("AddItem 15");
        q.Enqueue("Obtained Green Potion.");
        gm.PlayMessage(q);
    }
    /// <summary>
    /// Nox bad end
    /// </summary>
    public static void CreateRedPotion()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Happy");
        q.Enqueue("something something give this to nox");
        q.Enqueue("AddItem 17");
        q.Enqueue("Obtained Red Potion.");
        gm.PlayMessage(q);
    }

    public static void PotionFailed()
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Let's see...");
        q.Enqueue("Myyn: This goes here, right?");
        q.Enqueue("Myyn: Oh!");
        q.Enqueue("Myyn: That wasn't supposed to happen.");
        q.Enqueue("ShowAvatar 0 400 Sad");
        q.Enqueue("Myyn: Hmm... This potion doesn't seem to be useful for anything. No point in keeping it.");
        q.Enqueue("PlaySound water_4.ogg");
        q.Enqueue("...");
        q.Enqueue("AddItem 3");
        q.Enqueue("Obtained flask.");
        q.Enqueue("Myyn: I wonder if I have time to make something else...");
        q.Enqueue("ShowAvatar 0 400 Happy");
        q.Enqueue("Myyn: The moon is still shining brightly.");
        q.Enqueue("Myyn: If I hurry up I might be able to make one more attempt.");
        q.Enqueue("Myyn: Let's see what else I can make!");
        gm.PlayMessage(q);
    }
    #endregion
}
