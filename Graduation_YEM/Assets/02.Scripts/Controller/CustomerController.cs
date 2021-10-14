//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CustomerController : MonoBehaviour
//{
//    GameObject meObj = new GameObject(); // 자기자신

//    RandomSpawn randomSpawn;
//    public int cusID;

//    Item orderItem;
//    Animator cusAnim;

//    Vector3 cusVec; // 손님의 이동 벡터
//    float cusSpeed = 3;

//    bool isWalk;
//    bool[] isArrive = new bool[4]{ false, false, false, false };
//    Vector3 targetPos0 = new Vector3(6.252f, -0.47f, 10.58f);
//    Vector3 targetPos1 = new Vector3(4.667f, -0.47f, 10.58f);

//    Vector3 preTargetPos0 = new Vector3(6.252f, -0.47f, 15f);
//    Vector3 preTargetPos1 = new Vector3(4.667f, -0.47f, 15f);

//    //public GameObject[] targetPos; // 목표 위치
//    //int posIndex = 0;
//    //public bool[] checkIn; // 목표 위치에 npc가 있는지


//    void Awake()
//    {
//        cusAnim = GetComponent<Animator>();
//        randomSpawn = GetComponent<RandomSpawn>();
//    }

//    private void Update()
//    {
//        GoToTarget();
//    }


//    //Outlet 앞에 있는 목표지점으로 직진. 도착완료했으므로 true 반환
//    public bool GoToTarget()
//    {
//        cusAnim.SetBool("isWalk", isWalk == true);

//        if(isArrive[0] == false)
//        {
//            transform.position = Vector3.MoveTowards(transform.position, targetPos0, cusSpeed * Time.deltaTime); // 현재위치, 목표위치, 속도)
//            isArrive[0] = true;

//            return true;

//        }
//        else
//        {
//            if (isArrive[1] == false)
//            {
//                transform.position = Vector3.MoveTowards(transform.position, targetPos1, cusSpeed * Time.deltaTime); // 현재위치, 목표위치, 속도)
//                isArrive[1] = true;

//                return true;
//            }
//            else
//            {
//                if(isArrive[2] == false)
//                {
//                    transform.position = Vector3.MoveTowards(transform.position, preTargetPos0, cusSpeed * Time.deltaTime); // 현재위치, 목표위치, 속도)
//                    isArrive[2] = true;

//                    return true;
//                }
//                else
//                {
//                    if(isArrive[3] == false)
//                    {
//                        transform.position = Vector3.MoveTowards(transform.position, preTargetPos1, cusSpeed * Time.deltaTime); // 현재위치, 목표위치, 속도)
//                        isArrive[3] = true;

//                        return true;
//                    }
//                    else
//                    {
//                        // 오브젝트 삭제
//                        Debug.Log("갈 곳이 없습니다.");
//                        return false;
//                    }
//                }
//            }
//        }
//    }

//    // 퀘스트 성공해서 order가 삭제되면 사라지기
//    void DeleteAway()
//    {
//        if(randomSpawn.isRemoveOrder == true)
//        {
//            if((cusID == randomSpawn.removeID)&&(transform.position.)
//            {

//            }
//        }
//    }

//}


///*
//R 1. npc가 랜덤으로 스폰(RandomSpawn)
//    1-1. 스폰은 20초에 한번씩. 4명이 스폰되면 스탑
//C 2. 스폰되면 목표 위치로 걸어감.(CustomerController.GoToTarget();)
//C 3. 목표 위치에 도착했는지 판단: bool[] isArrive
//R(<-C) 4. 목표 위치에 도착하면 List order에 add(RandomSpawn)
//P 5. 캐릭터가 outlet에서 isDown했을 때 손에 완성된 요리가 들려있고
//    이 완성된 요리가 order에 있는거면 그 order는 삭제

//C 6. order가 삭제되면 npc도 목표 위치로 이동 후 사라짐
//7. isArrive[]가 false가 되고 해당 index 위치로 스폰됐던 캐릭터 중 하나가 이동
//8. 캐릭터가 사라지면 스폰된 인원수가 -1;

//9. 1번부터 반복
// */
