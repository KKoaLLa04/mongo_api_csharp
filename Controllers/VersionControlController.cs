using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Models;
using MongoDbDemo.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionControlController : ControllerBase
    {
        private readonly VersionControlService _service;

        public VersionControlController(VersionControlService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<VersionControl>>> Get()
        {
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(VersionControl versionControl)
        {
            await _service.CreateAsync(versionControl);
            return CreatedAtAction(nameof(Get), new { id = versionControl.Id }, versionControl);
        }
    }
}
