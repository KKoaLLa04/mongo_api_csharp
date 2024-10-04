using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyApiController : ControllerBase
    {

        [HttpPost("tongdauchan")]
         public IActionResult TongDauChan([FromBody] int[] numbers)
          {
            if (numbers == null || numbers.Length == 0)
            {
                return BadRequest(new { message = "Numbers are required." });
            }

            var sum = numbers.Where(new => HasEvenFirstDigit(n)).Sum();
            return Ok(new { sum });
        }

        [HttpPost("tbnguyento")]
        public IActionResult TBNguyenTo([FromBody] int[] numbers)
        {
            var primes = numbers.Where(IsPrime).ToArray();
            if (primes.Length == 0) return Ok(new { average = 0 });
            var average = primes.Average();
            return Ok(new { average });
        }

        [HttpPost("trungbinhcong")]
        public IActionResult TrungBinhCong([FromBody] double[] numbers)
        {
            var positives = numbers.Where(n => n > 0).ToArray();
            if (positives.Length == 0) return Ok(new { average = 0 });
            var average = positives.Average();
            return Ok(new { average });
        }

        [HttpPost("tbclonhon")]
        public IActionResult TBCLonHon([FromBody] MyArrayWithX model)
        {
            var greaterThanX = model.Numbers.Where(n => n > model.X).ToArray();
            if (greaterThanX.Length == 0) return Ok(new { average = 0 });
            var average = greaterThanX.Average();
            return Ok(new { average });
        }

        [HttpPost("trungbinhnhan")]
        public IActionResult TrungBinhNhan([FromBody] double[] numbers)
        {
            var positives = numbers.Where(n => n > 0).ToArray();
            if (positives.Length == 0) return Ok(new { productMean = 0 });
            var product = positives.Aggregate(1.0, (acc, val) => acc * val);
            //var mean = Math.Pow(product, 1.0 / positives.Length);
            var mean = product, 1.0 / positives.Length;
            return Ok(new { productMean = mean });
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

    private bool HasEvenFirstDigit(int number)
    {
        var firstDigit = Math.Abs(number).ToString()[0];

        int firstDigitValue = int.Parse(firstDigit.ToString());

        return firstDigitValue % 2 == 0;
    }
}

public class MyArrayWithX
{
    public double[] Numbers { get; set; }
    public double X { get; set; }
}