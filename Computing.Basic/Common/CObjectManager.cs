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


using System.Collections.Generic;
using System.Linq;
using Computing.Basic.Helper;

namespace Computing.Basic.Common
{
    /// <summary>
    /// 对象添加时触发的事件，如果需要做什么事情的话。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    public delegate void CGeneric<in T>(T obj);
    
    /// <summary>
    /// 对象管理容器，当主Master启动时管理对应的Worker。
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TObject"></typeparam>
    public class CObjectManager<TKey,TObject>
    {
        private readonly IDictionary<TKey, TObject> _objectDictionary = new Dictionary<TKey, TObject>(); 
        private readonly object _locker = new object();
        public event CGeneric<TObject> ObjectLoaded;
        public event CGeneric<TObject> ObjectUnloaded;

        /// <summary>
        /// 事件
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void OnObjectLoaded(TObject obj)
        {
            var handler = ObjectLoaded;
            if (handler != null)
            {
                handler(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void OnObjectUnloaded(TObject obj)
        {
            var handler = ObjectUnloaded;
            if (handler != null)
            {
                handler(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CObjectManager()
        {
            ObjectLoaded += delegate { };
            ObjectUnloaded += delegate { };

        }

        /// <summary>
        /// 
        /// </summary>
        public int ObjectCount
        {
            get { return _objectDictionary.Count; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public virtual void Add(TKey key, TObject obj)
        {
            lock (_locker)
            {
                _objectDictionary.AddWithUpdate(key,obj);

                OnObjectLoaded(obj);

            }   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public virtual void Remove(TKey key)
        {
            TObject target;

            lock (_locker)
            {
                target = _objectDictionary.RemoveAndReturn(key);
            }

            if (target != null)
            {
                OnObjectUnloaded(target);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual TObject Get(TKey key)
        {
            lock (_locker)
            {
                return _objectDictionary.Get(key);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            lock (_locker)
            {
                _objectDictionary.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<TObject> GetAllItems()
        {
            lock (_locker)
            {
                return CCollectionHelper.GetAllItems(_objectDictionary.Values);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<TKey> GetAllKeys()
        {
            lock (_locker)
            {
                return CCollectionHelper.GetAllItems(_objectDictionary.Keys);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IList<TKey> GetKeysByObj(TObject obj)
        {
            lock (_locker)
            {
                return GetAllKeys()
                    .Where(key => _objectDictionary[key].Equals(obj))
                    .ToList();
            }
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
        public bool Contains(TKey key)
        {
            lock (_locker)
            {
                return _objectDictionary.ContainsKey(key);
            }
        }

    }
}
