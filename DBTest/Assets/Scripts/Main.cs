using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public Web Web; //Web ��ũ��Ʈ 
    public UserInfo UserInfo;
    public Login Login;

    public GameObject Items; //items ������Ʈ ���� 

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; //Main ��ũ��Ʈ
        Web = GetComponent<Web>(); //Web ��ũ��Ʈ �������� 
        UserInfo = GetComponent<UserInfo>(); // UserInfo��ũ��Ʈ �������� 
    }

}
