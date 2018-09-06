using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/default")]
    public class DefaultController : ApiController
    {

        protected internal new JsonResult<T> Json<T>(T content)
        {
            Console.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]：")+JsonConvert.SerializeObject(content));
            return base.Json(content);
        }
        [Route("getData/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(SexEnum id)
        {
            try
            {
                var dataList = InitData();
                return Json(dataList.Where(a => a.Sex == id).Select(a=>a.Name));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<UserModel> InitData(int count=10)
        {
            var rd = new Random();
            var firstName = "张王李赵周吴郑钱";
            var lastName = "婕波云灵晓虎齐";
            var userList = new List<UserModel>();
            for (var i = 0; i < count; i++)
            {
                userList.Add(new UserModel()
                {
                    Name = (firstName.ToCharArray())[rd.Next(0, firstName.Length)].ToString() + (lastName.ToCharArray())[rd.Next(0, lastName.Length)].ToString(),
                    Sex = (SexEnum)rd.Next(1, 3)
                });
            }
            return userList;
        }
    }
}
