using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    [Authorize]
    public class RewardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;

        public RewardController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._UserManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> GetReward(int rewardIndex)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            Random rng = new Random();

            Product product = null;

            if(user.RewardPlayChanceCount > 0)
            {
                List<RewardPool> rewardPool = _context.RewardPool.Where(rp=>rp.PoolQuantity > 0).ToList();

                if(rewardPool.Count() > 0) { 

                    List<RewardPool> prizesPoolSelected = new List<RewardPool>();
                    for(int i = 0; i < 9; i++)
                    {
                        int rngNumber = rng.Next(0, rewardPool.Count);
                        prizesPoolSelected.Add(rewardPool[rngNumber]);
                    }

                    prizesPoolSelected[rewardIndex].PoolQuantity--;
                    user.RewardPlayChanceCount--;

                    Reward reward = new Reward()
                    {
                        ProductID = prizesPoolSelected[rewardIndex].ProductID,
                        UserID = user.Id,
                        RewardStatus = RewardStatus.Available,
                        RewardAddedDateTime = DateTime.Now,
                    };

                    product = _context.Product.Where(p => p.ProductID == prizesPoolSelected[rewardIndex].ProductID).FirstOrDefault();

                    _context.Add(reward);
                    _context.Update(prizesPoolSelected[rewardIndex]);
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
            }

            return PartialView("_RewardPrizePartial",product);
        }

        [HtppPost]
        public async Task<IActionResult> GetChoosePrizePartial()
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            ErrorMessage msg = new ErrorMessage();

            if (user.RewardPlayChanceCount > 0)
            {
                return PartialView("_ChoosePrizePartial");
            }
            else
            {
                return Json("Reward Not Available");
            }
        }
    }
}
  