using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float speed = 8f;
    public float rotSpeed = 8f;
    public float jumpForce = 10f;
    public float gravity = 9.81f;
    public float lengthToGround = 2.5f;
    float zMove;
    float rot;

    //components
    Rigidbody rb;
    Animator anim;
    public LayerMask groundLayer;
    Vector3 moveDir = Vector3.zero;


    //Triggers
    bool walking;
    public bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), lengthToGround, groundLayer);


        //Draw Raycast downwards
        //Vector3 downRay = transform.TransformDirection(Vector3.down) * lengthToGround;
        //Debug.DrawRay(transform.position, downRay, Color.blue);


        rot = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        if (grounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("walking",true);
                moveDir = new Vector3(0f, 0f, 1f);
                moveDir *= speed * Time.deltaTime;
                moveDir = transform.TransformDirection(moveDir);
            }
            else
            {
                anim.SetBool("walking", false);
                moveDir = new Vector3(0f, 0f, 0f);
            }
        }

        //moveDir.y -= gravity * Time.deltaTime;
        Vector3 rotate = new Vector3(0f, rot, 0f);
        transform.Translate(moveDir);
        transform.Rotate(rotate);
    }
}
