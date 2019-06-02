using RS.BL.ViewModel;
using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.Services
{
    public class TimePrepaeringService
    {
        IUnitOfWork Database { get; set; }

        public TimePrepaeringService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<KeyValue> GetAll()
        {
            List<KeyValue> times = new List<KeyValue>();
            foreach (var item in Database.TimePrepaeringRep.GetList())
            {
                times.Add(
                    new KeyValue
                    {
                        Value = item.Period,
                        Key = item.Id.ToString()
                    });
            }

            return times;
        }

        public ResultMessage Create(string name)
        {
            try
            {
                Database.TimePrepaeringRep.Create(new Core.TimePrepaering
                {
                    Period = name
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
                var item = Database.TimePrepaeringRep.Get(Int64.Parse(id));
                if (item != null)
                {
                    item.Period = name;
                    Database.TimePrepaeringRep.Update(item);
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
