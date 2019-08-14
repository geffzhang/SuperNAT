﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SuperNAT.Common.Bll;
using SuperNAT.Common.Models;

namespace SuperNAT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(User model)
        {
            var rst = new ReturnResult<bool>();

            using var bll = new UserBll();
            if (model.id == 0)
            {
                model.token = Guid.NewGuid().ToString("N");
                rst = bll.Add(model);
            }
            else
            {
                rst = bll.Update(model);
            }

            return new JsonResult(rst);
        }


        [HttpPost]
        [Route("GetOne")]
        public IActionResult GetOne(User model)
        {
            if (model.id == 0)
            {
                var defalut = new ReturnResult<User>()
                {
                    Result = true,
                    Data = new User()
                };
                return new JsonResult(defalut);
            }
            using var bll = new UserBll();
            var rst = bll.GetOne(model);
            return new JsonResult(rst);
        }

        [HttpPost]
        [Route("GetList")]
        public IActionResult GetList(User model)
        {
            using var bll = new UserBll();
            var rst = bll.GetList(model);
            return new JsonResult(rst);
        }
    }
}
