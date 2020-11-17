using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ApiController<Entity> : ControllerBase where Entity : class
    {
        protected readonly IService<Entity> service;

        public ApiController(IService<Entity> service)
        {
            this.service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<Entity>>> Get()
        {
            var list = await service.GetAll();
            return list.ToList();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<Entity>> Get(int id)
        {
            var reg = await service.GetById(id);

            if (reg == null)
                return NotFound();

            return reg;
        }

        [HttpPost]
        public virtual async Task<ActionResult<Entity>> Post(Entity reg)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            int id;
            try
            {
                id = await service.Insert(reg);
            }
            catch (Exception e) { return Conflict(e.Message); }

            return CreatedAtAction("Get", new { id }, reg);
        }

        [HttpPut()]
        public virtual async Task<ActionResult<Entity>> Put([FromBody]Entity reg)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await service.Update(reg);
            }
            catch (Exception e) { return Conflict(e.Message); }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<Entity>> Delete(int id)
        {
            var reg = await service.GetById(id);
            if (reg == null)
            {
                return NotFound();
            }

            await service.Delete(reg);
            return reg;
        }
    }
}
