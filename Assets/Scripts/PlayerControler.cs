using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Animator animator;
    public float Speed = 6f;
    public float RuningSpeed = 12f;
    private float Speed2 = 0f;

    public float Jump = 2f;

    private Rigidbody2D _rigidbody2D;
    private bool facingRight = false;
	public int Max = 100;
	public static int current;
    public HealthBar healt;
   

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
		current = Max;
		healt.setMaxHealth(Max);
    }

    // Update is called once per frame
    

    void Update()
    {
		if(current >= Max)
		current = Max;
        healt.setHealtd(current);
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f )
        {
            
                _rigidbody2D.AddForce(new Vector2(0, Jump), ForceMode2D.Impulse);
				
            
        }
		if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
          
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed2 = RuningSpeed;
			
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed2 = Speed;
			
        }

        move(Speed2);
    }

    private void move(float speed)
    {
        float horizontalValue= Input.GetAxisRaw("Horizontal");
        var move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * speed;
        if (facingRight && horizontalValue > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && horizontalValue < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = true;
        }
    }
}
