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
        UserName = username; //Web 스크립트의 Login() 함수 
        UserPassword = password; //Web 스크립트의 Login() 함수 

    }

    public void SetID(string id)
    {
        UserID = id;
    }
}
