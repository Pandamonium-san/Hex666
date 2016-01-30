using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float WalkSpeed { get; set; }
    public float RunSpeed { get; set; }

    enum Dir { D, DR, R, U, UR }
    Dir fDir = Dir.R;
    bool flipHorizontal = false;

    BoxCollider2D boxCollider;
    new Rigidbody2D rigidbody2D;

    public Vector3 triggerDir;
    public float triggerDistance;
    float Speed;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Speed = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyUp("z"))
            Examine();
    }

    void Movement()
    {
        float horizontal = HorizontalMovement();
        float vertical = VerticalMovement();
        Vector3 movement = new Vector3(horizontal, vertical, 0);
        rigidbody2D.velocity = movement;
        if (movement != Vector3.zero)
        {
            UpdateDirection(movement);
            triggerDir = movement.normalized;
        }
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
    void UpdateDirection(Vector3 movement)
    {
        if (movement.x > 0)
            flipHorizontal = false;
        else if (movement.x < 0)
            flipHorizontal = true;
        else
        {
            if (movement.y > 0)
                fDir = Dir.U;
            else if (movement.y < 0)
                fDir = Dir.D;
            else
                fDir = Dir.R;
            return;
        }
        if (movement.y > 0)
            fDir = Dir.UR;
        else if (movement.y < 0)
            fDir = Dir.DR;
    }

    void Examine()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, triggerDir, triggerDistance, 1 << 9);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Camera.main.cullingMask = ~(1 << 10);
            Destroy(hit.transform.gameObject);
        }

    }

}
