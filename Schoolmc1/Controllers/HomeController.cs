using Schoolmc1.DTO;
using Schoolmc1.Models;
using Schoolmc1.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList.Mvc;
using PagedList;

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
            ViewBag.Courses = new MultiSelectList(courseRepo.Get(), "Id", "CourseTitle", cou);
            return View(vm);
        }

        [HttpPost]
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
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            //ViewBag.SortLastNameParameter = string.IsNullOrEmpty(sortBy) ? "LastName desc" : "";
            //ViewBag.SortStateParameter = sortBy == "State" ? "State desc" : "State";
            //var request = Mapper.Map<IEnumerable<RequestDto>>(requestRepo.Get()).AsQueryable();
            if (searchBy == "City")
            {
                //request = request.Where(x => x.City.StartsWith(search) ||
                //search == null);

                return View(Mapper.Map<IEnumerable<RequestDto>>(requestRepo.GetBy(x => x.City.StartsWith(search) ||
                search == null).ToList()).ToPagedList(page ?? 1, 10));
            }
            else if(searchBy == "FirstName")
            {
                //request = request.Where(x => x.FirstName.StartsWith(search) ||
                //search == null);

                return View(Mapper.Map<IEnumerable<RequestDto>>(requestRepo.GetBy(x => x.FirstName.StartsWith(search) ||
                search == null).ToList()).ToPagedList(page ?? 1, 10));
            }
            return View(Mapper.Map<IEnumerable<RequestDto>>(requestRepo.Get()).ToPagedList(page ?? 1, 10));


            //if (!string.IsNullOrEmpty(search))
            //{
            //    return View(Mapper.Map<IEnumerable<RequestDto>>(requestRepo.GetBy(x => x.FirstName.Contains(search) ||
            //    x.LastName.Contains(search)).ToList()));
            //}
            //return View(Mapper.Map<IEnumerable<RequestDto>>(requestRepo.Get()));


            ////IEnumerable<Request> request = requestRepo.Get();
            ////return View(Mapper.Map<IEnumerable<RequestDto>>(request));


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

        public ActionResult Details(int id)
        {
            var k = requestRepo.GetById(id);
            return View(k);
        }

    }
}