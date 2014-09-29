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
using System.Linq;
using System.Text;
using Computing.Fmk.Interface;
using Computing.Fmk.Common;

namespace Computing.Master
{
    public class CService :ICService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public object Run(CTask task, string targetId)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyList"></param>
        /// <returns></returns>
        public string CreateAppDomain(IList<byte[]> assemblyList)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public bool TerminateAppDomain(string domainId)
        {
            return true;
        }
    }
}
