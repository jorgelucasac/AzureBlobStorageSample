using Estudos.BlobStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.BlobStorage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlobStorageController : ControllerBase
    {
        private readonly BlobStorageService _blobStorageService;

        private readonly ILogger<BlobStorageController> _logger;

        public BlobStorageController(ILogger<BlobStorageController> logger, BlobStorageService blobStorageService)
        {
            _logger = logger;
            _blobStorageService = blobStorageService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blobStorageService.GetAll());
        }
    }
}