using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prn211.Models;

namespace prn211.Controllers
{
	public class AdminController : Controller
	{	
		prn211Context db = new prn211Context();
		
        [Route("listsubject")]
        public IActionResult List()
		{
            int loginid = Int32.Parse(HttpContext.Session.GetString("loginid"));
			int courseownerid = db.CourseOwners.Where(x => x.Userid == loginid).FirstOrDefault().Ownerid;
			List<Course> courses = db.Courses.Where(x => x.Ownerid == courseownerid).ToList();
            
            ViewBag.Courses = courses;
            return View();
		}
		[Route("addsubject")]
		public IActionResult AddSubject()
		{
			  return View();
		}


        [HttpPost]
        [Route("DeleteCourse")]
        public IActionResult DeleteCourse(int courseId)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Courseid == courseId);

            if (course == null)
            {
                // Handle the case where the course is not found (e.g., show an error message).
                return RedirectToAction("List");
            }

            // Xóa các bản ghi liên quan trong bảng "courseOwner"
            db.Enrolls.RemoveRange(db.Enrolls.Where(e => e.Courseid == courseId));
            db.CourseContents.RemoveRange(db.CourseContents.Where(cc => cc.Coursesectionid == courseId));

            // Xóa khóa học
            List<CourseSection> delsection = db.CourseSections.Where(cs => cs.Courseid == courseId).ToList();
            foreach(CourseSection cs in delsection)
            {
                foreach (CourseContent ct in db.CourseContents.Where(cc => cc.Coursesectionid == cs.SectionId).ToList())
                {
                    db.CourseContents.Remove(ct);
                }
                db.CourseSections.Remove(cs);
            }
            
            db.Courses.Remove(course);

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();

            return RedirectToAction("List");
        }



        [Route("EditCourse")]
		public IActionResult EditCourse(int courseid, string coursename) 
		{	                                                             
		    Course course = db.Courses.FirstOrDefault();
            List<CourseSection> courseSections = db.CourseSections.Where(cs => cs.Courseid == courseid).ToList();
            ViewData["CourseSections"] = courseSections;
            ViewData["Coursename"] = coursename; 
		    
		    return View(course); 
		}
	}
}
