﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSAch.API.Data;
using PSAch.API.Models;

namespace PSAch.API.Controllers
{
    public class GamesController : BaseApiController
    {
        private readonly DataContext _dataContext;

        public GamesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames() => Ok(await _dataContext.Games.Include(g => g.Achievements).ToListAsync());

        [HttpGet]
        public async Task<ActionResult<Game>> GetGame([FromQuery] int id) => await _dataContext.Games.FirstOrDefaultAsync(g => g.Id == id);
    }
}