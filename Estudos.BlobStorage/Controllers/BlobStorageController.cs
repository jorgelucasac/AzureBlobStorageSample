using Azure.Storage.Blobs.Models;
using Estudos.BlobStorage.Models;
using Estudos.BlobStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.BlobStorage.Controllers
{
    [ApiController]
    [Route("api/v1/blob-storage")]
    public class BlobStorageController : ControllerBase
    {
        private readonly EstudosContainnerService _estudosContainnerService;

        private readonly ILogger<BlobStorageController> _logger;

        public BlobStorageController(ILogger<BlobStorageController> logger, EstudosContainnerService estudosContainnerService)
        {
            _logger = logger;
            _estudosContainnerService = estudosContainnerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _estudosContainnerService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] BlobItemUpload upload)
        {
            return Ok(await _estudosContainnerService.UploadAsync(upload));
        }
    }
}