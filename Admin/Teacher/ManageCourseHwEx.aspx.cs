using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;

public partial class Admin_ManageCourseHwEx : System.Web.UI.Page
{
    private string pagetype;
    private Dictionary<string, string> exInfo = new Dictionary<string, string>();
    private Dictionary<string, string> hoInfo = new Dictionary<string, string>();
    private IEnumerable<Experiment> experimentlist;
    private IEnumerable<Homework> homeworklist;

    List<Exnode> exlist = new List<Exnode>();
    List<Honode> holist = new List<Honode>();

    protected void Page_Load(object sender, EventArgs e)
    {
        pagetype = "ho";
        int id = 9;
        CourseExperiment courseExperiment = (CourseExperiment)new ExperimentServiceImpl().GetCourseExperimentById(id);
        IEnumerable<CourseSelection> recoders = new CourseSelectionServiceImpl().GetRecordStudentByCourseId(courseExperiment.CourseId);
        if (pagetype == "ex")
        {
            id = 8;
            exInfo.Add("name", courseExperiment.Name);
            exInfo.Add("deadline", courseExperiment.Deadline.ToString());
            exInfo.Add("purpose", courseExperiment.Purpose);
            exInfo.Add("steps", courseExperiment.Steps);
            exInfo.Add("references", courseExperiment.References);

            

            foreach(var i in recoders)
            {
                using (var context = new HaermsEntities())
                {
                    var queryans = context.Experiment.Where(ex => ex.CourseExperimentId == courseExperiment.CourseExperimentId && i.StudentId == ex.StudentId);
                    Exnode newnode = new Exnode();
                    if (queryans.FirstOrDefault() != null)
                    {
                        newnode.filename = queryans.FirstOrDefault().Name;
                        newnode.exid = queryans.FirstOrDefault().ExperimentId.ToString();
                        newnode.mark = queryans.FirstOrDefault().Mark == null ? "0" : queryans.FirstOrDefault().Mark.ToString();
                        newnode.path = queryans.FirstOrDefault().Path;
                    }
                    else
                    {
                        newnode.filename = null;
                        newnode.exid = null;
                    }
                    newnode.stuname = context.Student.Find(i.StudentId).Name;
                    newnode.stunum = context.Student.Find(i.StudentId).StudentNumber;

                    exlist.Add(newnode);
                }
            }
        }
        else if(pagetype=="ho")
        {
            id = 7;
            CourseHomework courseHomework = (CourseHomework)new HomeworkServiceImpl().GetCourseHomeworkByCourseId(id);
            hoInfo.Add("name", courseHomework.Name);
            hoInfo.Add("deadline", courseHomework.Deadline.ToString());
            hoInfo.Add("purpose", courseHomework.Content);
            
            foreach(var i in recoders)
            {
                using (var context = new HaermsEntities())
                {
                    var queryans = context.Homework.Where(ho => ho.CourseHomeworkId == id && ho.StudentId == i.StudentId);
                    Honode newnode = new Honode();
                    if (queryans.FirstOrDefault() != null)
                    {
                        newnode.filename = queryans.FirstOrDefault().Name;
                        newnode.hoid = queryans.FirstOrDefault().HomeworkId.ToString();
                        newnode.mark = queryans.FirstOrDefault().Mark == null ? "0" : queryans.FirstOrDefault().Mark.ToString();
                        newnode.path = queryans.FirstOrDefault().Path;
                    }
                    else
                    {
                        newnode.filename = null;
                        newnode.hoid = null;
                    }
                    newnode.stuname = context.Student.Find(i.StudentId).Name;
                    newnode.stunum = context.Student.Find(i.StudentId).StudentNumber;
                    holist.Add(newnode);
                }
            }
        }
    }

    public string PageType
    {
        get
        {
            return pagetype;
        }
    }
    
    public Dictionary<string, string> ExInfo
    {
        get
        {
            return exInfo;
        }
    }

    public Dictionary<string, string> HoInfo
    {
        get
        {
            return hoInfo;
        }
    }

    public List<Exnode> ExList
    {
        get
        {
            return exlist;
        }
    }

    public List<Honode> HoList
    {
        get
        {
            return holist;
        }
    }

    protected void updatemark_Click(object sender, EventArgs e)
    {
        string markstring = Request.Form.Get("input-mark");
        if(markstring == null)
        {
            return ;
        }
        var marklist = markstring.Split(',');
        int p = 0;
        if(pagetype == "ex")
        {
            foreach (var i in exlist)
            {
                if (i.filename != null)
                {
                    using (var context = new HaermsEntities())
                    {
                        int experimentid = int.Parse(i.exid);
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
            foreach(var i in holist)
            {
                if(i.filename != null)
                {
                    using (var context = new HaermsEntities())
                    {
                        int homeworkid = int.Parse(i.hoid);
                        var queryset = context.Homework.Where(ho => ho.HomeworkId == homeworkid);
                        var thefirst = queryset.FirstOrDefault();
                        if(thefirst != null)
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