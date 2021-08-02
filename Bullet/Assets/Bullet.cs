using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /* 
     * 총알 날아감 //bool 타입 생성  수정 시급
     * --1.직선  **
     * --2.포물선
     * 
     * 맞는 물체 구별 //
     * --1.몬스터 **
     * --2.사물  **
     * 
     * 파괴
     * --1.총알 **
     * 
     * 총알 발사 후 일정 시간 이후 파괴 **
     * //총알 발사 딜레이 **
     */




    public float Speed;
    public float BulletLifeTime;
    public float distance;
    public LayerMask IsLayer;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroyBullet), BulletLifeTime);// 총알 발사 후 일정 시간뒤 파괴
    }

    // Update is called once per frame
    void Update() //물리적 효과 단발성
    {
        /*RaycastHit2D ray = Physics2D.Raycast(transform.position,
            transform.right, distance, IsLayer);
        if (ray.collider != null)
        {
            if(ray.collider.tag == "Monster")
            {
                Debug.Log("Monster HIT!");
                //Take Damage


                DestroyBullet();
            }
            else if (ray.collider.tag == "Ground")
            {
                Debug.Log("Ground ");
                DestroyBullet();
            }
            
        }*/

    }
    void FixedUpdate()
    {
        //총알 전진


        transform.Translate(Vector2.right * Speed * Time.deltaTime);

    }
    /// <summary>
    /// DestroyBullet-총알 제거 함수
    /// </summary>
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("Monster HIT!");
            //Take Damage

            Destroy(collision.gameObject);
            DestroyBullet();
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Ground ");
            DestroyBullet();
        }
    }
    //충돌시 지형==0 몬스터==1
    /*int Hit()
    {
        //RaycastHit2D ray =Physics2D.Raycast(시작점,방향,길이,레이어 선택)

        if (ray.collider.tag == "Monster")
        {
            return 1;
        }
        else if (ray.collider.tag == "Top"){
            return 0;
        }
    }*/


}
