using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerQAScoreboard : MonoBehaviour
{

    public static ServerQAScoreboard instance;

    public List<ServerQAUnit> serverQANodes = new List<ServerQAUnit>();

    public   GameObject Graph;

    public ParticleSystem virtroryParticle;

    public GameObject[] turnOffGameObject;

    public QATickTextUpdate qATickTextUpdate;

    public ServerQADotsCtr serverQADotsCtr;

    public ServerQAVirtoryParticle serverQAVirtoryParticle;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        Hide();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        Graph.SetActive(true);

        foreach (var item in serverQANodes)
        {
            item.Show();
        }

        virtroryParticle.Play();

        foreach (var item in turnOffGameObject)
        {
            item.SetActive(false);
        }

        qATickTextUpdate.Hide();

        serverQADotsCtr.Hide();

        serverQAVirtoryParticle.Show();
    }

    public void Hide()
    {
        Graph.SetActive(false);

        foreach (var item in serverQANodes)
        {
            item.Hide();
        }

        virtroryParticle.Stop();
    }

    public void SetText(string s)
    {

        Debug.Log(s);
       string[] temp1= s.Split('&');

        foreach (var item in serverQANodes)
        {
            int i =   serverQANodes.IndexOf(item);

            string[] temp2 = temp1[i].Split('_');

            item.SetText(temp2[0], temp2[1]);
        }
    }
}
