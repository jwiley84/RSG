using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace passcode.Controllers
{
    public class passcodeController : Controller
    {
        int count = 0;
        private static IEnumerable<string> RandomStrings(
            string allowedChars,
            int minLength,
            int maxLength,
            int count,
            Random rng)
            {
                char[] chars = new char[maxLength];
                int setLength = allowedChars.Length;

                while (count-- > 0)
                {
                    int length = rng.Next(minLength, maxLength + 1);

                    for (int i = 0; i < length; ++i)
                    {
                        chars[i] = allowedChars[rng.Next(setLength)];
                    }

                    yield return new string(chars, 0, length);
                }
            }
        public string test() 
        {
            const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*";
            Random rng = new Random();
            string testString = "";
            foreach (var randomString in RandomStrings(AllowedChars, 16, 16, 25, rng)) 
            {
                    testString = randomString;
            }

            return testString;
        } 

        [HttpGet]
        [Route("")]

       public IActionResult passcode()
        {
                count += 1;
                HttpContext.Session.SetInt32("Count", count);
                ViewBag.Test = test();
                return View("passcode");
        }
        // [HttpPost]
        // [Route("method")]
        // public IActionResult results(string name, string loc, string lang, string comments)
        // {
        //         ViewBag.Test = "Test?";
        //         ViewBag.name = name;
        //         ViewBag.loc = loc;
        //         ViewBag.lang = lang;
        //         ViewBag.comments = comments;
        //         return View();
        // }
        // [HttpGet]
        // [Route("results")]
        // public IActionResult results()
        // {
        //         ViewBag.Test = "Test?";
                
        //         return View();
        // }
    }
}