using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Extra
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        #region PoolVariables
        private List<T> _pool;
        private readonly T _prefab;
        private readonly bool _autoExpand;
        private readonly Transform _container;
        #endregion
    
        public PoolMono(T prefab, int count, bool autoExpand)
        {
            _prefab = prefab;
            _autoExpand = autoExpand;
            _container = null;

            CreatePool(count);
        }

        public PoolMono(T prefab, int count, Transform container, bool autoExpand)
        {
            _prefab = prefab;
            _container = container;
            _autoExpand = autoExpand;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool.Where(mono => mono.gameObject.activeInHierarchy == false))
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception("There is no free element in pool");
        }

        public List<T> GetAllFreeElements()
        {
            return _pool.Where(element => element.gameObject.activeInHierarchy == false).ToList();
        }

        public List<T> GetAllElements()
        {
            return _pool.ToList();
        }
    }
}