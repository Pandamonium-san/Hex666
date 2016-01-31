using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    AudioSource current;
    void Start()
    {
        PlaySong("bgm_hexamination");
    }
	public void PlaySong(string name)
    {
        if (current)
            current.Stop();
        AudioSource song = transform.FindChild(name).GetComponent<AudioSource>();
        current = song;
        song.Play();
    }
}
