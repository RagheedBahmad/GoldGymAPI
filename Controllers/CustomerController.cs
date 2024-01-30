using GoldGymAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// Use the correct namespace where your models are defined

// Make sure this is the correct namespace for your GoldGymContext

namespace GoldGymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Prefix with "api/" if that's your desired routing structure
    public class CustomerController(GoldGymContext context) : ControllerBase
    {
        
    }
}