using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static NetworkManager;
//using static PlayerSkill;


public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public PhotonView PV;
    public Text NickNameText;


    

    NetworkManager NM = NetworkManager.NM;

    

    void Start()
    {
       
        PV = photonView;

    }
    


    void Awake()
    {
       

        //닉네임
        NickNameText.text = PhotonNetwork.LocalPlayer.NickName;

        //NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;


    }
    

  
     void update()
    {      // if (!PV.IsMine) return;
        //  NM.ValueText.text = RealScore.ToString();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
