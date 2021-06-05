﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = Convert.ToDecimal (firstNumber) + Convert.ToDecimal (secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult Multi(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }



        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        //private decimal ConvertToDecimal(string strNumber)
        //{
        //    decimal decimalValue;
        //    if (decimal.TryParse(strNumber, out decimalValue))
        //        return decimalValue;
        //    return 0;
        //}

       
    }
}
