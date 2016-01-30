using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    
	// Use this for initialization
	void Start () 
    {
        FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonOnClick()
    {
        Destroy(FindObjectOfType<Player>().gameObject);
    }

}
