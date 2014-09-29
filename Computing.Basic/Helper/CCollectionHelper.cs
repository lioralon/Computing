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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computing.Basic.Helper
{
    public static class CCollectionHelper
    {
        public static IList<TObj> GetAllItems<TObj>(IEnumerable<TObj> composer)
        {
            if (composer.HasElements()==false)
            {
                return null;
            }
            var list = new List<TObj>();
            ActionForEach(composer, list.Add, null);
            return list;
        }


        public static bool HasElements<T>(this T composer) where T : IEnumerable
        {
            if (composer == null)
            {
                return false;
            }
            return composer.GetEnumerator().MoveNext();

        }

        public static void ActionForEach<TObj>(IEnumerable<TObj> source, Action<TObj> action, Predicate<TObj>  predicate)
        {
            if (source.HasElements())
            {
                foreach (var item in source)
                {
                    if (predicate!=null&& predicate(item)==false)
                    {
                        continue;
                    }
                    action(item);
                }
               

            }
        }
    }
}
