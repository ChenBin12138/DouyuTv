using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkServer : MonoBehaviour {

    private static LinkServer _instance;

    public static string serverip = "http://open.douyucdn.cn/api/RoomApi";      //地址

    public static LinkServer Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start() {

    }

    /// <summary>
    /// 获取直播房间列表信息
    /// </summary>    
    /// <param name="_liveName">分类ID或别名</param>
    /// <param name="callback">回调</param>
    /// <param name="_offset">页数偏移</param>
    /// <param name="_limit">获取数量</param>
    public static void GetLiveList(string _liveName,Action<string> callback,int _offset = 0, int _limit = 30){
        string url = serverip + "/" + _liveName + "?offset" + _offset + "&limit" + _limit;

        if (Instance != null) {   Instance.GetData(url, callback); }
        else { if (callback != null) callback(null);  }
    }

    /// <summary>
    /// 获取直播分类信息
    /// </summary>
    /// <param name="type"></param>
    public static void GetLiveClassify(string type, Action<string> callback) {
        string url = serverip + "/" + type;
        if (Instance != null) { Instance.GetData(url, callback); }
        else { if (callback != null) callback(null); }
    }




    public void GetData(string url, Action<string> callback) {
        StartCoroutine(IGetData(url, callback));
    }

    /// <summary>
    /// 请求接口
    /// </summary>
    /// <param name="url">请求路径</param>
    /// <param name="callback">成功回调</param>
    /// <returns></returns>
    private IEnumerator IGetData(string url,Action<string> callback) {
        WWW www = new WWW(url);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (callback != null)
                callback(www.text);
        }
        else {
            if (callback != null)
                callback(null);

            Debug.LogError("Error : " + www.error);
        }
    }


}
