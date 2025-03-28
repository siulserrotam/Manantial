using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorBaseApi : ControllerBase
    {
        // Funcionalidad común para todos los controladores de API puede agregarse aquí
    }
}
