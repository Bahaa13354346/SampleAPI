using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CaptchaController : ControllerBase
    {
        [HttpPost("upload")]
        //[Produces("application/json")]
        public async Task<IActionResult> Post([FromForm] Request req)
        {
            using (HttpClient client = new HttpClient())
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["method"] = "base64";
                data["key"] = req.key;
                data["body"] = req.body;
                data["json"] = "1";
                if (req.coordinates)
                {
                    data["coordinatescaptcha"] = "1";
                }
                else if (req.recaptcha)
                {
                    data["recaptcha"] = "1";
                    data["recaptchacols"] = req.cols;
                    data["recaptcharows"] = req.rows;
                    if (req.cna)
                    {
                        data["can_no_answer"] = "1";
                    }
                }
                else
                {
                    data["numeric"] = req.numeric;
                    data["phrase"] = req.phrase;
                    data["regsense"] = req.regsense;
                }
                if (req.instructions != null)
                {
                    data["textinstructions"] = req.instructions;
                        data["textinstructions"]= data["textinstructions"] += "... Click skip if its not English";
                }
                else
                {
                    data["textinstructions"] = "Click skip if its not English";
                }
                if (req.finstructions != null)
                {
                    data["imginstructions"] = req.finstructions;
                }
               
                //if (req.russian)
                //{
                //    data["lang"] = "ru";
                //}
                var response = await client.PostAsync("https://2captcha.com/in.php", new FormUrlEncodedContent(data));
                string content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> Get([FromQuery] Request req)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"https://2captcha.com/res.php?action=get&key={req.key}&id={req.id}&json=1");
                string content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
        }

    }
}
