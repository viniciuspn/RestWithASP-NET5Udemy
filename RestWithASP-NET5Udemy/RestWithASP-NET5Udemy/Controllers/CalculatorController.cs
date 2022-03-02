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
                var sum = ConvetToDecimal(fristNumber) + ConvetToDecimal(secondNumber);// calculo soma
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{fristNumber}/{secondNumber}")]
        public IActionResult sub(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var sub = ConvetToDecimal(fristNumber) -  ConvetToDecimal(secondNumber);//calculo subtração
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{fristNumber}/{secondNumber}")]
        public IActionResult mult(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var mult = ConvetToDecimal(fristNumber) * ConvetToDecimal(secondNumber);//calculo multiplicação
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divi/{fristNumber}/{secondNumber}")]
        public IActionResult divi(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var divi = ConvetToDecimal(fristNumber) / ConvetToDecimal(secondNumber);// calculo divisão
                return Ok(divi.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{fristNumber}/{secondNumber}")]
        public IActionResult media(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))//validar valor numerico
            {
                var media = ConvetToDecimal(fristNumber) + ConvetToDecimal(secondNumber) / 2;//calculo media
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("raizQuadrada/{fristNumber}")]
        public IActionResult raizQuadrada(string fristNumber)
        {
            if (IsNumeric(fristNumber) )//validar valor numerico
            {
                var raizQuadrada = Math.Sqrt((double)ConvetToDecimal(fristNumber));//calculo raiz quadrada
                return Ok(raizQuadrada.ToString());
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
