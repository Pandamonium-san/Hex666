using UnityEngine;
using System.Collections;

public class TeleportTriggerScriptSouth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = FindObjectOfType<Player>().gameObject;
        Vector3 OldPos = player.transform.position;
        OldPos.y -= 13;
        player.transform.position = OldPos;
        OldPos = Camera.main.transform.position;
        OldPos.y -= 20;
        Camera.main.transform.position = OldPos;
    }
}
