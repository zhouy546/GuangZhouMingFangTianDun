using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;

using UnityEngine.UI;
using System.Xml;

public class ReadJson : MonoBehaviour {


    public static ReadJson instance;

    //  public  Ntext ntext;

    private JsonData itemDate;
    private JsonData iosData;


    private string jsonString;
    private string IOSjsonString;

    public void Start()
    {
        StartCoroutine(initialization());




    }

    public IEnumerator initialization() {
        if (instance == null)
        {

            instance = this;

        }


#if UNITY_EDITOR
    //   yield return StartCoroutine(iosReadJson());

     //   yield return StartCoroutine(readJson());

        ReadIosXml();
#endif

#if UNITY_STANDALONE_WIN
        yield return StartCoroutine(iosReadJson());

        yield return StartCoroutine(readJson());



#endif


#if UNITY_IOS

        ReadIosXml();
#endif

        yield return new WaitForSeconds(0.1f);
        EventCenter.Broadcast(EventDefine.INI);

    }

    public void ReadIosXml() {
        string path = Application.streamingAssetsPath + "/IOS.xml";

  
        XmlDocument xml = new XmlDocument();

        xml.Load(path);

        XmlNodeList xmlNodeList = xml.SelectSingleNode("config").ChildNodes;

        foreach (var item in xmlNodeList)
        {
            XmlElement xmlElement = (XmlElement)item;

            if (xmlElement.Name == "id")
            {
                GameManager.PADID = int.Parse(xmlElement.InnerText);

            }

            if (xmlElement.Name == "serverip")
            {
                GameManager.ServerIp = xmlElement.InnerText;
            }

            if (xmlElement.Name == "serverudpport")
            {
                GameManager.ServerUDPPort = int.Parse( xmlElement.InnerText);
            }

            if (xmlElement.Name == "servergameport")
            {
                GameManager.ServerGamePort = int.Parse(xmlElement.InnerText);
            }

        }

        }



    IEnumerator iosReadJson()
    {
        string spath = Application.streamingAssetsPath + "/IosConfig.json";

        Debug.Log("IOS PATH:  "+spath);

        WWW www = new WWW(spath);

        yield return www;

        IOSjsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

        iosData = JsonMapper.ToObject(IOSjsonString.ToString());

        JsonData iosindoData = iosData["info"];

        GameManager.PADID =int.Parse(iosData["info"]["id"].ToString());

        GameManager.ServerIp = iosData["info"]["serverip"].ToString();

        GameManager.ServerUDPPort = int.Parse(iosData["info"]["serverudpport"].ToString());

        GameManager.ServerGamePort = int.Parse(iosData["info"]["servergameport"].ToString());

        yield return new WaitForSeconds(1f);


    }

    IEnumerator readJson() {
        string spath = Application.streamingAssetsPath + "/information.json";

        Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

       itemDate = JsonMapper.ToObject(jsonString.ToString());


        JsonData QSdata = itemDate["QA"];

        for (int i = 0; i < QSdata.Count; i++)
        {
            int num = i;
            string question = QSdata[i]["q"].ToString();
            string[] A1 = new string[2];
            A1[0] = QSdata[i]["a"].ToString();
            A1[1] = QSdata[i]["b"].ToString();
            int RightAnswer =int.Parse( QSdata[i]["rightanswer"].ToString());

            QAinfo QAtemp = new QAinfo(num,question,A1,RightAnswer);

            GameManager.kp_id_qAinfos.Add(i, QAtemp);
        }

        GameManager.ProgramName = itemDate["Setup"]["programname"].ToString();
        GameManager.Xpos = int.Parse(itemDate["Setup"]["xpos"].ToString());
        GameManager.Ypos = int.Parse(itemDate["Setup"]["ypos"].ToString());
        GameManager.ScreenWidth = int.Parse(itemDate["Setup"]["screenwidth"].ToString());
        GameManager.ScreenHeight = int.Parse(itemDate["Setup"]["screenheight"].ToString());
        GameManager.M_isServer = int.Parse(itemDate["Setup"]["IsServer"].ToString()) == 1 ? true : false;


        JsonData videoData = itemDate["video"];

        for (int i = 0; i < videoData.Count; i++)
        {
            string Groundurl = videoData[i]["Groundurl"].ToString();
            string WallUrl = videoData[i]["WallUrl"].ToString();
            string udp= videoData[i]["udp"].ToString();
            bool isScreenProtect = int.Parse(videoData[i]["loop"].ToString()) == 1 ? true : false;
            bool isBackToScreenProtect= int.Parse(videoData[i]["isBackToScreenProtect"].ToString()) == 1 ? true : false;
            bool isLoop = int.Parse(videoData[i]["iscreenprotect"].ToString()) == 1 ? true : false;


            VideoInfo tempVideoInfo = new VideoInfo(Groundurl, WallUrl, udp, isLoop, isBackToScreenProtect, isScreenProtect);
            GameManager.kp_udp_VideoInfo.Add(udp, tempVideoInfo);         
        }

        GameManager.VolumeUpUDP = itemDate["Setup"]["VolumeUp"].ToString();
        GameManager.VolumeDownUDP =itemDate["Setup"]["VolumeDown"].ToString();
        GameManager.StopUdp = itemDate["Setup"]["Stop"].ToString();



    }

}
