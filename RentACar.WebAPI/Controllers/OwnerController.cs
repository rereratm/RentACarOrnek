using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Business.Validation.Owner;
using RentACar.DAL.Dtos.Owner;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        [HttpGet("GetOwnerList")]
        public async Task<ActionResult<List<GetListOwnerDto>>> GetOwnerList()
        {
            try
            {
                return Ok(await _ownerService.GetOwnerList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetOwnerById/{id}")]
        public async Task<ActionResult<GetOwnerDto>> GetOwnerById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz ID girdiniz!");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentOwner = await _ownerService.GetOwnerById(id);
                if (currentOwner == null)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
                else
                {
                    return currentOwner;
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddOwner")]
        public async Task<ActionResult<string>> AddOwner(AddOwnerDto addOwnerDto)
        {
            var list = new List<string>();
            var validator = new OwnerAddValidator();
            var validationResults = validator.Validate(addOwnerDto);
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
                var result = await _ownerService.AddOwner(addOwnerDto);
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
        [HttpPut("UpdateOwner/{id}")]
        public async Task<ActionResult<string>> UpdateOwner(int id, UpdateOwnerDto updateOwnerDto)
        {
            var list = new List<string>();
            var validator = new OwnerUpdateValidator();
            var validationResults = validator.Validate(updateOwnerDto);
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
                var result = await _ownerService.UpdateOwner(id, updateOwnerDto);
                if (result > 0)
                {
                    list.Add("Güncelleme İşlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
                else
                {
                    list.Add("Güncelleme İşlemi Başarısız!");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteOwner/{id}")]
        public async Task<ActionResult<string>> DeleteOwner(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _ownerService.DeleteOwner(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı!");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kayıt Bulunamadı!");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme İşlemi Başarısız!");
                    return Ok(new { cdeo = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
