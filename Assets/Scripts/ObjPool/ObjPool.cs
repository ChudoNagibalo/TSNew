using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPGame.ObjPool
{
    public class ObjPool<T> where T : MonoBehaviour
    {
        public T Prefab {get;}
        public bool AutoExpand { get;set;}
        public Transform Container {get;}
        private List<T> _objects;
        public bool heh = true;

        public ObjPool(T prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _objects = new List<T>();

            for(int i = 0;  i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = GameObject.Instantiate(Prefab,Container.position, Container.localRotation, Container.transform);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _objects.Add(createdObject);

            return createdObject;
        }

        public bool HasFreeElement( out T element)
        {
            foreach (var obj in _objects)
            {
                if(!obj.gameObject.activeInHierarchy)
                {
                    element = obj;
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if(HasFreeElement(out var element))
            {
                element.gameObject.SetActive(true);
                return element;
            }

            if(AutoExpand)
            {
                return CreateObject(true);
            }

            throw new Exception($"There is no free elements {typeof(T)}");
        }
    }
}