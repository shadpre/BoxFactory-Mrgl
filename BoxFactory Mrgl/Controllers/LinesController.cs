using BoxFactory_Mrgl.DAL.Interfaces;
using BoxFactory_Mrgl.DAL;
using Microsoft.AspNetCore.Mvc;
using BoxFactory_Mrgl.Models;
using BoxFactory_Mrgl.Models.Interfaces;

namespace BoxFactory_Mrgl.Controllers
{
    [ApiController]
    public class LinesController : ControllerBase
    {
        private IDBFacade _dbFacade = new DBFacade();
        
        [HttpPost]
        [Route("/api/Lines")]
        public IActionResult Create([FromBody] LineModel line)
        {
            ILineModel model = _dbFacade.CreateLine(line);
            if (model == null) { return BadRequest(); }
            return Created("", model);
        }
    }
}
