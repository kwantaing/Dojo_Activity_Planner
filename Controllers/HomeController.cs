using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSharpBelt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace CSharpBelt.Controllers
{
    public class HomeController : Controller
    {
        public MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    
    public IActionResult Register(User user)
        {
            if(ModelState.IsValid){

                if(dbContext.Users.Where(u => u.email==user.email).ToList().Count>0){
                    //Guest with that email already exists
                    ModelState.AddModelError("email","Email is already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.password = Hasher.HashPassword(user, user.password);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                var newguest = dbContext.Users.Last();
                newguest.created_at = DateTime.Now;
                newguest.updated_at = DateTime.Now;
                
                int id = newguest.user_id;
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("user_id",id);

                return RedirectToAction("Welcome");

            }else{
                return View("Index");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser user){
            if(ModelState.IsValid){
                if(dbContext.Users.FirstOrDefault(u => u.email == user.logEmail) ==null){
                    ModelState.AddModelError("logEmail", "Invalid Email/Password");
                    return View("Index");
                }
                var correctUser = dbContext.Users.First(u =>u.email == user.logEmail);
                var hasher = new PasswordHasher<LogUser>();

                if(hasher.VerifyHashedPassword(user,correctUser.password,user.logPassword)!=0){
                    HttpContext.Session.SetInt32("user_id",correctUser.user_id);
                    return RedirectToAction("Welcome");
                }else{
                    ModelState.AddModelError("logEmail","Invalid Email/Password");
                    return View("Index");
                }
            }
            return View("Index");   
        }
        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return View("Index");
        }
        [HttpGet("dashboard")]
        public IActionResult Welcome()
        {
            int ? current_user_id = HttpContext.Session.GetInt32("user_id");
            if(current_user_id==null){
                ModelState.AddModelError("email","Not logged in, please register or log in.");
                return View("Index");
            }else{
                removeExpired();
                var user = dbContext.Users.First(u => u.user_id == current_user_id);
                ViewBag.user_name = user.name;
                ViewBag.user_id = user.user_id;
                var allActivities = dbContext.Activities
                        .OrderByDescending(a => a.date)
                        .Include(a =>a.Coordinator)
                        .Include(a => a.Plans)
                        .ToList();
                return View("Dashboard",allActivities);
            }
        }
        [HttpGet("new")]
        public IActionResult newActPage()
        {
            int ? current_user_id = HttpContext.Session.GetInt32("user_id");
            if(current_user_id==null){
                ModelState.AddModelError("email","Not logged in, please register or log in.");
                return View("Index");
            }else{
                var user = dbContext.Users.First(u => u.user_id == current_user_id);
                ViewBag.user_name = user.name;
                ViewBag.user_id = user.user_id;
                return View("New");
            }
        }

        [HttpPost("new")]
        public IActionResult newActivity(DojoActivity activity)
        {
            var coordinator =  dbContext.Users.First(u => u.user_id == activity.coordinator_id);
            if(ModelState.IsValid)
            {
                activity.Coordinator = coordinator;
                dbContext.Activities.Add(activity);
                dbContext.SaveChanges();
                return RedirectToAction("Welcome");
            }else
            {
                ViewBag.user_name = coordinator.name;
                ViewBag.user_id = coordinator.user_id;
                return View("New");
            }
        }
        [HttpGet("activity/{activity_id}")]
        public IActionResult Detail(int activity_id)
        {
            var act = dbContext.Activities
                            .Include(a => a.Coordinator)
                            .Include(a => a.Plans)
                                .ThenInclude(p => p.Participant)
                            .FirstOrDefault(a => a.activity_id == activity_id);
            if(act == null)
            {
                //activity doesn't exist
                return RedirectToAction("Welcome");
            }else
            {
                int ? current_user_id = HttpContext.Session.GetInt32("user_id");
                if(current_user_id == null)
                {
                    return RedirectToAction("Index");
                }else
                {
                    var current_user = dbContext.Users.FirstOrDefault(u => u.user_id ==current_user_id);
                    if(current_user == null)
                    {
                        return RedirectToAction("Index");
                    }else
                    {
                        ViewBag.user_name = current_user.name;
                        ViewBag.user_id = current_user.user_id;
                        return View("Detail",act);
                    }
            }

                }
        }
        [HttpGet("activity/{id}/delete")]
        public IActionResult removeActivity(int id)
        {
            int ? session_id = HttpContext.Session.GetInt32("user_id");
            if(session_id == null)
            {
                return RedirectToAction("Index");
            }else
            {
                var current_user = dbContext.Users.FirstOrDefault(u => u.user_id == session_id);
                if(current_user == null)
                {
                    return RedirectToAction("Index");
                }else
                {
                    var tobeRemoved = dbContext.Activities.FirstOrDefault(a => a.activity_id == id);
                    if(tobeRemoved == null)
                    {
                        return RedirectToAction("Index");
                    }else
                    {
                        if(tobeRemoved.coordinator_id == current_user.user_id)
                        {
                            dbContext.Activities.Remove(tobeRemoved);
                            dbContext.SaveChanges();
                            return RedirectToAction("Welcome");
                        }else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }

            }
        }
        
        [HttpGet("activity/{id}/join")]
        public IActionResult joinActivity(int id)
        {
            int ? user_id = HttpContext.Session.GetInt32("user_id");
            if(user_id == null)
            {
                return RedirectToAction("Index");
            }else
            {
                var current_user = dbContext.Users.FirstOrDefault(u => u.user_id == user_id);
                if(current_user == null)
                {
                    return RedirectToAction("Index");
                }else
                {
                    Plan newPlan = new Plan(id,current_user.user_id);
                    dbContext.Plans.Add(newPlan);
                    dbContext.SaveChanges();
                    current_user.Plans.Add(dbContext.Plans.Last());
                    dbContext.SaveChanges();
                    return RedirectToAction("Welcome");   

                }
            }

        }
        [HttpGet("activity/{id}/joininDetail")]
        public IActionResult joinActivityinDetail(int id)
        {
            int ? user_id = HttpContext.Session.GetInt32("user_id");
            if(user_id == null)
            {
                return RedirectToAction("Index");
            }else
            {
                var current_user = dbContext.Users.FirstOrDefault(u => u.user_id == user_id);
                if(current_user == null)
                {
                    return RedirectToAction("Index");
                }else
                {
                    Plan newPlan = new Plan(id,current_user.user_id);
                    dbContext.Plans.Add(newPlan);
                    dbContext.SaveChanges();
                    current_user.Plans.Add(dbContext.Plans.Last());
                    dbContext.SaveChanges();
                    return RedirectToAction("Detail",new{id = id});   

                }
            }

        }
        [HttpGet("activity/{id}/leave")]
        public IActionResult leaveActivity(int id)
        {
            int ? user_id = HttpContext.Session.GetInt32("user_id");
            if(user_id == null)
            {
                return RedirectToAction("Index");
            }else
            {
                var current_user = dbContext.Users.FirstOrDefault(u => u.user_id == user_id);
                if(current_user == null)
                {
                    return RedirectToAction("Index");
                }else
                {
                    var activityPlans = dbContext.Plans.Where(p => p.activity_id == id).ToList();
                    int i = 0;
                    while( i <activityPlans.Count)
                    {
                        if(activityPlans[i].user_id == current_user.user_id)
                        {
                            current_user.Plans.Remove(activityPlans[i]);
                            dbContext.Plans.Remove(activityPlans[i]);
                            dbContext.SaveChanges();
                            return RedirectToAction("Welcome");
                        }
                        i++;                        
                    }

                    return RedirectToAction("Welcome");   

                }
            }

        }
        [HttpGet("activity/{id}/leaveinDetail")]
        public IActionResult leaveActivityinDetail(int id)
        {
            int ? user_id = HttpContext.Session.GetInt32("user_id");
            if(user_id == null)
            {
                return RedirectToAction("Index");
            }else
            {
                var current_user = dbContext.Users.FirstOrDefault(u => u.user_id == user_id);
                if(current_user == null)
                {
                    return RedirectToAction("Index");
                }else
                {
                    var planLeave = dbContext.Plans.FirstOrDefault(p => p.activity_id == id);
                    if(planLeave.user_id == current_user.user_id)
                    {
                        current_user.Plans.Remove(planLeave);
                        dbContext.Plans.Remove(planLeave);
                        dbContext.SaveChanges();
                        return RedirectToAction("Detail",new{id = id});

                    }

                    return  RedirectToAction("Welcome");

                }
            }

        }
        public void removeExpired()
        {
            var allActivities = dbContext.Activities.ToList();
            foreach(var activity in allActivities)
            {
                var timeNdate = activity.date + activity.time;
                if(timeNdate <DateTime.Now)
                {
                    dbContext.Remove(activity);
                    dbContext.SaveChanges();
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
