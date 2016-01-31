using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    Player player;
    GameManager gm;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        gm = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pPos = player.transform.position;
        float yPos = transform.position.y;
        float xPos = transform.position.x;
        switch (gm.screenIndex)
        {
            case 0:
                xPos = 0;
                yPos = Mathf.Clamp(pPos.y, -4, 4);
                break;
            case 1:
                xPos = 20;
                yPos = Mathf.Clamp(pPos.y, -4, 4);
                break;
            case 2:
                xPos = 0;
                yPos = Mathf.Clamp(pPos.y, 16, 24);
                break;
            case 3:
                xPos = 0;
                yPos = 50 + gm.ending * 10;
                break;
        }
        transform.position = new Vector3(xPos, yPos, transform.position.z);
	}
}
