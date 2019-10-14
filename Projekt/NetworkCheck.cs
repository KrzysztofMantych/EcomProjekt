﻿using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class NetworkCheck
    {
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }
    }
}