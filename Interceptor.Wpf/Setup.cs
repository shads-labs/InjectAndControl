﻿using System;
using System.Windows;
using System.Windows.Interop;

namespace Interceptor.Wpf
{
    public class Setup
    {
        public static bool Start()
        {
            HwndSource source = PresentationSource.FromVisual(Application.Current.MainWindow) as HwndSource;
            source.AddHook(WndProc);

            return true;
        }

        private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x201:
                    //left button down 
                    handled = true;//(filter the message and don't let app process it)
                    break;
                case 0x202:
                    //left button up, ie. a click
                    break;
                case 0x203:
                    //left button double click 
                    handled = true; //(filter the message and don't let app process it)
                    break;
            }

            return IntPtr.Zero;
        }
    }
}
