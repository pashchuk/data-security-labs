using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Web.Http;
using lab5_8.Helpers;

namespace lab5_8.Controllers
{
    [RoutePrefix("api/numbers")]
    public class NumberController : ApiController
    {
        [Route("get_random"), HttpGet]
        public IHttpActionResult GetRandomNumber()
        {
            var rnd = new Random();
            var number = new int[40].Select(a => rnd.Next(1, 9)).Aggregate(string.Empty, ((s, i) => s += i));
            return Json(number);
        }

        [Route("check_number"), HttpGet]
        public IHttpActionResult CheckIsPrime(string value)
        {
            return Json(BigInteger.Parse(value).IsProbablePrime(5));
        }

        [Route("primes_list"), HttpGet]
        public IEnumerable<string> GetPrimesList()
        {
            var primes = new[]
            {
                "671998030559713968361666935769",
                "282174488599599500573849980909",
                "521419622856657689423872613771",
                "362736035870515331128527330659",
                "115756986668303657898962467957",
                "590872612825179551336102196593",
                "1451730470513778492236629598992166035067",
                "5992830235524142758386850633773258681119",
                "668486051696691190102895306426999370394054817506916629001851",
                "361720912810755408215708460645842859722715865206816237944587"
            };
            return primes;
        }
    }
}
