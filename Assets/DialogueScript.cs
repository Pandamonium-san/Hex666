using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueScript : MonoBehaviour {

    Queue<string> intro;
    GameManager gm;

	void Start () {
        if(!gm)
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

    public void TalkingToWald()
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
		gm.PlayMessage(q);
    }
    public void TalkingToNox()
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
        q.Enqueue("Nox: Messing with toads through magic disqualifies them from competitions, but it’s not like Wald was going to compete with them anyway, and they could be sold as house pets when Wald is done with the study.");
        q.Enqueue("Nox: Please, Myyn!");
        q.Enqueue("ShowAvatar 0 -400 Idle");
        q.Enqueue("Myyn: Well, I was planning on doing something tonight anyway.");
        q.Enqueue("ShowAvatar 1 400 Happy");
        q.Enqueue("Nox: Thanks! Take this candle, I got some extra and I know you need them.");
        gm.PlayMessage(q);
    }

    //[green potion]
    public void WaldGoodEnd()
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


    public void WaldBadEnd()
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
	public void NoxGoodEnd()
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

	//[blue potion]
	public void NoxBadEnd()
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
		q.Enqueue("Myyn (neutral): Well, maybe stop sticking it into things that aren’t your business, then. See you next Wednesday!");
        q.Enqueue("ShowEndScreen 3");
        gm.PlayMessage(q);
	}
}
