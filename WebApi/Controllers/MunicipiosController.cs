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
    public class MunicipiosController : ApiController<Municipios>
    {
        public MunicipiosController(IService<Municipios> service) : base(service)
        {
        }
    }
}
