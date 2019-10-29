using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicTacToe.Helpers.AbstractFactory;
using TicTacToe.Helpers.Builder;
using TicTacToe.Models;
using TicTacToe.Repositories;
using TicTacToe.Helpers.Decorator;

namespace TicTacToe.Controllers
{
    public class GameController : Controller
    {
        private readonly Repo repo;
        private AbstractResult resultdecorator;

        public GameController(Repo repo)
        {
            this.repo = repo;
        }
        public IActionResult Small()
        {
            var list = repo.GetResults();
            GetDecorated(list);
            ViewBag.Results = list;
            return returnView(MethodBase.GetCurrentMethod().Name.ToLower());
        }
        public IActionResult Medium()
        {            
            return returnView(MethodBase.GetCurrentMethod().Name.ToLower());
        }
        private IActionResult returnView(string method)
        {
            var director = new Director(BuilderFactory.GetBuilder(method));
            director.Construct();
            return View(director.GetBoard);
        } 
        [HttpPost]
        public JsonResult SetValue(string id, string value)
        {
            repo.SetResult(new Result { Id = id, Value = value });
            return Json(true);
        }
        public IActionResult Reset()
        {
            repo.ResetResult();
            return RedirectToAction(nameof(Small));
        }
        private void GetDecorated(List<Result> results)
        {
            if (results.Count>2 &&
                results[0].Value==results[1].Value && 
                results[0].Value==results[2].Value &&
                results[0].Id.StartsWith("r_0") &&
                results[1].Id.StartsWith("r_0")&& 
                results[2].Id.StartsWith("r_0"))
            {
                AbstractResult result1 = new ResultDecorator(results[0]);
                result1.Decorate();
                AbstractResult result2 = new ResultDecorator(results[1]);
                result2.Decorate();
                AbstractResult result3 = new ResultDecorator(results[2]);
                result3.Decorate();
            }
        }
    }
}