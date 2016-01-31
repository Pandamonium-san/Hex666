using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public void PlaySong(string name)
    {
        transform.FindChild(name).GetComponent<AudioSource>().Play();
    }
}
