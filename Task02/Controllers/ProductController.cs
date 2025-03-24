using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task02.Context;
using Task02.Models;

namespace Task02.Controllers
{
    public class ProductController : Controller
    {
        private readonly Lab8Task02DbContext _dbContext;

        public ProductController(Lab8Task02DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //done
        public ActionResult Index()
        {
            var Products = _dbContext.Products.Include(P => P.Customer).ToList();
            return View(Products);
        }

     
        public ActionResult Details(int id)
        {
            var product = _dbContext.Products.Include(P => P.Customer).FirstOrDefault(P=>P.Id == id);
            return View(product);
        }

        
        public ActionResult Create()
        {
            ViewBag.AllCustomers = _dbContext.Customers.ToList();
            return View();
        }

  
        [HttpPost]
  
        public ActionResult Create(Product product)
        {
            ViewBag.AllCustomers = _dbContext.Customers.ToList();
            if (product is not null)
            {
                try
                {
                    if(ModelState.IsValid)
                    {
                        _dbContext.Add(product);
                        if(_dbContext.SaveChanges()>0)
                            return RedirectToAction(nameof(Index));
                    }
                    return View(product);
                   
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(product);

        }

       
        public ActionResult Edit(int id)
        {
            ViewBag.AllCustomers = _dbContext.Customers.ToList();
            var Product = _dbContext.Products.Include(P => P.Customer).FirstOrDefault(P=>P.Id == id);
            return View(Product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(Product product)
        {
            ViewBag.AllCustomers = _dbContext.Customers.ToList();
            if (product is not null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _dbContext.Update(product);
                        if (_dbContext.SaveChanges() > 0)
                            return RedirectToAction(nameof(Index));
                    }
                    return View(product);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.AllCustomers = _dbContext.Customers.ToList();
            var product = _dbContext.Products.Find(id);
            return View(product);
        }

     
        [HttpPost]
    
        public ActionResult Delete(Product product)
        {
            ViewBag.AllCustomers = _dbContext.Customers.ToList();
            if (product is not null)
            {
                try
                {
                    
                        _dbContext.Remove(product);
                        if (_dbContext.SaveChanges() > 0)
                            return RedirectToAction(nameof(Index));
                    
                    return View(product);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(product);
        }
    }
}
