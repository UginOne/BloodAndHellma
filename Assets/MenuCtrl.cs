using System;             
using System.Collections.Generic;
using System.IO;
using System.Net;                    
using System.Text;  
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public static class Global
{
    public static string login { get; set; }
    public static string password { get; set; }
    public static string serverAddress { get; set; }

    public static string authToken { get; set; }
    public static string sessionToken { get; set; }
}

[System.Serializable]
public class AuthInfo
{
    public string AuthToken;
    public string CurrentUserId;
    public string Lang;
    public string SessionToken;
}

public class MenuCtrl : MonoBehaviour
{
    private const string apiUrl = "/API/REST/Authorization/LoginWith?username=";
    private const string ApplicationToken = "285C8352AA7C67BFF882E4F236DECF51098C141AFB33A2AA4F7B34B4B3CEEF5DA30C848591DA55D5226C5D8D2C36432B12A5EF86C3D2EDF7E7C5781EC9D4E14A";

    public string AuthToken;
    public string CurrentUserId;
    public string SessionToken;

    public void LoadScene(string sceneName)
    {
        var authError = GameObject.Find("AuthErrorText");
        if (authError != null)
        {
            authError.GetComponent<Text>().enabled = false;
        }
        var inputLogin = GameObject.Find("Login");
        if (inputLogin != null)
        {
            Global.login = inputLogin.GetComponent<InputField>().text;     
        }
        var inputPassword = GameObject.Find("Password");
        if (inputPassword != null)
        {
            Global.password = inputPassword.GetComponent<InputField>().text;
        }
        var inputSettings = GameObject.Find("Settings");
        if (inputSettings != null)
        {
            Global.serverAddress = inputSettings.GetComponent<InputField>().text;
        }
        if (!string.IsNullOrEmpty(Global.serverAddress) && Auth(Global.login, Global.password, Global.serverAddress))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            if (authError != null)
            {
                authError.GetComponent<Text>().enabled = true;
            }
        }
    }

    public bool Auth(string login, string pass, string settings)
    {
        if (string.IsNullOrEmpty(settings)) return false;
        try
        {
            var url = settings + apiUrl;

            HttpWebRequest req =
                WebRequest.Create(String.Format("{0}{1}{2}", settings, apiUrl, login)) as HttpWebRequest;
            req.Headers.Add("ApplicationToken", ApplicationToken);
            req.Method = "POST";
            req.Timeout = 10000;
            req.ContentType = "application/json; charset=utf-8";

            var sentData = Encoding.UTF8.GetBytes(pass);
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);

            //получение ответа
            var res = req.GetResponse() as HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);

            var responseString = sr.ReadToEnd();
            //достаем необходимые данные

            Debug.Log(responseString);
            var dict = JsonUtility.FromJson<AuthInfo>(responseString);

            Debug.Log(dict);

            Global.authToken = dict.AuthToken;
            Global.sessionToken = dict.SessionToken;
            if (string.IsNullOrEmpty(Global.authToken) || string.IsNullOrEmpty(Global.sessionToken))
            {
                return false;
            }
        }
        catch (Exception ex)
        {
              Debug.Log(ex.Message);
            Debug.Log(ex);
            return false;
        }
        return true;
    } 
}
