using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;
using Utils;

namespace Admin.Teacher
{
    public partial class Admin_ManageCourseHwEx : System.Web.UI.Page
    {
        private IEnumerable<Experiment> experimentlist;
        private IEnumerable<Homework> homeworklist;

        readonly List<Exnode> exlist = new List<Exnode>();
        readonly List<Honode> holist = new List<Honode>();

        protected void Page_Load(object sender, EventArgs e)
        {
            AuthHelper.LoginCheck(Session, Request, Response, Server);
            if (Request.QueryString["pt"] == null || Request.QueryString["id"] == null)
            {
                return;
            }

            PageType = Request.QueryString["pt"];
            int id = int.Parse(Request.QueryString["id"]);

            if (PageType == "ex")
            {
                var courseExperiment =
                    (CourseExperiment) new ExperimentServiceImpl().GetCourseExperimentById(id);
                var recoders =
                    new CourseSelectionServiceImpl().GetRecordStudentByCourseId(courseExperiment.CourseId);
                ExInfo.Add("name", courseExperiment.Name);
                ExInfo.Add("deadline", courseExperiment.Deadline.ToString());
                ExInfo.Add("purpose", courseExperiment.Purpose);
                ExInfo.Add("steps", courseExperiment.Steps);
                ExInfo.Add("references", courseExperiment.References);


                foreach (var i in recoders)
                {
                    using (var context = new HaermsEntities())
                    {
                        var queryans = context.Experiment.Where(ex =>
                            ex.CourseExperimentId == courseExperiment.CourseExperimentId && i.StudentId == ex.StudentId);
                        var newnode = new Exnode();
                        if (queryans.FirstOrDefault() != null)
                        {
                            newnode.filename = queryans.FirstOrDefault()?.Name;
                            newnode.exid = queryans.FirstOrDefault()?.ExperimentId.ToString();
                            newnode.mark = queryans.FirstOrDefault()?.Mark == null
                                ? "0"
                                : queryans.FirstOrDefault()?.Mark.ToString();
                            newnode.path = queryans.FirstOrDefault()?.Path;
                        }
                        else
                        {
                            newnode.filename = null;
                            newnode.exid = null;
                        }
                        newnode.stuname = context.Student.Find(i.StudentId)?.Name;
                        newnode.stunum = context.Student.Find(i.StudentId)?.StudentNumber;

                        exlist.Add(newnode);
                    }
                }
            }
            else if (PageType == "ho")
            {
                var courseHomework = new HomeworkServiceImpl().GetCourseHomeworkByCourseId(id);
                var recoders =
                    new CourseSelectionServiceImpl().GetRecordStudentByCourseId(courseHomework.CourseId);
                HoInfo.Add("name", courseHomework.Name);
                HoInfo.Add("deadline", courseHomework.Deadline.ToString(CultureInfo.InvariantCulture));
                HoInfo.Add("purpose", courseHomework.Content);

                foreach (var i in recoders)
                {
                    using (var context = new HaermsEntities())
                    {
                        var queryans =
                            context.Homework.Where(ho => ho.CourseHomeworkId == id && ho.StudentId == i.StudentId);
                        Honode newnode = new Honode();
                        if (queryans.FirstOrDefault() != null)
                        {
                            newnode.filename = queryans.FirstOrDefault()?.Name;
                            newnode.hoid = queryans.FirstOrDefault()?.HomeworkId.ToString();
                            newnode.mark = queryans.FirstOrDefault()?.Mark == null
                                ? "0"
                                : queryans.FirstOrDefault()?.Mark.ToString();
                            newnode.path = queryans.FirstOrDefault()?.Path;
                        }
                        else
                        {
                            newnode.filename = null;
                            newnode.hoid = null;
                        }
                        newnode.stuname = context.Student.Find(i.StudentId)?.Name;
                        newnode.stunum = context.Student.Find(i.StudentId)?.StudentNumber;
                        holist.Add(newnode);
                    }
                }
            }
        }

        protected string PageType { get; private set; }

        protected Dictionary<string, string> ExInfo { get; } = new Dictionary<string, string>();

        protected Dictionary<string, string> HoInfo { get; } = new Dictionary<string, string>();

        protected IEnumerable<Exnode> ExList => exlist;

        protected IEnumerable<Honode> HoList => holist;

        protected void updatemark_Click(object sender, EventArgs e)
        {
            var markstring = Request.Form.Get("input-mark");
            if (markstring == null)
            {
                return;
            }
            var marklist = markstring.Split(',');
            var p = 0;
            if (PageType == "ex")
            {
                foreach (var i in exlist)
                {
                    if (i.filename != null)
                    {
                        using (var context = new HaermsEntities())
                        {
                            var experimentid = int.Parse(i.exid);
                            var queryset = context.Experiment.Where(ex => ex.ExperimentId == experimentid);
                            var thefirst = queryset.FirstOrDefault();
                            if (thefirst != null)
                            {
                                thefirst.Mark = int.Parse(marklist[p]);
                                context.SaveChanges();
                            }
                        }
                    }
                    p++;
                }
            }
            else
            {
                foreach (var i in holist)
                {
                    if (i.filename != null)
                    {
                        using (var context = new HaermsEntities())
                        {
                            var homeworkid = int.Parse(i.hoid);
                            var queryset = context.Homework.Where(ho => ho.HomeworkId == homeworkid);
                            var thefirst = queryset.FirstOrDefault();
                            if (thefirst != null)
                            {
                                thefirst.Mark = int.Parse(marklist[p]);
                                context.SaveChanges();
                            }
                        }
                    }
                    p++;
                }
            }
        }
    }

    public class Exnode
    {
        public string stunum;
        public string stuname;
        public string filename;
        public string exid;
        public string mark;
        public string path;
    }

    public class Honode
    {
        public string stunum;
        public string stuname;
        public string filename;
        public string hoid;
        public string mark;
        public string path;
    }
}