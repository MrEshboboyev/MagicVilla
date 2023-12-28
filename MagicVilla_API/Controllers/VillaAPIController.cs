﻿using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return VillaStore.villaList;
        }

        //[HttpGet("id")] // https://localhost:7009/api/VillaAPI/id?id=1
        [HttpGet("{id:int}")] // https://localhost:7009/api/VillaAPI/1
        public VillaDTO GetVilla(int id)
        {
            return VillaStore.villaList.FirstOrDefault(x => x.Id == id);
        }
    }
}
