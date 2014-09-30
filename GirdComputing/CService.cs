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

using Computing.Fmk.Common;
using Computing.Fmk.Interface;
using System.Collections.Generic;

namespace Computing.Master
{
    /// <summary>
    /// 
    /// </summary>
    public class CService :ICService
    {

        public CMaster CMaster { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public object Run(CTask task, string targetId)
        {
            return CMaster.Run(task, targetId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyList"></param>
        /// <returns></returns>
        public string CreateAppDomain(IList<byte[]> assemblyList)
        {
            return CMaster.CreateAppDomain(assemblyList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public bool TerminateAppDomain(string domainId)
        {
            return CMaster.TerminateAppDomain(domainId);
        }
    }
}
