using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameKit
{
    public static partial class Utility
    {
        private static Boolean LogicEx(Boolean a1, Boolean a2, string re)
        {
            Boolean result = false;
            switch (re)
            {
                case "&&": result = a1 && a2; break;
                case "||": result = a1 || a2; break;
            }
            return result;
        }
    }
}

