﻿//======================================================================
// Copyright (C) 2014 HuaZhu Hotel Group     
// All rights reserved
// Description : This is for app 5.0 continuing check in and self check out
// Created by : Luzhanpeng
// Date : 2014-08-29
// Purpose: Initialization
//
// Modified by 
//======================================================================

using Computing.Basic.Common;
using Computing.Basic.Helper;
using Computing.Fmk.Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Computing.Master
{
    /// <summary>
    /// 
    /// </summary>
    public class CMaster : CObjectManager<string, CNode>
    {
        private readonly CObjectManager<string,string>  _cAppdominManager = new CObjectManager<string, string>();
        private long _maxAppdominId;
        private readonly Random _random = new Random();

        public CMaster(long maxAppdominId)
        {
            _maxAppdominId = maxAppdominId;
        }


        /// <summary>
        /// 根据目标的domainID运行任务。
        /// </summary>
        /// <param name="task"></param>
        /// <param name="targetDomainId"></param>
        /// <returns></returns>
        public object Run(CTask task, string targetDomainId)
        {
            if (string.IsNullOrEmpty(targetDomainId))
            {
                var randomNode = GetRandomCNode();
                if (randomNode == null)
                {
                    throw new NullReferenceException("没有worker来运行该任务。");
                }
                return randomNode.WorkerService.Run(task, null);
            }
            if (_cAppdominManager.Contains(targetDomainId)==false)
            {
                throw new Exception(string.Format("名称为{0}的Appdomain不存在。", targetDomainId));
            }

            var node = base.Get(_cAppdominManager.Get(targetDomainId));
            if (node ==null)
            {
                throw new Exception(string.Format("支撑任务的work:{0},被移除了。",targetDomainId));
            }

            return node.WorkerService.Run(task, targetDomainId);


        }

        /// <summary>
        /// 随机挑取一个Node,注意选择.net的random非物理随机，真随机需要物理随机的算法。或者这段变成负载均衡的选择。
        /// </summary>
        /// <returns></returns>
        private CNode GetRandomCNode()
        {
            return ObjectCount > 0 ? GetAllItems()[_random.Next(ObjectCount)] : null;
        }


        /// <summary>
        /// 将任务指派给node并建立worker与domain的关系。
        /// </summary>
        /// <param name="assemblyData"></param>
        /// <returns></returns>
        public string CreateAppDomain(IList<byte[]> assemblyData)
        {
            var node = GetRandomCNode();

            if (node==null)
            {
                throw new NullReferenceException("没有worker来运行该任务。");
            }

            Interlocked.Increment(ref _maxAppdominId);

            var id = string.Format("{0}:{1}", node.NodeId, _maxAppdominId);
            node.WorkerService.CreateAppDomain(assemblyData);
            _cAppdominManager.Add(id,node.NodeId);
            return id;
        }

        /// <summary>
        /// 根据nodeID移除任务
        /// </summary>
        /// <param name="key"></param>
        public override void Remove(string key)
        {
            var keybyObj = _cAppdominManager.GetKeysByObj(key);
            if (!keybyObj.HasElements())
            {
                return;
            }
            foreach (var objKey in keybyObj)
            {
                _cAppdominManager.Remove(objKey);
            }
        }

        /// <summary>
        /// 终止任务
        /// </summary>
        /// <param name="targetId"></param>
        public bool TerminateAppDomain(string targetId)
        {
        
            if (!_cAppdominManager.Contains(targetId))
            {
                return false;
            }

            var node = base.Get(_cAppdominManager.Get(targetId));
            var isSuccess = false;
            if (node!=null)
            {
                isSuccess = node.WorkerService.TerminateAppDomain(targetId);
            }
    
            base.Remove(targetId);
            return isSuccess;
        }
    }
}
