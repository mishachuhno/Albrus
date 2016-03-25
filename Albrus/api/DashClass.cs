using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Albrus.api
{
    public class DashClass
    {
        public Int32 idDash;
        public Int32 idProj;
        public string name;
        public string information;
        public DateTime dataCreate;
        public int position;
        public List<TaskClass> tasks = new List<TaskClass>();
        public DashClass(DashBoardTask dash)
        {
            idDash = dash.idDash;
            idProj = Convert.ToInt32(dash.idProj);
            name = dash.name;
            information = dash.information;
            dataCreate = Convert.ToDateTime(dash.dataCreate);
            position = Convert.ToInt16(dash.position);
            List<TaskProject> taskProgect = new List<TaskProject>();
            using (DataProjectListDataContext DCDC = new DataProjectListDataContext())
            {
                taskProgect = (from task in DCDC.TaskProjects where task.position != null && task.idDash==dash.idDash select task).ToList();
            }
            foreach (TaskProject task_j in taskProgect)
            {
                TaskClass task_i = new TaskClass(task_j);
                tasks.Add(task_i);
            }
        }
    }
    public class TaskClass
    {
        public Int32 idTask;
        public Int32 idDash;
        public string name;
        public string information;
        public int position;
        public DateTime dataCreate;
        public DateTime dataStart;
        public DateTime dataEnd;
        public List<ExersiceTask> exers = new List<ExersiceTask>();
        public TaskClass(TaskProject task)
        {
            idTask = task.idTask;
            idDash = Convert.ToInt32(task.idDash);
            name = task.name;
            information = task.information;
            position = Convert.ToInt16(task.position);
            dataCreate = Convert.ToDateTime(task.dataCreate);
            dataStart = Convert.ToDateTime(task.dataStart);
            dataEnd = Convert.ToDateTime(task.dataEnd);
            using (DataProjectListDataContext DCDC = new DataProjectListDataContext())
            {
                exers = (from ex in DCDC.ExersiceTasks where ex.idTask == task.idTask select ex).ToList();
            }
        }
    }
}