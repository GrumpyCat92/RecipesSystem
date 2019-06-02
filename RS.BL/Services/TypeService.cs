using RS.BL.ViewModel;
using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.Services
{
    public class TypeService
    {
        IUnitOfWork Database { get; set; }

        public TypeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<KeyValue> GetAll()
        {
            List<KeyValue> types = new List<KeyValue>();
            foreach (var item in Database.TypeRep.GetList())
            {
                types.Add(
                    new KeyValue
                    {
                        Value = item.Name,
                        Key = item.Id.ToString()
                    });
            }

            return types;
        }

        public ResultMessage Create(string name)
        {
            try
            {
                Database.TypeRep.Create(new Core.Type
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
                var item = Database.TypeRep.Get(Int64.Parse(id));
                if (item != null)
                {
                    item.Name = name;
                    Database.TypeRep.Update(item);
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
