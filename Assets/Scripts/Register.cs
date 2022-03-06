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

public class Register : MonoBehaviour
{
        //InputField email;
        //InputField firstName;
        public GameObject Screen2;
        public GameObject email;
        public GameObject firstname;
        private string Email;
        private string FirstName;
        private string form;
        private bool EmailValid = false;

        [SerializeField]
        private string uri = "https://api.hubapi.com/crm/v3/objects/contacts";
        private string token = "Bearer pat-eu1-df746919-de5e-4eb7-b5f8-a6a644519eb7";

        //public void Send()
        //{
        //    Upload();
        //}


    // Start is called before the first frame update
    void Start()
        {
            //Email = email.GetComponent<InputField>().text;
            //FirstName = firstname.GetComponent<InputField>().text;
            GameObject.Find("ButtonSubmit").GetComponent<Button>().onClick.AddListener(PostData);
        }

        void PostData() => StartCoroutine(Upload());
        private IEnumerator Upload()
        {

        Email = email.GetComponent<InputField>().text;
        FirstName = firstname.GetComponent<InputField>().text;

        if (Input.GetKeyDown(KeyCode.Return))
            {
                if (email.GetComponent<InputField>().isFocused)
                {
                    firstname.GetComponent<InputField>().Select();
                }
            }
            if (Email != "" && FirstName != "")
            {

                bool EM = false;
                bool FI = false;

                if (Email != "")
                    {   // The last letter can't be a number
                        if (!EmailValid)
                        {
                            if (Email.Contains("@"))
                            {
                                if (Email.Contains("."))
                                {
                                    EM = true;
                                }
                                else
                                {
                                    Debug.Log("Email is Incorrect");
                                }
                            }
                            else
                            {
                                Debug.Log("Email is Incorrect");
                            }
                        }
                        else
                        {
                            Debug.Log("Email is Incorrect");
                        }

                    }
                    else
                    {

                        Debug.Log("Email field Empty");

                    }
                if (FirstName != "")
                {
                    if (FirstName.Length > 1)
                    {
                        FI = true;
                    }
                    else
                    {
                        Debug.Log("FirstName must to be at least two Characters long");
                    }

                }
                else
                {
                    Debug.Log("FirstName field Empty");

                }

                if (EM == true && FI == true)
                {
                    //var mbox = "tata@tata.fr";
                    //var fbox = "Carmen";
                    var endpoint = string.Concat("{\"properties\":",
                                              "{\"email\":\"", Email, "\",",
                                              "\"firstname\":\"", FirstName, "\"}}");

                    
                    UnityWebRequest www = new UnityWebRequest(uri, "POST");
                    {
                        www.SetRequestHeader("authorization", token);
                        www.SetRequestHeader("Content-Type", "application/json");
                        byte[] raw = Encoding.UTF8.GetBytes(endpoint);
                        www.uploadHandler = new UploadHandlerRaw(raw);
                        www.downloadHandler = new DownloadHandlerBuffer();
                        yield return www.SendWebRequest();

                        if (www.result != UnityWebRequest.Result.Success)
                        {
                            Debug.Log(www.error);
                            Debug.Log(www.downloadHandler.text);
                    }
                        else
                        {
                            Debug.Log("Form upload complete!");
                            //GameObject.Find("ButtonExit").GetComponent<Button>().onClick.Invoke();
                            //GameObject.Find("RealShare").GetComponent<Button>().onClick.Invoke();
                            Screen2.gameObject.SetActive(false);
                            GameObject.Find("Captur").GetComponent<Button>().onClick.Invoke();
                            Debug.Log(":\nReceived: " + www.downloadHandler.text);
                    }
                    }
                }
            }else {
            Debug.Log("Maybe Write your informations first ?");
            }
        }
    }


