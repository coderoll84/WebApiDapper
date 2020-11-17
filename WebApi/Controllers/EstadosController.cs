using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ApiController<Estados>
    {
        public EstadosController(IService<Estados> service) : base(service)
        {
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Estados>>> Get()
        {
            throw new Exception("Super error");

            var list = await service.GetAll();
            return list.ToList();
        }
    }
}
