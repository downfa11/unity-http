using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class WebServer : MonoBehaviour
{

    [SerializeField] InputField code;

      public void BtnCodeSubmit() //InputField 말고도 Submit Button을 만들어줘야합니다.
    {
        StartCoroutine(CheckCode(codes.text)); 
    }

    IEnumerator SendDataToServer(string code)
    {

        url = "주소/getDataFromServer"
        object data = new object();
        string json = JsonConvert.SerializeObject(data); // JsonUtility.ToJson(data); 해도됨
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] body = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // HTTP 요청을 보내고 결과를 기다립니다.
        yield return request.SendWebRequest();

        // HTTP 요청이 성공하면 결과를 출력합니다.
        if (request.result == UnityWebRequest.Result.Success)
        {
            string result = request.downloadHandler.text;
            object dict = JsonConvert.DeserializeObject<object>(result);

            Debug.Log("Receive Result: " + result);
        }
        // HTTP 요청이 실패하면 에러를 출력합니다.
        else
        {
            codeInfo.text = "Http 요청이 실패했습니다.";
            Debug.Log("Receive Error: " + request.error);
        }
    }
    
    
    }