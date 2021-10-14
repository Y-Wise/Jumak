using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public Image backgroundImage;
    private void OnMouseUp()
    {
        //if(GetComponent)
        //로그인씬(씬2)으로 전환
        SceneManager.LoadScene("02_Login");
    }
}
