using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public Web Web; //Web 스크립트 
    public UserInfo UserInfo;
    public Login Login;

    public GameObject Items; //items 오브젝트 연결 

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; //Main 스크립트
        Web = GetComponent<Web>(); //Web 스크립트 가져오기 
        UserInfo = GetComponent<UserInfo>(); // UserInfo스크립트 가져오기 
    }

}
