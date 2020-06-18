using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class M_Utility 
{
    /// <summary>
    /// texture转换成Texture2d
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static Texture2D TextureToTexture2D(Texture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);

        return texture2D;
    }

    /// <summary>
    /// 将Bytes[]转换成Texture2d
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static Texture2D GetTexture2d(byte[] bytes)
    {
        //先创建一个Texture2D对象，用于把流数据转成Texture2D
        Texture2D texture = new Texture2D(10, 10);
        texture.LoadImage(bytes);//流数据转换成Texture2D
        //创建一个Sprite,以Texture2D对象为基础
        return texture;
    }


    /// <summary>
    /// Texture2d转换成SPRITE
    /// </summary>
    /// <param name="tex2">Texture2D</param>
    /// <returns></returns>
    public static Sprite Texture2DtoSprite(Texture2D tex2)
    {
        Sprite s = Sprite.Create(tex2, new Rect(0, 0, tex2.width, tex2.height), Vector2.zero);
        return s;
    }
    /// <summary>
    /// 在一个范围内随机几个不重复的数值
    /// </summary>
    /// <param name="min">从多少开始</param>
    /// <param name="Max">结束数值是多少</param>
    /// <param name="count">取得几个数值</param>
    /// <returns></returns>
    public static List<int> GetRandom(int min, int Max, int count)
    {
        List<int> temp = new List<int>();
        List<int> temp1 = new List<int>();

        for (int i = min; i < Max+1; i++)
        {
            temp.Add(i);
        }

        if (Max + 1 - min < count)
        {
            return temp;
        }
        else
        {
            while(temp1.Count< count)
            {
               int tempi =  Mathf.FloorToInt(Random.Range(0, temp.Count));
                temp1.Add(temp[tempi]);
                temp.Remove(temp[tempi]);
            }
            return temp1;
        }
    }
}
