using Microsoft.AspNetCore.Mvc;
using WebAppValidations.Models;

namespace WebAppValidations.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            var model = new UserModel();           
            return View(model);
        }     

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SignUp(UserModel model)
        {
            #region Old Style Validations
            //if (string.IsNullOrWhiteSpace(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Enter Valid Name");
            //}
            //if (string.IsNullOrWhiteSpace(model.Passowrd))
            //{
            //    ModelState.AddModelError("Name", "Enter Valid Passowrd");
            //}
            //if (string.IsNullOrWhiteSpace(model.ConfirmPassowrd))
            //{
            //    ModelState.AddModelError("Name", "Enter Valid ConfirmPassowrd");
            //}
            //if (!string.IsNullOrWhiteSpace(model.Passowrd)
            //    && !string.IsNullOrWhiteSpace(model.ConfirmPassowrd)
            //    && model.Passowrd != model.ConfirmPassowrd)
            //{
            //    ModelState.AddModelError("Passowrd", "Passowrd and ConfirmPassowrd does not match!");
            //}
            //if (string.IsNullOrWhiteSpace(model.Address))
            //{
            //    ModelState.AddModelError("Name", "Enter Valid Address");
            //}
            //if (string.IsNullOrWhiteSpace(model.MobileNo))
            //{
            //    ModelState.AddModelError("Name", "Enter Valid MobileNo");
            //}
            #endregion

            if (string.IsNullOrWhiteSpace(model.Country))
            {
                ModelState.AddModelError("Country", "Enter Valid Country");
            }
            if (string.IsNullOrWhiteSpace(model.City))
            {
                ModelState.AddModelError("City", "Enter Valid City");
            }
            if (ModelState.IsValid)
            {
                var msg = model.Country + " selected";
                return RedirectToAction("IndexSuccess", new { message = msg });
            }
            // If we got this far, something failed; redisplay form.
            return View(model);
        }       

        public IActionResult Message()
        {
            return View();
        }
    }
}
