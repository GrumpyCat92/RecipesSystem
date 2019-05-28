using RS.BL.Services;
using RS.BL.ViewModel;
using RS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecipesSystem.Controllers
{
    public class CategoryController : ApiController
    {
        UnitOfWork iuo;

        public CategoryController()
        {
            iuo = new UnitOfWork();
        }

        private CategoryService CategoryService
        {
            get
            {
                return new CategoryService(iuo);
            }
        }
        public IEnumerable<KeyValue> Get()
        {
            return CategoryService.GetAll();
        }

        // POST api/values
        public ResultMessage Post([FromBody]string value)
        {
            return CategoryService.Create(value);
        }
        
    }
}
