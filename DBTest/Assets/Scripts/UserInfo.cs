using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    string UserName;
    string UserPassword;
    string Level;
    string Coins;

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
