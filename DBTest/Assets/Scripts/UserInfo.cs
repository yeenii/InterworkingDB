using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    public string UserName;
    public string UserPassword;
    public string Level;
    public string Coins;

    public void SetCrendentials(string username, string password)
    {
        UserName = username; //Web ��ũ��Ʈ�� Login() �Լ� 
        UserPassword = password; //Web ��ũ��Ʈ�� Login() �Լ� 

    }

    public void SetID(string id)
    {
        UserID = id;
    }
}
