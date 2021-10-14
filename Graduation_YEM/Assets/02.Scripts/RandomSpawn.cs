//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RandomSpawn : MonoBehaviour
//{
//    CustomerController customer;
//    PlayerSkill playerSkill;
//    GameObject meObj = new GameObject(); // 자기자신
//    [SerializeField]
//    GameObject spawnPos;
//    Vector3 spawnPosVec = new Vector3(6.252f, -0.47f, 20f); // 스폰 위치

//    public List<int> order = new List<int>();

//    int cntSpawn = 0; // 스폰된 명수 체크

//    [SerializeField]
//    float spwanTime = 20f;

//    public bool isRemoveOrder = false;
//    public int removeID;
//    private void Awake()
//    {
//        customer = GetComponent<CustomerController>();
//        playerSkill = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSkill>();
//    }

//    private void Update()
//    {
//        // 4명까지만 스폰
//        if(cntSpawn < 4)
//        {
//            Spawn();
//            //스폰되고 성공적으로 이동하면 주문서 등록
//            if(customer.GoToTarget() == true) {
//                AddOrder();
//            }
//        }
//        if(playerSkill.isCompleteOrder == true)
//        {
//            RemoveOrder(playerSkill.completeDishId);
//        }
//    }

//    void Spawn()
//    {
//        // 20초에 한번씩 npc 스폰
//        spwanTime -= Time.deltaTime;

//        if (spwanTime <= 0)
//        {
//            customer.cusID = Random.Range(0, 3); // cusID가 0~3 중에 랜덤으로 스폰(원하는 order가 랜덤으로 정해지는 것)
//            Instantiate(meObj, spawnPosVec, Quaternion.identity); // 랜덤 스폰

//            cntSpawn++;
//            spwanTime = 20f;
//        }
//    }

//    void AddOrder()
//    {
//        order.Add(customer.cusID);
//    }

//    void RemoveOrder(int cusID)
//    {
//        order.Remove(cusID);
//        isRemoveOrder = true;
//        removeID = cusID;
//    }
//    //[SerializeField]
//    //int spawnPosIdx;
//    //PlayerSkill playerSkill;


//    //[SerializeField]
//    //GameObject[] Customers;


//    //int spawnIndex;
//    ////bool isSpawn = true;

//    //void AddOrder()
//    //{
//    //    CustomerController customer;
//    //    customer = 
//    //    order.Add(customer.cusID);
//    //}
//    //void CompleteQuest()
//    //{



//    //}
//}
