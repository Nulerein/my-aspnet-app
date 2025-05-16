using Microsoft.AspNetCore.Mvc;
using my_aspnet_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_aspnet_app.Controllers;

public class RouletteController : Controller
{
    private static readonly List<RouletteBet> Bets = new();
    private static readonly Random RandomGenerator = new();

    public IActionResult Index()
    {
        return View(Bets);
    }

    [HttpPost]
    public IActionResult PlaceBet(string userName, decimal betAmount, string betColor)
    {
        if (string.IsNullOrEmpty(userName) || betAmount <= 0 || string.IsNullOrEmpty(betColor))
        {
            return BadRequest("Invalid bet details.");
        }

        if (!new[] { "red", "black", "green" }.Contains(betColor.ToLower()))
        {
            return BadRequest("Invalid bet color.");
        }

        var bet = new RouletteBet
        {
            Id = Bets.Count + 1,
            UserName = userName,
            BetAmount = betAmount,
            BetColor = betColor,
            BetTime = DateTime.Now
        };

        Bets.Add(bet);
        return RedirectToAction("Index");
    }

    public IActionResult Spin()
    {
        var colors = new[] { "red", "black", "green" };
        var winningColor = colors[RandomGenerator.Next(colors.Length)];

        var result = new RouletteResult
        {
            Id = Bets.Count + 1,
            WinningColor = winningColor,
            ResultTime = DateTime.Now
        };

        ViewData["WinningColor"] = winningColor;
        ViewData["Bets"] = Bets.Select(bet => new
        {
            bet.UserName,
            bet.BetAmount,
            bet.BetColor,
            Winnings = bet.BetColor == winningColor ? bet.BetAmount * (winningColor == "green" ? 14 : 2) : 0
        }).ToList();

        Bets.Clear(); // Очистка ставок после спина
        return View(result);
    }
}