using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Albrus.api
{
    public partial class Albrus : System.Web.UI.Page
    {
        const int VISIBLE_TRUE = 1;
        const int VISIBLE_FALSE = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetServerMessage(string name, string surname)
        {

            //ProgectCreate("TestProject1", "TestInfo1", DateTime.Now, DateTime.Now);
            //bool resault = ProjectUpdate(2, "FirstProject", "FirstInfo", DateTime.Now, DateTime.Now);
            //string str = ProjectGetAll();
            return "Hello " + surname + " " + name + Environment.NewLine + "At " + DateTime.Now.ToLongTimeString();
        }

        #region Method Project Create 
        [WebMethod]
        public static int ProgectCreate(string prName, string prInform, DateTime prDataStart, DateTime prDataEnd)
        {
            int prId = 0;

            try
            {
                using (DataProjectListDataContext database = new DataProjectListDataContext())
                {
                    ProjectList projectList = new ProjectList();
                    projectList.name = prName;
                    projectList.information = prInform;
                    projectList.dataStart = prDataStart;
                    projectList.dataEnd = prDataEnd;
                    projectList.visible = VISIBLE_TRUE;
                    database.ProjectLists.InsertOnSubmit(projectList);
                    database.SubmitChanges();

                    prId = projectList.idProj;
                }
            }
            catch (Exception e)
            {

            }

            return prId;
        }

        [WebMethod]
        public static bool ProjectUpdate(int prId, string prName, string prInform, DateTime prDataStart, DateTime prDataEnd)
        {
            bool resault = false;
            try
            {
                using (DataProjectListDataContext database = new DataProjectListDataContext())
                {
                    IEnumerable<ProjectList> projectCurrent = database.ProjectLists.Where(projectList => projectList.idProj == prId);

                    foreach (ProjectList p in projectCurrent)
                    {
                        p.name = prName;
                        p.information = prInform;
                        p.dataStart = prDataStart;
                        p.dataStart = prDataEnd;
                    }

                    database.SubmitChanges();
                }

                resault = true;
            }
            catch (Exception e)
            {

            }


            return resault;
        }

        [WebMethod]
        public static bool ProjectDelete(int prId)
        {
            bool resault = false;
            try
            {
                using (DataProjectListDataContext database = new DataProjectListDataContext())
                {
                    IEnumerable<ProjectList> projectCurrent = database.ProjectLists.Where(projectList => projectList.idProj == prId);

                    foreach (ProjectList p in projectCurrent)
                        p.visible = VISIBLE_TRUE;

                    database.SubmitChanges();
                }

                resault = true;
            }
            catch (Exception e)
            {

            }


            return resault;
        }

        [WebMethod]
        public static string ProjectGetAll()
        {
            object buffer = null;

            try
            {
                using (DataProjectListDataContext database = new DataProjectListDataContext())
                {
                    IEnumerable<ProjectList> projectCurrent = database.ProjectLists.Where(projectList => projectList.visible == VISIBLE_TRUE);
                    buffer = projectCurrent.ToList();
                }
            }
            catch (Exception e)
            {

            }

            return JsonConvert.SerializeObject(buffer);
        }
        #endregion

        #region Method DashBoard Create
        [WebMethod]
        public static int DashCreate(int dashIdProj, string dashName, string dashInform)
        {
            int dashId = 0;

            try
            {
                using (DataProjectListDataContext database = new DataProjectListDataContext())
                {
                    bool enmtyBoard = database.DashBoardTasks.Any();

                    DashBoardTask board = new DashBoardTask();
                    board.idProj = dashIdProj;
                    board.name = dashName;
                    board.information = dashInform;
                    board.dataCreate = DateTime.Now;

                    if (!enmtyBoard)
                    {
                        board.position = 0;
                    }
                    else
                    {
                        IList<DashBoardTask> dashBoardList = database.DashBoardTasks.Where(dash => dash.idProj == dashIdProj && dash.position.HasValue).ToList();
                        board.position = dashBoardList.Count;
                    }

                    database.DashBoardTasks.InsertOnSubmit(board);
                    database.SubmitChanges();


                    dashId = board.idDash;
                }

            }

            catch (Exception e)
            {

            }

            return dashId;
        }

        [WebMethod]
        public static bool DashUpdate(int dashId, string dashName, string dashInform)
        {
            try
            {
                using (DataProjectListDataContext database = new DataProjectListDataContext())
                {
                    IEnumerable<DashBoardTask> dashBoardList = database.DashBoardTasks.Where(dash => dash.idDash == dashId);

                    foreach (DashBoardTask board in dashBoardList)
                    {
                        board.name = dashName;
                        board.information = dashInform;
                    }

                    database.SubmitChanges();
                }
            }

            catch (Exception e)
            {

            }
            return true;
        }

        [WebMethod]
        public static void DashMove(int dashId, int dashPosition)
        {
            try
            {
                using (DataProjectListDataContext database = new DataProjectListDataContext())
                {
                    IList<DashBoardTask> dashBoardList = database.DashBoardTasks.Where(dash => dash.idDash == dashId && dash.position.HasValue).ToList();
                    DashBoardTask dashBoard = null;

                    foreach (DashBoardTask d in dashBoardList)
                        dashBoard = d;

                    int idProj = 0;

                    if (dashBoard.idProj.HasValue)
                        idProj = dashBoard.idProj.Value;

                    int count = dashBoardList.Count;

                    if (dashPosition == 0)
                    {
                        AllMove(idProj, dashId, dashPosition, database);
                        dashBoard.position = 0;
                        database.SubmitChanges();
                    }
                    else if (dashPosition == count - 1)
                    {
                        AllMove(idProj, dashId, dashPosition, database);
                        dashBoard.position = count - 1;
                        database.SubmitChanges();
                    }
                    else
                    {
                        if (dashPosition > dashBoard.position)
                        {
                            IEnumerable<DashBoardTask> boardList = database.DashBoardTasks.Where(board => board.position > dashBoard.position && board.position <= dashPosition);

                            foreach (DashBoardTask boardTask in boardList)
                                boardTask.position = boardTask.position - 1;
                        }
                        else
                        {
                            IEnumerable<DashBoardTask> boardList = database.DashBoardTasks.Where(board => board.position < dashBoard.position && board.position >= dashPosition);

                            foreach (DashBoardTask boardTask in boardList)
                                boardTask.position = boardTask.position + 1;
                        }

                        dashBoard.position = dashPosition;
                        database.SubmitChanges();
                    }


                }
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        private static void AllMove(int idProj, int dashBoardId, int dashBoardPosition, DataProjectListDataContext database)
        {
            IEnumerable<DashBoardTask> dashBoardList = database.DashBoardTasks.Where(dash => (dash.idProj == idProj && dash.idDash != dashBoardId));

            if (dashBoardPosition == 0)
            {
                foreach (DashBoardTask dashBoard in dashBoardList)
                    dashBoard.position = dashBoard.position + 1;
            }
            else
            {
                foreach (DashBoardTask dashBoard in dashBoardList)
                    dashBoard.position = dashBoard.position - 1;
            }

            database.SubmitChanges();
        }

        #endregion

        [WebMethod]
        public static object TaskGetAll()
        {
            object result = null;
            try
            {
                using (DataProjectListDataContext DCDC = new DataProjectListDataContext())
                {
                    List<TaskProject> Task = DCDC.TaskProjects.Where(t => t.position != null).ToList();
                    result = Task;
                }
            }
            catch
            {
                result = "false";
            }
            return result; // JsonConvert.SerializeObject(
        }
        [WebMethod]
        public static string TaskCreate(string taskIdDash, string taskName, string taskInform, string taskPosition, string taskDataStart, string taskDataEnd)
        {
            Int32 NumberNewTask;
            try
            {
                using (DataProjectListDataContext DCDC = new DataProjectListDataContext())
                {
                    TaskProject NewTask = new TaskProject();
                    NewTask.idDash = Convert.ToInt32(taskIdDash);
                    NewTask.name = taskName;
                    NewTask.information = taskInform;
                    NewTask.position = Convert.ToInt32(taskPosition);
                    NewTask.dataCreate = DateTime.Now;
                    NewTask.dataStart = Convert.ToDateTime(taskDataStart);
                    NewTask.dataEnd = Convert.ToDateTime(taskDataEnd);

                    DCDC.TaskProjects.InsertOnSubmit(NewTask);
                    DCDC.SubmitChanges();

                    NumberNewTask = NewTask.idTask;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return NumberNewTask.ToString();
        }
        [WebMethod]
        public static object DashGetAll(string dashIdProject)
        {
            IEnumerable<DashBoardTask> Dash = null;
            List<DashClass> DashLish = new List<DashClass>();
            using (DataProjectListDataContext DCDC = new DataProjectListDataContext())
            {
                Dash = (from dash in DCDC.DashBoardTasks
                        where dash.idProj == Convert.ToInt32(dashIdProject)
                        select dash).ToList();
                // переробити на чистий LINQ
                // select new {
                //    dash.idDash,
                //    dash.idProj,
                //    dash.name,
                //    dash.information,
                //    dash.dataCreate,
                //    dash.position
                // tasks = from task in DCDC.TaskProjects
                //        where task.idDash == dash.idDash
                //        select new {
                //            task.idTask,
                //            task.idDash,
                //            task.name,
                //            task.information,
                //            task.position,
                //            task.dataCreate,
                //            task.dataStart,
                //            //task.dataEnd,
                //            //Exersice=from exer in DCDC.ExersiceTasks
                //            //         where exer.idTask==task.idTask
                //            //         select exer
                //        }
                //           }

                foreach (DashBoardTask dash_i in Dash)
                {
                    DashClass dashClass_i = new DashClass(dash_i);
                    DashLish.Add(dashClass_i);
                }
            }
            return DashLish;
        }
        //[WebMethod]
        //public static object GetAllDevice()
        //{
        //    object rezult = null;
        //    using (DataClasses2DataContext DCDC = new DataClasses2DataContext())
        //    {
        //        rezult = (from res in DCDC.Devices select res).ToList();
        //    }
        //    return rezult;
        //}
        //[WebMethod]
        //public static string NewDeviceMessage(string ipAdress, string idDevice, string dataError, string error)
        //{
        //    using (DataClasses2DataContext DCDC = new DataClasses2DataContext())
        //    {
        //        DeviceError devError = new DeviceError();
        //        devError.ipAdress = ipAdress;
        //        devError.idDevice = idDevice;
        //        devError.dataError = Convert.ToDateTime(dataError);
        //        devError.error = error;
        //        DCDC.DeviceErrors.InsertOnSubmit(devError);

        //        DCDC.SubmitChanges();

        //        return "ok";
        //    }
        //    return "error";
        //}
    }
}