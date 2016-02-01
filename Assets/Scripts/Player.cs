using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float WalkSpeed { get; set; }
    public float RunSpeed { get; set; }

    public enum State { Moving, Interacting, Inventory }
    public State state = State.Moving;

    public Inventory inventory;
    public AudioClip inventoryOpen, inventoryClose;
    new Rigidbody2D rigidbody2D;
    GameManager gm;
    Animator animator;

    public Vector2 triggerOffset;
    public Vector2 triggerDistance;
    float Speed;

    // Use this for initialization
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        gm = FindObjectOfType<GameManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Speed = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Moving:
                Movement();
                if (Input.GetKeyDown("z"))
                    Examine();
                if (Input.GetKeyUp("x"))
                    OpenInventory();
                break;
            case State.Interacting:
                rigidbody2D.velocity = Vector2.zero;
                if (Input.GetKeyDown("z") || Input.GetKey("x"))
                    gm.PlayNextMessage();
                break;
            case State.Inventory:
                InventoryControls();
                break;
            default:
                break;
        }
    }
    void OpenInventory()
    {
        if (inventoryOpen)
            AudioSource.PlayClipAtPoint(inventoryOpen, Camera.main.transform.position + new Vector3(0,0,-5));
        inventory.ShowHighlight(true);
        state = State.Inventory;
    }
    void ExitInventory()
    {
        if (inventoryClose)
            AudioSource.PlayClipAtPoint(inventoryClose, transform.position);
        inventory.ShowHighlight(false);
        state = State.Moving;
    }
    void InventoryControls()
    {
        if (Input.GetKeyUp("z"))
            UseItem();
        if (Input.GetKeyUp("x"))
            ExitInventory();
        if (Input.GetKeyUp("left"))
            inventory.ScrollBack();
        if (Input.GetKeyUp("right"))
            inventory.ScrollForward();
    }

    void UseItem()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(transform.position + (Vector3)triggerOffset, triggerDistance, 0, Vector2.zero, 1, 1 << 9);
        if (hit == null || hit.Length == 0)
        {
            ExitInventory();
            gm.PlayMessage("Nothing happened");
            return;
        }

        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider != null)
            {
                //Debug.Log(hit.collider.name);
                EventTrigger et = hit[i].transform.GetComponent<EventTrigger>();
                if (et != null && et.Trigger(inventory.SelectedItem))
                {
                    inventory.RemoveSelectedItem();
                    ExitInventory();
                    return;
                }
            }
        }
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
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
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
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.rotation = new Quaternion(0, 1, 0, 0);
        }
    }

    void Examine()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)triggerOffset, triggerDistance, 0, Vector2.zero, 1, 1 << 9);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
            EventTrigger et = hit.transform.GetComponent<EventTrigger>();
            et.Trigger();
        }

    }

}
