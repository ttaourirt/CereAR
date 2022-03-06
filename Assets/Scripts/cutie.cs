using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net.Http;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class cutie : MonoBehaviour
{
    Button ButtonSubmit;
    InputField email;
    InputField firstName;

    [SerializeField]
    private string uri = "https://api.hubapi.com/crm/v3/objects/contacts";

    // Start is called before the first frame update
    void Start()
    {
        //Email = email.GetComponent<InputField>().text;
        //FirstName = firstname.GetComponent<InputField>().text;
        GameObject.Find("ButtonSubmit").GetComponent<Button>().onClick.AddListener(PostData);
    }

    void PostData() => StartCoroutine(PostData_Coroutine());
    
    //class Prospects
    //{
    //    // Make sure all class attributes have relevant getter setter.
    //    // Roll Number
    //    public string email { get; set; }
    //    // Name of the student
    //    public string firstname { get; set; }

    //}
    IEnumerator PostData_Coroutine()
    {
        //string prospect;
        var mbox = "tata@tata.fr";
        var fbox = "Carmen";
        //var str = string.Format("{\"properties\":[",
        // "{\"property\":\"email\",\"value\":\"toto\"},",
        // "{\"property\":\"firstname\",\"value\":\"FirstName\"}]}");
        ///{"properties":{ "email": "tata@tata.fr","firstname":"tata"} "{properties: [{property:email,value:a @b.com},{property:firstname,value:Carmen}]}"
        var json = string.Concat("{\"properties\":",
              "{\"email\":\"", mbox, "\",",
              "\"firstname\":\"", fbox, "\"}}");
        //Prospects prospect = new Prospects()
        //{
        //    email = "totototo@toto.fr",
        //    // Name
        //    firstname = "Alex"
        //};
        //var cast = new Prospects()
        //{
        //    email = "totototo@toto.fr",
        //    // Name
        //    firstname = "Alex"
        //};


        //prospect.properties = new string[] { property.email = "testingapis@hubspot.com", property.firstname = "toto"};
        //string jsoning = "\{""email"":""titi@titi.fr"",""firstname"":""Alex""}'\";

        //string json = JsonSerializer.Serialize<Prospects>(cast);
        //var endpoint = "\"{ \"\"properties\":[\"{ \"property\":\"email\",\"value\":\"testingapis@hubspot.com\"}\"";
        var pro = "{\"property\":\"email\",\"value\":\"testingapis@hubspot.com\"},{ \"property\":\"firstname\",\"value\":\"Adrian\"}]}";
        var edn = "{\"email\":\"toto@toto.fr\", \"firstname\":\"tottotototo\"}";
        //string mail = "{email:tottotototo.toto.fr}";
        //string name = "{\"firstname\":\"totototo\"}";
        Debug.Log(json);
        //WWWForm form = new WWWForm();
        //form.AddField("email", "toto@tot.fr");
        //form.AddField("firstname", "name");
        //var js = JsonConvert.SerializeObject(prospect);
    
        
        UnityWebRequest www = new UnityWebRequest(uri, "POST");
        //www.SetRequestHeader("accept", "application/json");
        www.SetRequestHeader("authorization", "Bearer pat-eu1-df746919-de5e-4eb7-b5f8-a6a644519eb7");
        www.SetRequestHeader("Content-Type", "application/json");
        byte[] raw = Encoding.UTF8.GetBytes(json);
        www.uploadHandler = new UploadHandlerRaw(raw);
        www.downloadHandler = new DownloadHandlerBuffer();

         yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(":\nReceived: " + www.downloadHandler.text);
        }

    }
    
}
