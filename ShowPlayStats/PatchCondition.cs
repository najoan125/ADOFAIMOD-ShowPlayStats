﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlayStats
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PatchCondition : HarmonyPatch
    {
        private static Dictionary<string, bool> _enables = new Dictionary<string, bool>();
        public string ClassName { get; set; }
        public string Id { get; set; }

        public string MethodName => info.methodName;

        public Assembly Assembly { get; set; }

        public int MinVersion { get; set; }

        public int MaxVersion { get; set; }

        public bool IsEnabled
        {
            get
            {
                if (!_enables.ContainsKey(Id)) _enables[Id] = false;
                return _enables[Id];
            }
            set => _enables[Id] = value;
        }

        public PatchCondition(string id, string className, string method, int minVersion = -1, int maxVersion = -1)
        {
            Id = id;
            ClassName = className;
            Assembly = Assembly.GetAssembly(typeof(ADOBase));
            info.methodName = method;
            info.declaringType = Assembly.GetType(className);
            info.method = info.declaringType.GetMethod(method, AccessTools.all);
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }
    }
}
