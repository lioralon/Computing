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
using Computing.Fmk.Common;
using Computing.Fmk.Interface;

namespace Computing.Master
{
    /// <summary>
    /// 
    /// </summary>
    public class CWorkerRegister : ICWorkerRegister
    {

        /// <summary>
        /// 
        /// </summary>
        public CMaster CMaster { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workNode"></param>
        /// <returns></returns>
        public bool Register(CNode workNode)
        {
            if (CMaster==null)
            {
                throw new Exception("主节点为空，请确保主节点不为空。");
            }
            if (workNode==null)
            {
                throw new Exception("Work为空，必须实例化一个worker。");
            }
            if (CMaster.Contains(workNode.NodeId))
            {
                throw  new Exception(string.Format("workerId: {0}在服务器中已经存在。",workNode.NodeId));
            }
            this.CMaster.Add(workNode.NodeId,workNode);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workNodeId"></param>
        /// <returns></returns>
        public bool UnRegister(string workNodeId)
        {
            if (string.IsNullOrEmpty(workNodeId))
            {
                return false;
            }
            if (CMaster==null)
            {
                throw new Exception("主节点为空，请确保主节点不为空。");
            }
            if (CMaster.Contains(workNodeId)==false)
            {
                return false;
            }
            CMaster.Remove(workNodeId);
            return true;
        }
    }
}
