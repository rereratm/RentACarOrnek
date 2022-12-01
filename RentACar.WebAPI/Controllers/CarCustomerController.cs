using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Business.Validation.CarCustomer;
using RentACar.DAL.Dtos.CarCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCustomerController : ControllerBase
    {
        private readonly ICarCustomerService _carCustomerService;
        public CarCustomerController(ICarCustomerService carCustomerService)
        {
            _carCustomerService = carCustomerService;
        }
        [HttpGet("GetCarCustomerList")]
        public async Task<ActionResult<List<GetListCarCustomerDto>>> GetCarCustomerList()
        {
            try
            {
                return Ok(await _carCustomerService.GetCarCustomerList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCarCustomerById/{id}")]
        public async Task<ActionResult<GetCarCustomerDto>> GetCarCustomerById(int id)
        {
            var list = new List<string>();
            try
            {
                var currentCarCustomer = await _carCustomerService.GetCarCustomerById(id);
                if (currentCarCustomer == null)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
                else
                {
                    return currentCarCustomer;
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddCarCustomer")]
        public async Task<ActionResult<string>> AddCarCustomer(AddCarCustomerDto addCarCustomerDto)
        {
            var list = new List<string>();
            var validator = new CarCustomerAddValidator();
            var validationResults = validator.Validate(addCarCustomerDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _carCustomerService.AddCarCustomer(addCarCustomerDto);
                if (result > 0)
                {
                    list.Add("Kayıt Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else
                {
                    list.Add("Kayıt Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateCarCustomer/{id}")]
        public async Task<ActionResult<string>> UpdateCarCustomer(int id, UpdateCarCustomerDto updateCarCustomerDto)
        {
            var list = new List<string>();
            var validator = new CarCustomerUpdateValidator();
            var validationResults = validator.Validate(updateCarCustomerDto);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            try
            {
                var result = await _carCustomerService.UpdateCarCustomer(id, updateCarCustomerDto);
                if (result > 0)
                {
                    list.Add("Güncelleme Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "error" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Güncelleme Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteCarCustomer/{id}")]
        public async Task<ActionResult<string>> DeleteCarCustomer(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _carCustomerService.DeleteCarCustomer(id);
                if (result > 0)
                {
                    list.Add("Silme işlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme işlemi Başarısız!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
