using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //�߰� 
using SimpleJSON;

public class Items : MonoBehaviour
{
    Action<string> _createItemsCallback;

    // Start is called before the first frame update
    void Start()
    {   
        //json ���� �ҷ����� 
        _createItemsCallback = (jsonArrayString) => {
            StartCoroutine(CreateItemsRoutine(jsonArrayString));
        };

        CreateItems();
    }

    public void CreateItems()
    {   
            string userId = Main.Instance.UserInfo.UserID;
            StartCoroutine(Main.Instance.Web.GetItemsIDs(userId, _createItemsCallback));
       
    }

    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
        //Parsing json array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //Create local variables
            bool isDone=false; //are we done downloading?
            string itemId = jsonArray[i].AsObject["itemID"];
            JSONObject itemInfoJson = new JSONObject();

            //Create a callback to get the information from Web.cs
            Action<string> getItemInfoCallback = (itemInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };
            StartCoroutine(Main.Instance.Web.GetItem(itemId, getItemInfoCallback));

            //wait until the callback  is called from WEB (info finished downloading)
            yield return new WaitUntil(() => isDone == true);

            //Instantiate GameObject (item prefab)
            GameObject item = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
            item.transform.SetParent(this.transform);
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = Vector3.zero;

            //Fill information
            item.transform.Find("Name").GetComponent<Text>().text=itemInfoJson["name"];
            item.transform.Find("Price").GetComponent<Text>().text = itemInfoJson["price"];
            item.transform.Find("Description").GetComponent<Text>().text = itemInfoJson["description"];

            //continue to the next  item

        }

    }
}
