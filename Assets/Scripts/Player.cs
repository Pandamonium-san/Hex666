using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float WalkSpeed { get; set; }
    public float RunSpeed { get; set; }

    float Speed;

    BoxCollider2D boxCollider;
    new Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Speed = 500f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Movement();
        if(Input.GetKey)
	}

    void Movement()
    {
        float horizontal = HorizontalMovement();
        float vertical = VerticalMovement();
        Vector3 movement = new Vector3(horizontal, vertical, 0);
        rigidbody2D.velocity = movement;
        if (Input.GetKey("z"))
            Examine();
    }

    float HorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
            horizontal = 1;
        else if (horizontal < 0)
            horizontal = -1;
        horizontal *= Speed * Time.deltaTime;
        return horizontal;
    }

    float VerticalMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
            vertical = 1;
        else if (vertical < 0)
            vertical = -1;
        vertical *= Speed * Time.deltaTime;
        return vertical;
    }

    void Examine()
    {

    }

}
