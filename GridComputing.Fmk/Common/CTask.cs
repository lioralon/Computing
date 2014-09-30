//======================================================================
// Copyright (C) 2014 HuaZhu Hotel Group     
// All rights reserved
// Description : This is for app 5.0 continuing check in and self check out
// Created by : Luzhanpeng
// Date : 2014-08-29
// Purpose: Initialization
//
// Modified by 
//======================================================================

using System;
using System.Collections.Generic;

namespace Computing.Fmk.Common
{
    /// <summary>
    /// 任务，将任务中包含的dll序列化成字节流到Master,Master根据空闲的进程/机子将字节流发往worker,worker根据字节流反序列后调用方法。达到计算的目的。
    /// </summary>
    [Serializable]
    public class CTask
    {
        private List<byte[]> _asmlist = new List<byte[]>();
        private string _targetMethodName = string.Empty;
        private string _targetTypeFullName = string.Empty;
        private string _xmlTargetObject = string.Empty;

        public CTask()
        {

        }

        public CTask(string xml, string method, string fullName) : this(xml, method, fullName, new List<byte[]>())
        {

        }

        public CTask(string xml, string method, string fullname, List<byte[]> list)
        {
            _asmlist = list;
            _xmlTargetObject = xml;
            _targetMethodName = method;
            _targetTypeFullName = fullname;
        }

        public string TargetTypeFullName
        {
            get { return _targetTypeFullName; }
            set { _targetTypeFullName = value; }
        }

        public string XmlTargetObject
        {
            get { return _xmlTargetObject; }
            set { _xmlTargetObject = value; }
        }

        public string TargetMethodName
        {
            get { return _targetMethodName; }
            set { _targetMethodName = value; }
        }

        public List<byte[]> AsmList
        {
            get { return _asmlist; }
            set { _asmlist = value; }
        }
    }
}
