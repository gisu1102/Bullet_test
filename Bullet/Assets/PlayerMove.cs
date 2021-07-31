using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float maxSpeed;
    SpriteRenderer spriterenderer;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //단발적인 이벤트는 Update //물리적 
    void Update()
    {
        //버튼에서 손 땔 때 속도 고정값
        if (Input.GetButtonUp("Horizontal"))
        {
            // rigid.velocity.nomarlized  //단위벡터를 구할때
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f,
                rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
            spriterenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        //Animation IsRunning
        if (rigid.velocity.normalized.x == 0)
            anim.SetBool("IsRunning", false);
        else
            anim.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed*(-1)) //Left max Speed
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);

    }
}
