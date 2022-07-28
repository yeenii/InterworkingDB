using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Web: MonoBehaviour
{


    void Start()
    {

        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser","123456"));
        //StartCoroutine(RegisterUser("testuser3", "123456"));
    }

    public void ShowUserItems()
    {
        //StartCoroutine(GetItemsIDs(Main.Instance.UserInfo.UserID, callback));
    }

    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/unityBackend/GetUsers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }


    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                Main.Instance.UserInfo.SetCrendentials(username, password); // UserInfo.cs
                Main.Instance.UserInfo.SetID(www.downloadHandler.text);

                //If we logged in correctly 로그인을 올바르게 했다면 
                if (www.downloadHandler.text.Contains("wrong Credentials.") || www.downloadHandler.text.Contains("Username does not exist"))
                {
                    Debug.Log("Try Again.");
                }
                else
                {
                    Main.Instance.Items.SetActive(true); //Items 오브젝트
                    Main.Instance.Login.gameObject.SetActive(false);
                }
               
            }
        }
    }

    IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetItemsIDs(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/GetItemsIDs.php", form))
        {
            
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                string jsonArray = www.downloadHandler.text; //JSON

                //Call callback function to pass result 
                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetItem(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/GetItem.php", form))
        {

            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                string jsonArray = www.downloadHandler.text; //JSON

                //Call callback function to pass result 
                callback(jsonArray);
            }
        }
    }

   
}