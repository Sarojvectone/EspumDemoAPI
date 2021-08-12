using EspumDemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EspumDemoAPI.Controllers
{
    public class productController : ApiController
    {
        IList<productlstModel> products = new List<productlstModel>()
        {
            new productlstModel()
                {
                    ean = 3600523873852, Name = "Serum antirugs com",  Label = "TestLabel1", Brand = "serum brand", Category = "Seurm test category", ShortDescription = "Serum short description ", ImagePath = "sites/com/test.png",Url ="https://www.test.com"
                },
             new productlstModel()
                {
                    ean = 3600, Name = "Serum antirugs com1", Label = "TestLabel1", Brand = "serum brand1", Category = "Seurm test category1", ShortDescription = "Serum short description1 ", ImagePath = "sites/com/test1.png",Url ="https://www.test1.com"
                },
              new productlstModel()
                {
                    ean = 3601, Name = "Serum antirugs com2", Label = "TestLabel1", Brand = "serum brand2", Category = "Seurm test category2", ShortDescription = "Serum short description2 ", ImagePath = "sites/com/test2.png",Url ="https://www.test2.com"
                },
        };

        //https://localhost:44392/product/deatils
        [Route("product/deatils")]
        [HttpGet]

        public IList<productlstModel> GetAllProducts()
        {
            return products;
        }


        //JsonConvert.SerializeObject(result);

        [Route("product/deatils/{id}")]
        [HttpGet]
        //https://localhost:44392/product/deatils/3601
        public productlstModel GetProduct_Detailsby_Id(int id)
        {
            //Return a single employee detail  
            var products_dtl = products.FirstOrDefault(e => e.ean == id);
            if (products_dtl == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return products_dtl;
        }
    }
}