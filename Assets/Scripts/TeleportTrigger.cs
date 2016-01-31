using UnityEngine;
using System.Collections;

public class TeleportTrigger : MonoBehaviour {
    public Vector3 warpPos;
    public int toScreenIndex;
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        FindObjectOfType<GameManager>().screenIndex = toScreenIndex;
        player.transform.position = warpPos;
    }
}
