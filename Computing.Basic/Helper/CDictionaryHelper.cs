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

namespace Computing.Basic.Helper
{
    public static  class CDictionaryHelper
    {
        public static void AddWithUpdate<TKey, TVal>(this IDictionary<TKey, TVal> composer, TKey k, TVal v)
        {

            if (composer==null)
            {
                throw new  NullReferenceException("Dictionary is null");
            }

            if (composer.ContainsKey(k))
            {
                composer.Remove(k);
            }
            composer.Add(k,v);
        }

        public static TVal RemoveAndReturn<TKey, TVal>(this IDictionary<TKey, TVal> composer, TKey k)
        {
            if (composer==null)
            {
                
                throw  new NullReferenceException("Dictionary is null");
            }
            if (composer.ContainsKey(k))
            {
                var result = composer[k];
                composer.Remove(k);
                return result ;
            }
            return default(TVal);
        }

        public static TVal Get<TKey, TVal>(this IDictionary<TKey, TVal> composer, TKey k)
        {
            if (composer == null)
            {

                throw new NullReferenceException("Dictionary is null");
            }
            if (composer.ContainsKey(k))
            {
                return composer[k];
            }
            return default(TVal);
        }


    }
}
