﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Model;

namespace Persistence
{
    [Serializable]
    public abstract class Repository<T> : MonoBehaviour where T : Base
    {
        [HideInInspector] public DataContext context;

        private List<T> Entities => context.Set<T>();
        
        public T GetById(string id)
        {
            return Entities.FirstOrDefault(e => e.id == id);
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void Modify(T entity)
        {
            for (var i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].id == entity.id)
                {
                    Entities[i] = entity;
                }
            }
        }

        public void Delete(T entity)
        {
            
        }
        
        public async Task Save()
        {
            await context.Save();
        }
    }
}