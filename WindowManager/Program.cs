using System;
using System.Collections.Generic;

public class WindowManager
{
    Stack<string> window = new Stack<string>();
    Stack<string> store = new Stack<string>();
    public string data;
    public void Open(string windowName)
    {
        window.Push(windowName);
    }

    public void Close(string windowName)
    {
        while (window.Count > 0)
        {
            data = window.Pop();
            if(data != windowName)
            {
                store.Push(data);
            }
            else if(data == windowName) {
                while(store.Count > 0)
                {
                    window.Push(store.Pop());
                }
                break;
            }
        }
    }

    public string GetTopWindow()
    {
        if(window.Count > 0)
        {
            return window.Pop();
        }
        return "";
    }

    public static void Main(string[] args)
    {
        WindowManager wm = new WindowManager();
        wm.Open("Browser");
        wm.Open("Calculator"); 
        wm.Open("Player");
        wm.Open("hello");
        wm.Close("Calculator");
        Console.WriteLine(wm.GetTopWindow());
    }
}
