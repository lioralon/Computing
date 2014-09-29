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

using Computing.Fmk.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computing.Fmk.Common
{
    [Serializable]
    public class CNode
    {
        public string NodeId { get; set; }
        public ICWorkerRegister WorkerRegister { get; set; }
    }
}
