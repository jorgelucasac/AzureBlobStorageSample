using Estudos.BlobStorage.Models;
using Estudos.BlobStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.BlobStorage.Controllers;

[ApiController]
[Route("api/v1/blob-storage")]
public class BlobStorageController : ControllerBase
{
    private readonly BlobContainnerService _blobContainnerService;

    private readonly ILogger<BlobStorageController> _logger;

    public BlobStorageController(ILogger<BlobStorageController> logger, BlobContainnerService blobContainnerService)
    {
        _logger = logger;
        _blobContainnerService = blobContainnerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _blobContainnerService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromForm] BlobItemUpload upload)
    {
        return Ok(await _blobContainnerService.UploadAsync(upload));
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteAsync(string name)
    {
        return Ok(await _blobContainnerService.DeleteAsync(name));
    }
}