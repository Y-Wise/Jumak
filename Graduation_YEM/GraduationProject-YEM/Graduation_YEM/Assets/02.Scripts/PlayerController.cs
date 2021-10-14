using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//코드 참고: 레트로의 유니티 게임 프로그래밍 에센스
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed; // 속력

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //수평축과 수직축의 입력값을 감지 후 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        
        //실제 이동 속도 = 입력값 * 이동 속력
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도 = (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //리지드바디의 속도 = newVelocity
        playerRigidbody.velocity = newVelocity;
    }
}
