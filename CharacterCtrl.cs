using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float speed = 4.0f;
    public float rotSpeed = 80.0f;
    public float rot = 0.0f;
    public float gravity = 8.0f;
    Vector3 moveDir = Vector3.zero;
    public float jumpForce;

    public float mouseSensitive = 100.0f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    

    private Transform _bullet;

    CharacterController controller;
    Animator anim;
    Rigidbody rb;

    //public Inventory inventory;

    private HealthBar mHealthBar;
    public HUD Hud;
    public int Health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        mHealthBar = Hud.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;
        
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir); //หาแกนตามตัวละครหันไป
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("condition", -1);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed / 2;
                moveDir = transform.TransformDirection(moveDir); //หาแกนตามตัวละครหันไป
            }
            else if (Input.GetMouseButtonDown(0))
            {
                anim.SetInteger("condition", 2);
                
            }
            else
            {
                anim.SetInteger("condition", 0);
                moveDir = Vector3.zero;
            }

            rot = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;

            xRotation = Mathf.Clamp(xRotation, -180f, 180f);

            playerBody.Rotate(Vector3.up * rot);

            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }

        /*rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);*/
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
            Health = 0;

        mHealthBar.SetHealth(Health);

        if(IsDead)
        {
            anim.SetTrigger("death");
        }
    }
    
    public bool IsDead
    {
        get
        {
            return Health == 0;
        }
    }
    

    /*private void IsControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null /*&& inventory.mItems.Count < 5)
        {
            inventory.AddItem(item);
            item.OnPickup();
        }
    }*/
}
