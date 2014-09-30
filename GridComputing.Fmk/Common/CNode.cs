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

namespace Computing.Fmk.Common
{
    [Serializable]
    public class CNode
    {
        /// <summary>
        /// 
        /// </summary>
        public string NodeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IWorker WorkerService { get; set; }
    }
}
