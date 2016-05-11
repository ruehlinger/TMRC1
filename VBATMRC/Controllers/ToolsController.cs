using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.Mvc.Shared;
using Syncfusion.Mvc.Grid;
using System.Collections;

namespace VBADashboard01.Controllers
{
    public partial class ToolsController : Controller
    {
        //
        // GET: /EditorsPackage/
        public ActionResult ToolsFeatures()
        {

            //multicolumndropdowncontrol
            MultiColumnDropDownModel<Student1> dropdown = new MultiColumnDropDownModel<Student1>();
            dropdown.DataSource = new Student1DataContext().JSONStudent1.Skip(0).Take(30).ToList();
            dropdown.TargetContentId = "--select--";
            dropdown.DisplayExpression = new int[3] { 2, 3, 5 };
            dropdown.Width = 430;
            dropdown.PopupPanelHeight = 200;
            dropdown.PopupPanelWidth = 430;
            dropdown.AllowFiltering = true;
            ViewData["dropdown"] = dropdown;

            ViewData["ProductName"] = "Tools";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ToolsFeatures(MultiColumnDropDownModel<Student1> dropdown, PagingParams args)
        {
            if (args.RequestType == 0)
            {
                dropdown.DataSource = new Student1DataContext().JSONStudent1.Skip(0).Take(30).ToList();
                dropdown.Text = "--Select--";
                dropdown.DisplayExpression = new int[3] { 2, 3, 5 };
                dropdown.Width = 400;
                dropdown.PopupPanelWidth = 400;
                ViewData["dropdown"] = dropdown;
                ViewData["ProductName"] = "Tools";
                return View();
            }
            else
            {
                ViewData["ProductName"] = "Tools";
                IEnumerable data = new Student1DataContext().JSONStudent1.Skip(0).Take(30).ToList();
                return data.GridActions<Student1>();
            }
        }


        public ActionResult Editors()
        {
            ViewData["ProductName"] = "Tools";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetData(string QueryString)
        {
            List<string> syncProducts = new List<string>();
            syncProducts.Add("JQuery Vs Java Script");
            syncProducts.Add("Pro Sync Framework");
            syncProducts.Add("Asp.net MVC Tutorial");
            syncProducts.Add("Professional ASP.NET MVC 4 ");
            syncProducts.Add("Windows 8 Apps with XAML ");
            syncProducts.Add("Syncfusion jQuery_Succinctly");
            syncProducts.Add("Android Application Development");
            syncProducts.Add("Basics in C and C++");
            syncProducts.Add("Dot net Application development");
            syncProducts.Add("Programming in C#");
            syncProducts.Add("Advanced Java");
            var datasource = syncProducts.AsQueryable();
            return datasource.AutocompleteActionResult();
        }


        public ActionResult Save(IEnumerable<HttpPostedFileBase> upload)
        {
            foreach (var file in upload)
            {
                var fileName = System.IO.Path.GetFileName(file.FileName);
                var destinationPath = System.IO.Path.Combine(Server.MapPath("~/App_Data"), fileName);
            }
            return Content("");
        }


        public ActionResult Remove(string[] fileNames)
        {
            foreach (var fullName in fileNames)
            {
                var fileName = System.IO.Path.GetFileName(fullName);
                var physicalPath = System.IO.Path.Combine(Server.MapPath("~/App_Data"), fileName);
                if (System.IO.File.Exists(physicalPath))
                {
                    // In this demo the files are not removed
                    //System.IO.File.Delete(physicalPath);
                }
            }
            return Content("");
        }

        //ToolsMenu###
        //ToolsToolbar###
    }


    public class Student1
    {
        #region Properties
        /// <summary>
        /// Gets or sets the student Name
        ///</summary>
        public long UniversityCode { get; set; }
        /// <summary>
        /// Gets or sets the course title
        ///</summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the duration in days of the course
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Gets or sets course fees
        /// </summary>
        public double CourseFees { get; set; }
        /// <summary>
        /// Gets or sets CGPA
        /// </summary>
        public double CGPA { get; set; }
        #endregion
    }
    public class Student1DataContext
    {
        #region Properties
        /// <summary>
        /// Gets  the courses in a IQueryable format
        ///</summary>
        public List<Student1>
          Student1
        {
            get
            {
                List<Student1>
                  student1 = new List<Student1>
                    ();
                Student1 stu = new Student1();
                int code = 10000;
                for (long i = 0; i < 100; i++)
                {
                    Student1[] s = new Student1[10];
                    s[0] = new Student1() { UniversityCode = code + 1, CourseFees = 2000.00, CGPA = 7.52, Duration = 90, Title = "Distributed Component Architecture" };
                    s[1] = new Student1() { UniversityCode = code + 2, CourseFees = 1000.00, CGPA = 9.55, Duration = 60, Title = "Data Structures" };
                    s[2] = new Student1() { UniversityCode = code + 3, CourseFees = 1750.00, CGPA = 9.03, Duration = 75, Title = "Neural Networks" };
                    s[3] = new Student1() { UniversityCode = code + 4, CourseFees = 2000.00, CGPA = 8.91, Duration = 90, Title = "Genetic Algorithms" };
                    s[4] = new Student1() { UniversityCode = code + 5, CourseFees = 1000.00, CGPA = 9.55, Duration = 30, Title = "Grid Computing" };
                    s[5] = new Student1() { UniversityCode = code + 6, CourseFees = 2500.00, CGPA = 9.87, Duration = 60, Title = "Cloud Computing" };
                    s[6] = new Student1() { UniversityCode = code + 7, CourseFees = 1500.00, CGPA = 9.75, Duration = 90, Title = "Enterprise Computing" };
                    s[7] = new Student1() { UniversityCode = code + 8, CourseFees = 1250.00, CGPA = 9.66, Duration = 45, Title = "Mobile Computing" };
                    s[8] = new Student1() { UniversityCode = code + 9, CourseFees = 1000.00, CGPA = 8.33, Duration = 60, Title = "WAP and XML" };
                    s[9] = new Student1() { UniversityCode = code + 10, CourseFees = 1500.00, CGPA = 8.66, Duration = 75, Title = "Design Patterns" };
                    foreach (Student1 studnt in s)
                    {
                        student1.Add(studnt);
                    }
                    code += 10;
                }
                return student1;
            }
        }
        /// <summary>
        /// Gets the JSONStudent
        ///</summary>
        public List<Student1>
          JSONStudent1
        {
            get
            {
                List<Student1>
                  student1 = new List<Student1>
                    ();
                Student1 stu = new Student1();
                int code = 10000;
                for (long i = 0; i < 1000; i++)
                {
                    Student1[] s = new Student1[10];
                    s[0] = new Student1() { UniversityCode = code + 1, CourseFees = 2000.00, CGPA = 7.52, Duration = 90, Title = "Distributed Component Architecture" };
                    s[1] = new Student1() { UniversityCode = code + 2, CourseFees = 1000.00, CGPA = 9.55, Duration = 60, Title = "Data Structures" };
                    s[2] = new Student1() { UniversityCode = code + 3, CourseFees = 1750.00, CGPA = 9.03, Duration = 75, Title = "Neural Networks" };
                    s[3] = new Student1() { UniversityCode = code + 4, CourseFees = 2000.00, CGPA = 8.91, Duration = 90, Title = "Genetic Algorithms" };
                    s[4] = new Student1() { UniversityCode = code + 5, CourseFees = 1000.00, CGPA = 9.55, Duration = 30, Title = "Grid Computing" };
                    s[5] = new Student1() { UniversityCode = code + 6, CourseFees = 2500.00, CGPA = 9.87, Duration = 60, Title = "Cloud Computing" };
                    s[6] = new Student1() { UniversityCode = code + 7, CourseFees = 1500.00, CGPA = 9.75, Duration = 90, Title = "Enterprise Computing" };
                    s[7] = new Student1() { UniversityCode = code + 8, CourseFees = 1250.00, CGPA = 9.66, Duration = 45, Title = "Mobile Computing" };
                    s[8] = new Student1() { UniversityCode = code + 9, CourseFees = 1000.00, CGPA = 8.33, Duration = 60, Title = "WAP and XML" };
                    s[9] = new Student1() { UniversityCode = code + 10, CourseFees = 1500.00, CGPA = 8.66, Duration = 75, Title = "Design Patterns" };
                    foreach (Student1 studnt in s)
                    {
                        student1.Add(studnt);
                    }
                    code += 10;
                }
                return student1;
            }
        }
        #endregion
    }

}
