
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Dapper;
using BoxFactory_Mrgl.Models;
using System.Data.SqlClient;
using BoxFactory_Mrgl.DAL;

namespace BoxFactory_Mrgl.Controllers
{
    [ApiController]
    public class BoxController : ControllerBase
    {
        BoxDAO boxDAO = new BoxDAO();

        [HttpPost]
        [Route("/api/box")]
        public IActionResult Post([FromBody] BoxModel box)
        {
            BoxModel newBox =
            boxDAO.Create(box.Length, box.Width, box.Height, box.Price);

            if (newBox == null) { return BadRequest(); }
            return Created("", newBox);
        }

        [HttpGet]
        [Route("/api/box")]
        public IActionResult GetAll()
        {
            List<BoxModel> boxes;

            boxes = boxDAO.ReadAll();
            return Ok(boxes);
        }

        [HttpGet]
        [Route("/api/box/{BoxId}")]
        public IActionResult Get([FromRoute] int BoxId)
        {
            BoxModel box;
            box = boxDAO.Read(BoxId);

            if (box == null) { NotFound("Box Not Found"); }
            return Ok(box);
        }

        [HttpGet]
        [Route("api/box/search")]
        public IActionResult Search(
            [FromQuery] decimal volumenMin = 0, 
            [FromQuery] decimal volumenMax = decimal.MaxValue, 
            [FromQuery] decimal minPrice = 0, 
            [FromQuery] decimal maxPrice = decimal.MaxValue)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/api/box")]
        public IActionResult Put([FromBody]BoxModel box)
        {
            BoxModel newbox;
            newbox = boxDAO.Update(box.BoxId, box.Length, box.Width, box.Height, box.Price);

            if (newbox == null) { return NotFound("Box Not Found"); }
            return Ok(newbox);
        }

        [HttpDelete]
        [Route("/api/box/{BoxId}")] 
        public IActionResult Delete([FromRoute] int BoxId)
        {
            if (boxDAO.Delete(BoxId)) return Ok(); 
            else return NotFound("Box not Found");
        }
    }
}
