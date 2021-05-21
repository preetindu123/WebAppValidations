using DAL;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Repository.UOW;
using System.Linq;

namespace WebAppValidations.Controllers
{
    public class AccountController : Controller
    {
        public IUnitOfWork _uow;
        public AccountController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            var data = _uow.UserRepo.GetAllUsers();
            return View(data);
        }

        public IActionResult SignUp()
        {
            var model = new UserModel();
            ViewBag.CountryList = _uow.CountryRepo.GetAll();
            ViewBag.CityList = _uow.CityRepo.GetAll().ToList();
            return View(model);
        }     

        [HttpPost]
        public IActionResult SignUp(User model)
        {          
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                _uow.UserRepo.Add(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryList = _uow.CountryRepo.GetAll().ToList();
            ViewBag.CityList = _uow.CityRepo.GetAll().ToList();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var user = _uow.UserRepo.FindById(id);
            ViewBag.CountryList = _uow.CountryRepo.GetAll().ToList();
            ViewBag.CityList = _uow.CityRepo.GetAll().ToList();
            return View("SignUp", user);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                _uow.UserRepo.Update(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryList = _uow.CountryRepo.GetAll().ToList();
            ViewBag.CityList = _uow.CityRepo.GetAll().ToList();
            return View("SignUp", model);
        }

        public IActionResult Delete(int id)
        {
            var product = _uow.UserRepo.FindById(id);
            if (product != null)
            {
                _uow.UserRepo.DeleteById(id);
                _uow.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(User model)
        {
            if (ModelState.IsValid)
            {
                _uow.UserRepo.DeleteById(model.UserId);
                _uow.SaveChanges();
            }
            ViewBag.CategoryList = _uow.UserRepo.GetAll().ToList();
            return RedirectToAction("Index");

        }

        public IActionResult Message()
        {  
            return View();
        }

        #region ref code

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

        //if (string.IsNullOrWhiteSpace(model.CountryName))
        //{
        //    ModelState.AddModelError("Country", "Enter Valid Country");
        //}
        //if(string.IsNullOrWhiteSpace(model.CityName))
        //{
        //    ModelState.AddModelError("City", "Enter Valid City");
        //}
        //if (ModelState.IsValid)
        //{
        //    return RedirectToAction("Message");
        //}
        #endregion


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SignUp(UserModel model)
        //{
        //    #region Old Style Validations
        //    //if (string.IsNullOrWhiteSpace(model.Name))
        //    //{
        //    //    ModelState.AddModelError("Name", "Enter Valid Name");
        //    //}
        //    //if (string.IsNullOrWhiteSpace(model.Passowrd))
        //    //{
        //    //    ModelState.AddModelError("Name", "Enter Valid Passowrd");
        //    //}
        //    //if (string.IsNullOrWhiteSpace(model.ConfirmPassowrd))
        //    //{
        //    //    ModelState.AddModelError("Name", "Enter Valid ConfirmPassowrd");
        //    //}
        //    //if (!string.IsNullOrWhiteSpace(model.Passowrd)
        //    //    && !string.IsNullOrWhiteSpace(model.ConfirmPassowrd)
        //    //    && model.Passowrd != model.ConfirmPassowrd)
        //    //{
        //    //    ModelState.AddModelError("Passowrd", "Passowrd and ConfirmPassowrd does not match!");
        //    //}
        //    //if (string.IsNullOrWhiteSpace(model.Address))
        //    //{
        //    //    ModelState.AddModelError("Name", "Enter Valid Address");
        //    //}
        //    //if (string.IsNullOrWhiteSpace(model.MobileNo))
        //    //{
        //    //    ModelState.AddModelError("Name", "Enter Valid MobileNo");
        //    //}
        //    #endregion

        //    if (string.IsNullOrWhiteSpace(model.CountryName))
        //    {
        //        ModelState.AddModelError("Country", "Enter Valid Country");
        //    }
        //    if (string.IsNullOrWhiteSpace(model.CityName))
        //    {
        //        ModelState.AddModelError("City", "Enter Valid City");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        return RedirectToAction("Message");
        //    }



        //    //if (ModelState.IsValid)
        //    //{
        //    //    TempData["Message"] = "Welcome Back!";
        //    //    TempData["Message1"] = "Welcome Back!!!!";
        //    //    var serealized = JsonSerializer.Serialize(model);
        //    //    HttpContext.Session.SetString("User", serealized);
        //    //    Response.Cookies.Append("nonpersistent", "nonpersistent cookie");
        //    //    Response.Cookies.Append("persistent", "persistent cookie",new CookieOptions { Expires= DateTime.Now.AddDays(1)});
        //    //    return RedirectToAction("Message");
        //    //}
        //    // If we got this far, something failed; redisplay form.
        //    return View(model);
        //}
        //public IActionResult Message()
        //{
        //    //var msg =(string) TempData["Message"];//one time read
        //    //var msg1 =(string) TempData.Peek("Message1");//multiple read
        //    //var data = HttpContext.Session.GetString("User");
        //    //var model = JsonSerializer.Deserialize<UserModel>(data);
        //    //var nonpersistent =  Request.Cookies["nonpersistent"];
        //    //var persistent =  Request.Cookies["persistent"];

        //    return View();
        //}


        #endregion
    }
}
