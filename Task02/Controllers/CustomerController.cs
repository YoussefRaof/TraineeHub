using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task02.Context;
using Task02.Models;
using Task02.ViewModels;

namespace Task02.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Lab8Task02DbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerController(Lab8Task02DbContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
           _mapper = mapper;
        }
     
        //done
        public ActionResult Index()
        {
           var Customers = _dbContext.Customers.ToList();
            return View(Customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(C=> C.Produdcts).FirstOrDefault(C=> C.Id ==id);
            var mappedCustomer = _mapper.Map<Customer,ProductCustViewModel>(customer);
            return View(mappedCustomer);
        }

     
        //done
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Done
        [HttpPost]
       
        public ActionResult Create(Customer customer)
        {
            if (customer is not null)
            {
                try
                {
                    if(ModelState.IsValid)
                    {
                        _dbContext.Customers.Add(customer);
                        if(_dbContext.SaveChanges() > 0)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    return View(customer);

                
                }
                catch(Exception Ex)
                {
                    Console.WriteLine(Ex.Message); 
                }
            }
            return View(customer);
        
        }

        //done
        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            return View(customer);
        }

        //done
        [HttpPost]
       
        public ActionResult Edit(Customer customer)
        {
            if (customer is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _dbContext.Customers.Update(customer);
                        if (_dbContext.SaveChanges() > 0)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    return View(customer);


                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
            return View(customer);
        }

       
        public ActionResult Delete(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            return View(customer);
           
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
    
        public ActionResult Delete(Customer customer)
        {
            if (customer is not null)
            {
                try
                {

                    _dbContext.Remove(customer);
                    if (_dbContext.SaveChanges() > 0)
                        return RedirectToAction(nameof(Index));

                   

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(customer);
        }
    }
}
