using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{fristNumber}/{secondNumber}")]
        public IActionResult sum(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var sum = ConvetToDecimal(fristNumber) + ConvetToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{fristNumber}/{secondNumber}")]
        public IActionResult sub(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var sub = ConvetToDecimal(fristNumber) -  ConvetToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{fristNumber}/{secondNumber}")]
        public IActionResult mult(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var mult = ConvetToDecimal(fristNumber) * ConvetToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divi/{fristNumber}/{secondNumber}")]
        public IActionResult divi(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var divi = ConvetToDecimal(fristNumber) / ConvetToDecimal(secondNumber);
                return Ok(divi.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)//Metodo para validar 
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
        private decimal ConvetToDecimal(string strNumber)//Metodo para converter string para decimal
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }


    }
}
