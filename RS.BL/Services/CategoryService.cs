﻿using RS.BL.ViewModel;
using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.Services
{
    public class CategoryService
    {
        IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<KeyValue> GetAll()
        {
            List<KeyValue> categories = new List<KeyValue>();
            foreach (var item in Database.CategoryRep.GetList())
            {
                categories.Add(
                    new KeyValue
                    {
                        Value = item.Name,
                        Key = item.Id.ToString()
                    });
            }

            return categories;
        } 

        public ResultMessage Create(string name)
        {
            try
            {
                Database.CategoryRep.Create(new Core.Category
                {
                    Name = name
                });
                return new ResultMessage(false, "Success");
            }
            catch(Exception ex)
            {
                return new ResultMessage(ex.Message);
            }
        }

        public ResultMessage ChangeName(string name, string id)
        {
            try
            {
                var item = Database.CategoryRep.Get(Int64.Parse(id));
                if(item!=null)
                {
                    item.Name = name;
                    Database.CategoryRep.Update(item);
                    return new ResultMessage(false, "Success");
                }
                else
                {
                    return new ResultMessage("Not Found by Id");
                }
                
            }
            catch (Exception ex)
            {
                return new ResultMessage(ex.Message);
            }
        }
    }
}
