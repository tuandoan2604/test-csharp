using System;
using System.Collections;
using System.Collections.Generic;

public class WindowManager
{
    ArrayList arr = new ArrayList();
    public void Open(string windowName)
    {
        arr.Add(windowName);
    }

    public void Close(string windowName)
    {
        arr.Remove(windowName);
    }

    public string GetTopWindow()
    {
        return arr[arr.Count - 1].ToString();
    }

    public static void Main(string[] args)
    {
        WindowManager wm = new WindowManager();
        wm.Open("Calculator");
        wm.Open("Browser");
        wm.Open("Player");
        wm.Close("Browser");
        Console.WriteLine(wm.GetTopWindow());
    }
}

