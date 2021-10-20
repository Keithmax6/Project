using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Project.Dtos;
using Project.Models;

namespace Project.Controllers.Api
{
    public class ComponentsController : ApiController
    {
        private ApplicationDbContext _context;

        public ComponentsController()
        {
            _context = new ApplicationDbContext();
        }

        //Get/Api/components
        public IHttpActionResult GetComponents()
        {
            var componentDto = _context.Component.ToList().Select(Mapper.Map<Component, ComponentDto>);
            return Ok(componentDto);
        }
        //Get/Api/components/1
        public IHttpActionResult GetComponent(int id)
        {
            var component = _context.Component.SingleOrDefault(c => c.Id == id);
            if (component == null)
                return NotFound();
            return Ok( Mapper.Map<Component, ComponentDto>(component)) ;
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        //Post/Api/components
        [HttpPost]
        public IHttpActionResult CreateComponent(ComponentDto componentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var component = Mapper.Map<ComponentDto, Component>(componentDto);
            _context.Component.Add(component);
            _context.SaveChanges();

            componentDto.Id = component.Id;

            return Created(new Uri(Request.RequestUri + "/" + component.Id),componentDto);
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        //Put/Api/components/1
        [HttpPut]
        public IHttpActionResult UpdateComponent(int id, ComponentDto componentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var componentInDb = _context.Component.SingleOrDefault(c=>c.Id == id);

            if (componentInDb == null)
                return NotFound();

            Mapper.Map(componentDto, componentInDb);

            _context.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        // Delete/Api/component
        [HttpDelete]
        public IHttpActionResult DeleteComponent(int id)
        {
            var componentInDb = _context.Component.SingleOrDefault(c => c.Id == id);

            if (componentInDb == null)
                return NotFound();

            _context.Component.Remove(componentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
