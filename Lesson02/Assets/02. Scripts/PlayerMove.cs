using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    const float SPEED_JUMP = 5.0f;
    const float SPEED_JUMP_Move = 3.0f;
    
    Rigidbody2D rb;
    bool leftPressed = false;
    bool rightPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            float dist = SPEED_JUMP_Move * Time.deltaTime;
            Vector2 pos = transform.position;
            
            // 왼쪽 이동
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                leftPressed = false;
            }
            if (leftPressed)
            {
                pos.x -= dist;
            }

            //오른쪽 이동
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                rightPressed = false;
            }
            if (rightPressed)
            {
                pos.x += dist;
            }
            transform.position = pos;

            // 점프
            if ( //Input.GetKeyDown(KeyCode.Space) ||
                 Input.GetMouseButtonDown(0))
            {
                Vector2 moveVelocity = rb.velocity;
                moveVelocity.y = SPEED_JUMP;
                rb.velocity = moveVelocity;
            }
            /*
            if (Input.GetAxis("Vertical") > 0.5f)
            {
                Vector2 moveVelocity = rb.velocity;
                moveVelocity.y = SPEED_JUMP;
                rb.velocity = moveVelocity;
            }
            */

            // 순간이동 - 오른쪽 버튼
            if (Input.GetMouseButtonDown(1))
            {
                // 마우스 위치를 알아내 메인 카메라의 월드 공간 좌표로 변환한다.
                Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 주인공 캐릭터를 그곳으로 이동한다.
                transform.position = newPos;

                // 주인공 캐릭터의 리지드바디 속도를 0으로 설정한다.
                rb.velocity = Vector2.zero;
            }
        }
    }
}
