﻿using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class RemoveTheWindowsBorder : MonoBehaviour
{

    [DllImport("user32.dll")]
    static extern IntPtr SetWindowLong(IntPtr hwnd, int _nIndex, int dwNewLong);
    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);



    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

    const uint SWP_SHOWWINDOW = 0x0040;
    const int GWL_STYLE = -16;  //边框用的
    const int WS_BORDER = 1;
    const int WS_POPUP = 0x800000;

    int offset = 2;

     int _posX = -1;
     int _posY = -1;
     int _Txtwith;
     int _Txtheight;
    void Start()
    {
    
#if !UNITY_EDITOR && UNITY_STANDALONE_WIN

        EventCenter.AddListener(EventDefine.INI, ini);

#endif
    }

    private void ini()
    {

        if (GameManager.M_isServer)
        {
            Screen.SetResolution(GameManager.ScreenWidth, GameManager.ScreenHeight, false);
            StartCoroutine("Setposition");
            Cursor.visible = false;
        }



    }

    private void Update()
    {
        
    }

    IEnumerator Setposition()
    {
        yield return new WaitForSeconds(0.5f);      //不知道为什么发布于行后，设置位置的不会生效，我延迟0.1秒就可以

        IntPtr hWnd = FindWindow(null, GameManager.ProgramName);



        SetWindowLong(hWnd, GWL_STYLE, WS_POPUP);      //无边框

        SwitchToThisWindow(hWnd, true);    // 激活，显示在最前 
        bool result = SetWindowPos(hWnd, 0, GameManager.Xpos, GameManager.Ypos, GameManager.ScreenWidth + offset, GameManager.ScreenHeight + offset, SWP_SHOWWINDOW);       //设置屏幕大小和位置

        yield return new WaitForSeconds(0.5f);
        TestMoveAndClickMouse();
    }

    //IEnumerator ReSetposition()
    //{
    //    yield return new WaitForSeconds(1f);		//不知道为什么发布于行后，设置位置的不会生效，我延迟0.1秒就可以
    //    SetWindowLong(GetForegroundWindow(), GWL_STYLE, WS_POPUP);      //无边框
    //    bool result = SetWindowPos(GetForegroundWindow(), 0, _posX, _posY, _Txtwith, _Txtheight, SWP_SHOWWINDOW);       //设置屏幕大小和位置
    //}

    [System.Runtime.InteropServices.DllImport("user32")]
    private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    //移动鼠标 
    const int MOUSEEVENTF_MOVE = 0x0001;
    //模拟鼠标左键按下 
    const int MOUSEEVENTF_LEFTDOWN = 0x0002;
    //模拟鼠标左键抬起 
    const int MOUSEEVENTF_LEFTUP = 0x0004;
    //模拟鼠标右键按下 
    const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    //模拟鼠标右键抬起 
    const int MOUSEEVENTF_RIGHTUP = 0x0010;
    //模拟鼠标中键按下 
    const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    //模拟鼠标中键抬起 
    const int MOUSEEVENTF_MIDDLEUP = 0x0040;
    //标示是否采用绝对坐标 
    const int MOUSEEVENTF_ABSOLUTE = 0x8000;
    //模拟鼠标滚轮滚动操作，必须配合dwData参数
    const int MOUSEEVENTF_WHEEL = 0x0800;


    public static void TestMoveAndClickMouse()
    {
        Console.WriteLine("模拟鼠标移动5个像素点。");
        mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, 500, 500, 0, 0);
         mouse_event(MOUSEEVENTF_LEFTDOWN, 0,0, 0, 0);
         mouse_event(MOUSEEVENTF_LEFTUP,0,0, 0, 0);
    }

}
