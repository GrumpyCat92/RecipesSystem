using RS.BL.ViewModel;
using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.Services
{
    public class IngridientService
    {
        IUnitOfWork Database { get; set; }

        public IngridientService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<KeyValue> GetAll()
        {
            List<KeyValue> categories = new List<KeyValue>();
            foreach (var item in Database.IngridientRep.GetList())
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
                Database.IngridientRep.Create(new Core.Ingridient
                {
                    Name = name
                });
                return new ResultMessage
                {
                    Error = false,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Error = true,
                    Message = ex.Message
                };
            }
        }

        public ResultMessage ChangeName(string name, string id)
        {
            try
            {
                var item = Database.IngridientRep.Get(Int64.Parse(id));
                if (item != null)
                {
                    item.Name = name;
                    Database.IngridientRep.Update(item);
                    return new ResultMessage
                    {
                        Error = false,
                        Message = "Success"
                    };
                }
                else
                {
                    return new ResultMessage
                    {
                        Error = true,
                        Message = "Not Found by Id"
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResultMessage
                {
                    Error = true,
                    Message = ex.Message
                };
            }
        }
    }
}
