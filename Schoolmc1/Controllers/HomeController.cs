using Schoolmc1.DTO;
using Schoolmc1.Models;
using Schoolmc1.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;

namespace Schoolmc1.Controllers
{
    public class HomeController : Controller
    {
        RequestRepository requestRepo ;
        StateRepository stateRepo ;
        CourseRepository courseRepo;

        public HomeController()
        {
            var context = new SchoolDataEntities1();
            requestRepo = new RequestRepository(context);
            courseRepo = new CourseRepository(context);
            stateRepo = new StateRepository(context);
           
        }
        public ActionResult Create()
        {
            RequestViewModel vm = new RequestViewModel();
            //var vm = new CreateRequestViewModel();
            vm.StateId = stateRepo.Get().Select(x => new SelectListItem()
            {
                Text = x.StateName,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.Courses = new MultiSelectList(courseRepo.Get(), "Id", "CourseTitle");

            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(RequestViewModel requestViewModel)
        {
            foreach(int id in requestViewModel.CourseIds)
            {
                Course course = courseRepo.GetById(id);
                requestViewModel.NewRequest.Courses.Add(course);
            }
            requestRepo.Insert(requestViewModel.NewRequest);
            requestRepo.Save();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            RequestViewModel vm = new RequestViewModel();

            vm.StateId = stateRepo.Get().Select(x => new SelectListItem()
            {
                Text = x.StateName,
                Value = x.Id.ToString()
            }).ToList();

            vm.NewRequest = requestRepo.GetById(id);
            var cou = vm.NewRequest.Courses.Select(x => x.Id);
            //ViewBag.Courses = new MultiSelectList(db.Courses.ToList(), "Id", "CourseTitle");
            ViewBag.Courses = new MultiSelectList(courseRepo.Get(), "Id", "CourseTitle", cou);
            return View(vm);
        }

        //        [HttpPost]
        //        //public ActionResult Edit(RequestViewModel vm)
        //        //{
        //        //    var updateRequest = db.Requests.Include("Courses").ToList();
        //        //    var request = db.Requests.Find(vm.NewRequest.Id);
        //        //    db.Entry(request).CurrentValues.SetValues(vm.NewRequest);
        //        //    var coursesArray = request.Courses.ToArray();
        //        //    for (var i = 0; i < coursesArray.Length; i++)
        //        //    {
        //        //        request.Courses.Remove(coursesArray[i]);
        //        //    }
        //        //    foreach (var cid in vm.CourseIds)
        //        //    {
        //        //        var addedCourse = db.Courses.Find(cid);
        //        //        db.Courses.Attach(addedCourse);
        //        //        request.Courses.Add(addedCourse);
        //        //    }
        //        //    db.SaveChanges();
        //        //    return RedirectToAction("Details");
        //        //}

        public ActionResult Edit(RequestViewModel requestViewModel)
        {
            Request request = requestRepo.GetById(requestViewModel.NewRequest.Id);

            var coursesArray = request.Courses.ToArray();
            for (var i = 0; i < coursesArray.Length; i++)
            {
                request.Courses.Remove(coursesArray[i]);
            }
            foreach (int id in requestViewModel.CourseIds)
            {
                Course course = courseRepo.GetById(id);
                requestViewModel.NewRequest.Courses.Add(course);
            }

            requestRepo.Update(requestViewModel.NewRequest.Id, requestViewModel.NewRequest);
            requestRepo.Save();
            return View("Details", requestViewModel.NewRequest);
        }


        //Home/Index
        public ActionResult Index(string str)
        {
            IEnumerable<Request> request = requestRepo.Get();
            return View(Mapper.Map<IEnumerable<RequestDto>>(request));


            //if (!string.IsNullOrEmpty(str))
            //{
            //    return View(requestRepo.GetBy(x => x.FirstName == str ||
            //    x.LastName == str).OrderByDescending(x => x.Id).ToList());
            //}
            //return View(requestRepo.Get().OrderByDescending(x => x.Id).ToList());
            
            //List<RequestDto> requestDto = new List<RequestDto>();
            //IEnumerable<Request> request = requestRepo.Get();
            //foreach (var x in request)
            //{
            //    RequestDto reqDto = new RequestDto();
            //    reqDto.FirstName = x.FirstName;
            //    reqDto.LastName = x.LastName;
            //    reqDto.City = x.City;
            //    reqDto.StateName = x.state.StateName;
            //    reqDto.EmailAddress = x.EmailAddress;
            //    reqDto.Id = x.Id;
            //    reqDto.PhoneNumber = x.PhoneNumber;
            //    requestDto.Add(reqDto);
            //}
            //return View(requestDto);
            //var index = requestRepo.Get();
            //return View(index);
        }

        //        public ActionResult GetBy(string str)
        //        {
        //            return View(requestRepo.GetBy(x => x.FirstName == str || x.LastName == str));
        //        }


        //        //public ActionResult Details(int id)
        //        //{
        //        //    var k = db.Requests.Find(id);
        //        //    if (k == null)
        //        //    {
        //        //        var data = db.Requests.ToList();
        //        //        return View("Index", data);
        //        //    }
        //        //    return View(k);
        //        //}
        public ActionResult Details(int id)
        {
            var k = requestRepo.GetById(id);
            return View(k);
        }

    }
}