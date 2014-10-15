using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using WWWKit;
using MiniJSON;
using System;

public class postTest : MonoBehaviour {
    WWWClientManager cm;
    string ipaddr = "172.23.16.64:3000/users/";

	// Use this for initialization
	void Start () {
        cm = new WWWClientManager(this);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void postMessage()
    {
        string url = ipaddr + "regist";
        Dictionary<string, string> post = new Dictionary<string, string>();

        // ランダムな名前を生成
        //Guid g = System.Guid.NewGuid();
        //string name = g.ToString("N").Substring(0, 4);
        //Debug.Log(name);
        string rName = "ABCDEFGHIJKLNMOPQRSTUVWYZ";
        string nName = string.Empty;
        for (int i = 0; i < 3; i++)
        {
            int rnd = UnityEngine.Random.Range(0,25);
            nName += rName.Substring(rnd,1);
        }

        post.Add("name", nName);
        int score = UnityEngine.Random.Range(0,101);
        post.Add("score", score.ToString());
        cm.POST(url, post, "ReceivePost");
        Debug.Log(nName.ToString() + " " + score.ToString() + " " + "POSTリクエストを送信しました。");
    }

    void ReceivePost(WWW www)
    {
        Debug.Log(www.text);
    }
}
