using Microsoft.AspNetCore.Mvc;
using my_aspnet_app.Models;
using System.Linq;

namespace my_aspnet_app.Controllers;

public class CaseController : Controller
{
    private static readonly List<Case> Cases = new()
    {
        new Case
        {
            Id = 1,
            Name = "Chroma Case",
            Items = new List<Item>
            {
                new Item { Id = 1, Name = "AK-47 | Redline", Rarity = "rare", ImageUrl = "/images/ak47_redline.png" },
                new Item { Id = 2, Name = "AWP | Asiimov", Rarity = "epic", ImageUrl = "/images/awp_asiimov.png" },
                new Item { Id = 3, Name = "P250 | Sand Dune", Rarity = "common", ImageUrl = "/images/p250_sand_dune.png" }
            }
        }
    };

    public IActionResult Index()
    {
        return View(Cases);
    }

    public IActionResult Open(int id)
    {
        var selectedCase = Cases.FirstOrDefault(c => c.Id == id);
        if (selectedCase == null)
        {
            return NotFound();
        }

        var random = new Random();
        var wonItem = selectedCase.Items[random.Next(selectedCase.Items.Count)];

        return View(wonItem);
    }
}