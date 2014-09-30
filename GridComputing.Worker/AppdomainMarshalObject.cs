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

namespace Computing.Worker
{
    /// <summary>
    /// Appdomain marshalObject,利用.net romting 接受byte[] 后反射产生class进行调用。
    /// </summary>
    public  sealed class AppdomainMarshalObject : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="xmlObj"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public object call(string fullName, string xmlObj, string method)
        {
            return null;
            //Type typeName = 
        }
    }
}
