using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testCore.Data;
using testCore.Models;
using testCore.Models.Account;
using testCore.ViewModels;

namespace testCore.Controllers
{
    [Authorize]
    public class SkiCardController : Controller
    {
        private readonly SkiCardContext _skiCardContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public SkiCardController(SkiCardContext skiCardContext, 
            UserManager<ApplicationUser> userManager)
        {
            _skiCardContext = skiCardContext;
            _userManager = userManager;
        }

        // GET: SkiCard
        public async Task<ActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var skiCardViewModels = await _skiCardContext.SkiCards
                .Where(s => s.ApplicationUserId == userId)
                .Select(s => new SkiCardListViewModel
                {
                    Id = s.Id,
                    CardHolderName = s.CardHolderFirstName + " " +s.CardHolderLastName
                })
                .ToListAsync();
            return View(skiCardViewModels);
        }

        // GET: SkiCard/Create
        public async Task<ActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);
            var currentUser = await _userManager.FindByEmailAsync(userId);
            var viewModel = new CreateSkiCardViewModel 
            {
                CardHolderPhoneNumber = currentUser.PhoneNumber
            };

            var hasExistingSkiCards = _skiCardContext.SkiCards.Any(s =>
            s.ApplicationUserId == userId);

            if (!hasExistingSkiCards)
            {
                viewModel.CardHolderFirstName = currentUser.FirstName;
                viewModel.CardHolderLastName = currentUser.LastName;
            }
            return View(viewModel);
        }

        // POST: SkiCard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSkiCardViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                SkiCard skiCard = new SkiCard
                {
                    ApplicationUserId = userId,
                    CreateOn = DateTime.UtcNow,
                    CardHolderFirstName = viewModel.CardHolderFirstName,
                    CardHolderLastName = viewModel.CardHolderLastName,
                    CardHolderBirthDate = viewModel.CardHolderBirthDate,
                    CardHolderPhoneNumber = viewModel.CardHolderPhoneNumber
                };

                _skiCardContext.SkiCards.Add(skiCard);
                await _skiCardContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: SkiCard/Edit/id
        public async Task<ActionResult> Edit(int id)
        {
            var userId = _userManager.GetUserId(User);
            var skiCardViewModel = await _skiCardContext.SkiCards
                .Where(s => s.ApplicationUserId == userId && s.Id == id)
                .Select(s => new EditSkiCardViewModel {
                    Id = s.Id,
                    CardHolderFirstName = s.CardHolderFirstName,
                    CardHolderLastName = s.CardHolderLastName,
                    CardHolderBirthDate = s.CardHolderBirthDate,
                    CardHolderPhoneNumber = s.CardHolderPhoneNumber
                }).SingleOrDefaultAsync();
            if(skiCardViewModel == null)
            {
                return NotFound();
            }

            return View(skiCardViewModel);
        }

        // POST: SkiCard/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditSkiCardViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var skiCard = await _skiCardContext.SkiCards
                    .SingleOrDefaultAsync(s => s.ApplicationUserId == userId && s.Id == viewModel.Id);
                if(skiCard == null)
                {
                    return NotFound();
                }

                skiCard.CardHolderFirstName = viewModel.CardHolderFirstName;
                skiCard.CardHolderLastName = viewModel.CardHolderLastName;
                skiCard.CardHolderBirthDate = viewModel.CardHolderBirthDate.Date;
                skiCard.CardHolderPhoneNumber = viewModel.CardHolderPhoneNumber;

                await _skiCardContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
