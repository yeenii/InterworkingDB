using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;


    // Start is called before the first frame update
    void Start()
    {
        //로그인 버튼을 클릭하면 
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login(UsernameInput.text, PasswordInput.text));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
