using Microsoft.AspNetCore.Mvc;
using MultithreadingLongReading.Services;

namespace MultithreadingLongReading.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("withoutlock")]
        public IActionResult WithoutLock()
        {
            var res = ReaderService.ReadFile();
            return Ok(res);
        }

        [Route("withlock")]
        public IActionResult WithLock()
        {
            var res = ReaderService.ReadFileWithLock();
            return Ok(res);
        }

        [Route("monitor")]
        public IActionResult Monitor()
        {
            var res = ReaderService.MonitorTest();
            return Ok(res);
        }
    }
}
