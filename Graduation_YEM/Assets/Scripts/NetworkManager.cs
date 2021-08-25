using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon;






public class NetworkManager : MonoBehaviourPunCallbacks
{

    

    public Character currentCharacter;

    void Setting()
    {
        Screen.SetResolution(1920, 1080, true);
        PhotonNetwork.AutomaticallySyncScene = true;
       
    }
    public static NetworkManager NM;
    void Awake()
    {
        NM = this;
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    public GameObject CharGirl;
    public GameObject CharBoy;

    [Header("DisconnectPanel")]
    public InputField NickNameInput;

    [Header("LobbyPanel")]
    public GameObject LobbyPanel;
    public InputField RoomInput;
    public Text WelcomeText;
    public Text LobbyInfoText;
    public Button[] CellBtn;
    public Button PreviousBtn;
    public Button NextBtn;
    public GameObject Help;


    [Header("RoomPanel")]
    public GameObject RoomPanel;
    public Text ListText;
    public Text RoomInfoText;
    public Text[] ChatText;
    public InputField ChatInput;
    public Button StartBtn;

    [Header("SelectPanel")]
    public GameObject SelectPanel;
    public Button BoyButton;
    public Button GirlButton;

    

    [Header("ETC")]
    public Text StatusText;
    public PhotonView PV;

    List<RoomInfo> myList = new List<RoomInfo>();
    int currentPage = 1, maxPage, multiple;

    void Start()
    {
        PV = photonView;
       
        //CharacterCamera = GameObject.Find("CharacterCamera");
        //CharacterCamera2 = GameObject.Find("CharacterCamera2");

    }




    #region 방리스트 갱신
    // ◀버튼 -2 , ▶버튼 -1 , 셀 숫자
    public void MyListClick(int num)
    {
        if (num == -2) --currentPage;
        else if (num == -1) ++currentPage;
        else PhotonNetwork.JoinRoom(myList[multiple + num].Name);
        MyListRenewal();
    }

    void MyListRenewal()
    {
        // 최대페이지
        maxPage = (myList.Count % CellBtn.Length == 0) ? myList.Count / CellBtn.Length : myList.Count / CellBtn.Length + 1;

        // 이전, 다음버튼
        PreviousBtn.interactable = (currentPage <= 1) ? false : true;
        NextBtn.interactable = (currentPage >= maxPage) ? false : true;

        // 페이지에 맞는 리스트 대입
        multiple = (currentPage - 1) * CellBtn.Length;
        for (int i = 0; i < CellBtn.Length; i++)
        {
            CellBtn[i].interactable = (multiple + i < myList.Count) ? true : false;
            CellBtn[i].transform.GetChild(0).GetComponent<Text>().text = (multiple + i < myList.Count) ? myList[multiple + i].Name : "";
            CellBtn[i].transform.GetChild(1).GetComponent<Text>().text = (multiple + i < myList.Count) ? myList[multiple + i].PlayerCount + "/" + myList[multiple + i].MaxPlayers : "";
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int roomCount = roomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!roomList[i].RemovedFromList)
            {
                if (!myList.Contains(roomList[i])) myList.Add(roomList[i]);
                else myList[myList.IndexOf(roomList[i])] = roomList[i];
            }
            else if (myList.IndexOf(roomList[i]) != -1) myList.RemoveAt(myList.IndexOf(roomList[i]));
        }
        MyListRenewal();
    }
    #endregion


    #region 서버연결
   

    void Update()
    {
        StatusText.text = PhotonNetwork.NetworkClientState.ToString();
        LobbyInfoText.text = (PhotonNetwork.CountOfPlayers - PhotonNetwork.CountOfPlayersInRooms) + "로비인원 / " + PhotonNetwork.CountOfPlayers + "접속유저";


        if (!PhotonNetwork.IsMasterClient) return;
         ShowStartBtn();
    }
    

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        //SelectPanel.SetActive(true);
        LobbyPanel.SetActive(true);
        RoomPanel.SetActive(false);

        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        WelcomeText.text = "어서오세요." + PhotonNetwork.LocalPlayer.NickName + "님";
        myList.Clear();
    }

    public void Disconnect() => PhotonNetwork.Disconnect();

    public override void OnDisconnected(DisconnectCause cause)
    {
        LobbyPanel.SetActive(false);
        RoomPanel.SetActive(false);
       // PlayerPanel.SetActive(false);
    }
    #endregion


    #region 방
    public void CreateRoom() => PhotonNetwork.CreateRoom(RoomInput.text == "" ? "Room" + Random.Range(0, 100) : RoomInput.text, new RoomOptions { MaxPlayers = 2 },null);

    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    public override void OnJoinedRoom()
    {
        RoomPanel.SetActive(true);
        RoomRenewal();
        ChatInput.text = "";
        for (int i = 0; i < ChatText.Length; i++) ChatText[i].text = "";
       // PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity).name="Player";
    }

    public override void OnCreateRoomFailed(short returnCode, string message) { RoomInput.text = ""; CreateRoom(); }

    public override void OnJoinRandomFailed(short returnCode, string message) { RoomInput.text = ""; CreateRoom(); }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RoomRenewal();
        ChatRPC("<color=yellow>" + newPlayer.NickName + "님이 참가하셨습니다</color>");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RoomRenewal();
        ChatRPC("<color=yellow>" + otherPlayer.NickName + "님이 퇴장하셨습니다</color>");
    }

    public void RoomRenewal()
    {
        ListText.text = "";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            ListText.text +=  "\r\n" + PhotonNetwork.PlayerList[i].NickName + "\r\n" + ((i + 1 == PhotonNetwork.PlayerList.Length) ? "" : " ");
        RoomInfoText.text = "방 이름:"+PhotonNetwork.CurrentRoom.Name +"  "+"참가인원:" + PhotonNetwork.CurrentRoom.PlayerCount + " / " + PhotonNetwork.CurrentRoom.MaxPlayers + "명";
    }
    #endregion

    #region 게임시작,도움말 버튼
    public void ShowStartBtn()
    {
        StartBtn.gameObject.SetActive(true);
        StartBtn.interactable= PhotonNetwork.CurrentRoom.PlayerCount >=2 ;
    }
   
    public void GameStart()
    {
        //PV.RPC("GirlChar", RpcTarget.MasterClient);
       // PV.RPC("BoyChar", RpcTarget.Others);
        PV.RPC("GameStartRPC", RpcTarget.AllViaServer);
        // PV.RPC("GameStart02RPC", RpcTarget.Others);
      //  PV.RPC("Player01Start", RpcTarget.MasterClient);
       // PV.RPC("Player02Start", RpcTarget.Others);
    }

    [PunRPC]
    public void GameStartRPC()
    {   
        
        PhotonNetwork.LoadLevel("05_Game_Main");
    }
    /*[PunRPC]
    public void CamTrans()
    {
        GamePanel.SetActive(true);
        // PhotonNetwork.LoadLevel("05_Game_Main");
    }
    /*[PunRPC]
    public void GirlChar()
    {
        Girl.gameObject.SetActive(true);

    }
    [PunRPC]
    public void BoyChar()
    {
        Boy.gameObject.SetActive(true);

    }*/
    /*[PunRPC]
    public void Player01Start()
    {
        Player01Panel.SetActive(true);
    }
    [PunRPC]
    public void Player02Start()
    {
        Player02Panel.SetActive(true);
    }*/
    /*[PunRPC]
    public void GameStart02RPC()
    {
        PhotonNetwork.LoadLevel("GameScene02");

    }*/

    #endregion

    #region 채팅
    public void Send()
    {
        PV.RPC("ChatRPC", RpcTarget.All, PhotonNetwork.NickName + " : " + ChatInput.text);
        ChatInput.text = "";
    }

    [PunRPC] // RPC는 플레이어가 속해있는 방 모든 인원에게 전달한다
    void ChatRPC(string msg)
    {
        bool isInput = false;
        for (int i = 0; i < ChatText.Length; i++)
            if (ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = msg;
                break;
            }
        if (!isInput) // 꽉차면 한칸씩 위로 올림
        {
            for (int i = 1; i < ChatText.Length; i++) ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = msg;
        }
    }

    #endregion

    
    

}
