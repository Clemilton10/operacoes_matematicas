using Microsoft.AspNetCore.Mvc;
using System;

namespace scaffold_linha_de_comando_v5.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalculadoraController : ControllerBase
	{
		[HttpGet("sum/{firstNumber}/{secondNumber}")]
		public IActionResult SumGet(string firstNumber, string secondNumber)
		{
			firstNumber = firstNumber.Replace('.', ',');
			secondNumber = secondNumber.Replace('.', ',');
			if (isNumeric(firstNumber) && isNumeric(secondNumber))
			{
				var sum = ConvertDecimal(firstNumber) +
					ConvertDecimal(secondNumber);
				return Ok(sum.ToString().Replace(',', '.'));
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("subtraction/{firstNumber}/{secondNumber}")]
		public IActionResult SubtractionGet(string firstNumber, string secondNumber)
		{
			firstNumber = firstNumber.Replace('.', ',');
			secondNumber = secondNumber.Replace('.', ',');
			if (isNumeric(firstNumber) && isNumeric(secondNumber))
			{
				var sum = ConvertDecimal(firstNumber) -
					ConvertDecimal(secondNumber);
				return Ok(sum.ToString().Replace(',', '.'));
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("multiplication/{firstNumber}/{secondNumber}")]
		public IActionResult MultiplicationGet(string firstNumber, string secondNumber)
		{
			firstNumber = firstNumber.Replace('.', ',');
			secondNumber = secondNumber.Replace('.', ',');
			if (isNumeric(firstNumber) && isNumeric(secondNumber))
			{
				var sum = ConvertDecimal(firstNumber) *
					ConvertDecimal(secondNumber);
				return Ok(sum.ToString().Replace(',', '.'));
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("division/{firstNumber}/{secondNumber}")]
		public IActionResult DivisionGet(string firstNumber, string secondNumber)
		{
			firstNumber = firstNumber.Replace('.', ',');
			secondNumber = secondNumber.Replace('.', ',');
			if (isNumeric(firstNumber) && isNumeric(secondNumber))
			{
				var sum = ConvertDecimal(firstNumber) /
					ConvertDecimal(secondNumber);
				return Ok(sum.ToString().Replace(',', '.'));
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("square-root/{strNumber}")]
		public IActionResult SqrtGet(string strNumber)
		{
			strNumber = strNumber.Replace('.', ',');
			if (isNumeric(strNumber))
			{
				var sum = Math.Sqrt((double)ConvertDecimal(strNumber));
				return Ok(sum.ToString().Replace(',', '.'));
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("media/{firstNumber}/{secondNumber}")]
		public IActionResult MediaGet(string firstNumber, string secondNumber)
		{
			firstNumber = firstNumber.Replace('.', ',');
			secondNumber = secondNumber.Replace('.', ',');
			if (isNumeric(firstNumber) && isNumeric(secondNumber))
			{
				var sum = (ConvertDecimal(firstNumber) +
					ConvertDecimal(secondNumber)) / 2;
				return Ok(sum.ToString().Replace(',', '.'));
			}
			return BadRequest("Invalid Input");
		}

		private bool isNumeric(string strNumber)
		{
			double number;
			bool isNumeric = double.TryParse(
			strNumber,
			/*System.Globalization.NumberStyles.Any,
			System.Globalization.NumberFormatInfo.InvariantInfo,*/
			out number
			);
			return isNumeric;
		}

		private decimal ConvertDecimal(string strNumber)
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
