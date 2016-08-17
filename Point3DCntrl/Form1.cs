using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point3DCntrl
{
    public partial class Form1 : Form
    {

        private GeometryObjects.Point3D Point3D_Val = new GeometryObjects.Point3D();
        PointsProectionsControl Task_PointsProectionsControl = new PointsProectionsControl();
        private TaskEval_Mechanism Task_Mechanism = new TaskEval_Mechanism();

        bool Flag_Testing = false;

        Dictionary<string, object> InitialParams = new Dictionary<string, object>();
        Dictionary<string, object> UserParams = new Dictionary<string, object>();
        Dictionary<string, object> SolveParams = new Dictionary<string, object>();

        Dictionary<string, string> CommentsTrue = new Dictionary<string, string>();
        Dictionary<string, string> CommentsFalse = new Dictionary<string, string>();

        string Object_Comment = "";
        string Object_CommentOut = "";

        bool SolveAsFalse = false;
        bool TaskSolve = false;
        bool TotalSolve = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Dictionary<int, string> myDictionary = new Dictionary<int, string>();

            //foreach (KeyValuePair<int, string> kvp in myDictionary)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            //}
        }
        private void button9_Education_Click(object sender, EventArgs e)
        {
            Flag_Testing = false;
        }

        private void button10_Testing_Click(object sender, EventArgs e)
        {
            Flag_Testing = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Введите координаты 3D точки";
            textBox5_TaskEvalution.Text = "";
        }

        private void button2_Task1_Click(object sender, EventArgs e)
        {//Решение задачи: "Введите координаты 3D точки"
            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputY_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputY_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

            Out: textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }
        }

        private void button6__TaskUsl2_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты горизонтальной проекции точки";
            textBox5_TaskEvalution.Text = "";
        }

        private void button3_Task2_Click(object sender, EventArgs e)
        {//Решение задачи "Задайте координаты горизонтальной проекции точки"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputY_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                { //CommentsFalse.TryGetValue("InputZ_false", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else { TaskSolve = false; CommentsTrue.TryGetValue("InputZ_t_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.PointOfPlan1X0Y_ByXY(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointOfPlan1X0Y_ByXY_f_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan1X0Y_ByXY_f_2", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan1X0Y_ByXY_f_3", out Object_Comment); Object_CommentOut += Object_Comment;
                }

                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputY_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                { //CommentsFalse.TryGetValue("InputZ_false", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else
                {
                    TaskSolve = false; CommentsTrue.TryGetValue("InputZ_t_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    //Object_CommentOut += "Не верно заданы координаты горизонтальной проекции точки";
                    goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.PointOfPlan1X0Y_ByXY(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointOfPlan1X0Y_ByXY_f_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan1X0Y_ByXY_f_2", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan1X0Y_ByXY_f_3", out Object_Comment); Object_CommentOut += Object_Comment;
                    goto Out;
                }
            Out: textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }

            //InitialParams.Clear();
            //UserParams.Clear();
            //SolveParams.Clear();
            //CommentsFalse.Clear();
            //CommentsTrue.Clear();
        }

        private void button7__TaskUsl3_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты фронтальной проекции точки";
            textBox5_TaskEvalution.Text = "";
        }

        private void button4_Task3_Click(object sender, EventArgs e)
        { //Решение задачи "Задайте координаты фронтальной проекции точки"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                { //CommentsFalse.TryGetValue("InputY_false", out Object_Comment);
                  // Object_CommentOut += Object_Comment;
                }
                else { TaskSolve = false; CommentsTrue.TryGetValue("InputY_t_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else
                { //TaskSolve = false; CommentsTrue.TryGetValue("InputZ_true", out Object_Comment);
                  //Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.PointOfPlan2X0Z_ByXZ(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_2", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_3", out Object_Comment); Object_CommentOut += Object_Comment;
                }

                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                { //CommentsFalse.TryGetValue("InputY_false", out Object_Comment);
                  // Object_CommentOut += Object_Comment;  goto Out;
                }
                else { TaskSolve = false; CommentsTrue.TryGetValue("InputY_t_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputZ_t_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    //Object_CommentOut += "Не верно заданы координаты горизонтальной проекции точки";
                    //goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; goto Out; }

                TaskSolve = Task_PointsProectionsControl.PointOfPlan2X0Z_ByXZ(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_2", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_3", out Object_Comment); Object_CommentOut += Object_Comment;
                    goto Out;
                }
            Out: textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }

            //InitialParams.Clear();
            //UserParams.Clear();
            //SolveParams.Clear();
            //CommentsFalse.Clear();
            //CommentsTrue.Clear();
        }

        private void button8__TaskUsl4_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты профильной проекции точки";
            textBox5_TaskEvalution.Text = "";
        }

        private void button5_Task4_Click(object sender, EventArgs e)
        { //Решение задачи "Задайте координаты профильной проекции точки"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                }
                else
                {
                    TaskSolve = false; CommentsTrue.TryGetValue("InputX_t_1", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputY_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputY_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputZ_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                TaskSolve = Task_PointsProectionsControl.PointOfPlan3Y0Z_ByYZ(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_2", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_3", out Object_Comment); Object_CommentOut += Object_Comment;
                }

                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment; goto Out;
                }
                else
                {
                    TaskSolve = false; CommentsTrue.TryGetValue("InputX_t_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputY_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputY_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment; goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputZ_t_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    //Object_CommentOut += "Не верно заданы координаты горизонтальной проекции точки";
                    //goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.PointOfPlan3Y0Z_ByYZ(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_2", out Object_Comment); Object_CommentOut += Object_Comment;
                    CommentsFalse.TryGetValue("PointOfPlan2X0Z_ByXZ_f_3", out Object_Comment); Object_CommentOut += Object_Comment;
                    goto Out;
                }
            Out: textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }
        }

        private void button9__TaskUsl5_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты 3D точки общего положения";
            textBox5_TaskEvalution.Text = "";
        }

        private void button12_Task5_Click(object sender, EventArgs e)
        { //Решение задачи "Задайте координаты 3D точки общего положения"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputX_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputY_false", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputY_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputZ_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false) { CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment); Object_CommentOut += Object_Comment; }

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("Point3D_OfPlan1X0Y_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //CommentsFalse.TryGetValue("Point3D_OfPlan1X0Y_f_2", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    TaskSolve = true;
                }
                else
                {
                    TaskSolve = false;
                    //CommentsTrue.TryGetValue("Point3D_OfPlan1X0Y_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    CommentsTrue.TryGetValue("Point3D_OfPlan1X0Y_t_2", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("Point3D_OfPlan2X0Z_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //CommentsFalse.TryGetValue("Point3D_OfPlan2X0Z_f_2", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    TaskSolve = true;
                }
                else
                {
                    TaskSolve = false;
                    //CommentsTrue.TryGetValue("Point3D_OfPlan2X0Z_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    CommentsTrue.TryGetValue("Point3D_OfPlan2X0Z_t_2", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("Point3D_OfPlan3Y0Z_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //CommentsFalse.TryGetValue("Point3D_OfPlan3Y0Z_f_2", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    TaskSolve = true;
                }
                else
                {
                    TaskSolve = false;
                    //CommentsTrue.TryGetValue("Point3D_OfPlan3Y0Z_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    CommentsTrue.TryGetValue("Point3D_OfPlan3Y0Z_t_2", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                }
                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputX_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputX_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment; goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputY_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputY_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment; goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("InputZ_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }
                else
                {
                    //TaskSolve = false; CommentsTrue.TryGetValue("InputZ_t_1", out Object_Comment); Object_CommentOut += Object_Comment;
                    //Object_CommentOut += "Не верно заданы координаты горизонтальной проекции точки";
                    //goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    CommentsFalse.TryGetValue("PointMinus_f_1", out Object_Comment);
                    Object_CommentOut += Object_Comment; goto Out;
                }

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("Point3D_OfPlan1X0Y_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //CommentsFalse.TryGetValue("Point3D_OfPlan1X0Y_f_2", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    TaskSolve = true;
                }
                else
                {
                    TaskSolve = false;
                    //CommentsTrue.TryGetValue("Point3D_OfPlan1X0Y_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    CommentsTrue.TryGetValue("Point3D_OfPlan1X0Y_t_2", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                    goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("Point3D_OfPlan2X0Z_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //CommentsFalse.TryGetValue("Point3D_OfPlan2X0Z_f_2", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    TaskSolve = true;
                }
                else
                {
                    TaskSolve = false;
                    //CommentsTrue.TryGetValue("Point3D_OfPlan2X0Z_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    CommentsTrue.TryGetValue("Point3D_OfPlan2X0Z_t_2", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                    goto Out;
                }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                if (TaskSolve == false)
                {
                    //CommentsFalse.TryGetValue("Point3D_OfPlan3Y0Z_f_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //CommentsFalse.TryGetValue("Point3D_OfPlan3Y0Z_f_2", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    TaskSolve = true;
                }
                else
                {
                    TaskSolve = false;
                    //CommentsTrue.TryGetValue("Point3D_OfPlan3Y0Z_t_1", out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    CommentsTrue.TryGetValue("Point3D_OfPlan3Y0Z_t_2", out Object_Comment);
                    Object_CommentOut += Object_Comment;
                    goto Out;
                }

            Out: textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TaskSolve);
            }

        }

        private void button10__TaskUsl6_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты 3D точки, принадлежащей только горизонтальной плоскости проекций";
            textBox5_TaskEvalution.Text = "";
        }

        private void button13_Task6_Click(object sender, EventArgs e)
        {
            //Решение задачи "Задайте координаты 3D точки, принадлежащей только горизонтальной плоскости проекций"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            List<string> CommentsNames = new List<string>();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;
            TotalSolve = true;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TotalSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }
            }

        Out: textBox5_TaskEvalution.Text = Object_CommentOut;

            label6_Evalution.Text = Convert.ToString(TotalSolve);
        }

        private void button11__TaskUsl7_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты 3D точки, принадлежащей только фронтальной плоскости проекций";
            textBox5_TaskEvalution.Text = "";
        }

        private void button14_Task7_Click(object sender, EventArgs e)
        {
            //Решение задачи "Задайте координаты 3D точки, принадлежащей только фронтальной плоскости проекций"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            List<string> CommentsNames = new List<string>();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;
            TotalSolve = true;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_t_2");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TotalSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_t_2");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, false, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, true, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }
            }

        Out: textBox5_TaskEvalution.Text = Object_CommentOut;

            label6_Evalution.Text = Convert.ToString(TotalSolve);
        }

        private void button15_TaskUsl8_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты 3D точки, принадлежащей только профильной плоскости проекций";
            textBox5_TaskEvalution.Text = "";
        }

        private void button23_Task8_Click(object sender, EventArgs e)
        {
            //Решение задачи "Задайте координаты 3D точки, принадлежащей только профильной плоскости проекций"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            List<string> CommentsNames = new List<string>();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;
            TotalSolve = true;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                //if (TotalSolve == true)//Контроль на каждом шаге правильности решения: если хоть на одном шаге решение неверно, то общее решение всегда должно быть "false".
                //{
                //    if (TaskSolve == false) { TotalSolve = false; }
                //    //if ((SolveAsFalse == false & TaskSolve == false) | (SolveAsFalse == true & TaskSolve == true))
                //    //{ TotalSolve = false; }
                //}

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
               
                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                
                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
               
                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = true;
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_t_2");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
               
                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = true;
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_f_1");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
              
                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_f_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
              
                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TotalSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = true;
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_t_2");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve,  CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = true;
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_f_1");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames,  ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams,   ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_f_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames,  ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }
            }

        Out: textBox5_TaskEvalution.Text = Object_CommentOut;

            label6_Evalution.Text = Convert.ToString(TotalSolve);
        }

        private void button16_TaskUsl9_Click(object sender, EventArgs e)
        {
            textBox4_TaskDescription.Text = "Задайте координаты 3D точки, принадлежащей оси OX";
            textBox5_TaskEvalution.Text = "";
        }

        private void button24_Task9_Click(object sender, EventArgs e)
        {
            //Решение задачи "Задайте координаты 3D точки, принадлежащей оси OX"

            InitialParams.Clear(); UserParams.Clear(); SolveParams.Clear();
            CommentsFalse.Clear(); CommentsTrue.Clear();
            List<string> CommentsNames = new List<string>();
            Object_CommentOut = ""; Object_Comment = "";

            TaskSolve = false;
            TotalSolve = true;

            UserParams.Add("X", textBox_X.Text); UserParams.Add("Y", textBox_Y.Text); UserParams.Add("Z", textBox_Z.Text);
            textBox5_TaskEvalution.Text = "";

            if (Flag_Testing)
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
              
                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_1");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_2");
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = true;
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_f_1");
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();

                textBox5_TaskEvalution.Text = Object_CommentOut;

                label6_Evalution.Text = Convert.ToString(TotalSolve);
            }
            else
            {
                TaskSolve = Task_PointsProectionsControl.Input_X(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputX_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Y(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("InputY_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Input_Z(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                CommentsNames.Add("InputZ_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.PointMinus(InitialParams, UserParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                CommentsNames.Add("PointMinus_f_1");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                // !!! Здесь надо из SolveParams добавить объект "Point3D" в UserParams.

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan1X0Y(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_1");
                //CommentsNames.Add("Point3D_OfPlan1X0Y_t_2");
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_1");
                CommentsNames.Add("Point3D_OfPlan1X0Y_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan2X0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = false;
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_1");
                //CommentsNames.Add("Point3D_OfPlan2X0Z_t_2");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_1");
                CommentsNames.Add("Point3D_OfPlan2X0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }

                TaskSolve = Task_PointsProectionsControl.Point3D_OfPlan3Y0Z(InitialParams, SolveParams, ref SolveParams, ref CommentsTrue, ref CommentsFalse);
                SolveAsFalse = true;
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_t_1");
                CommentsNames.Add("Point3D_OfPlan3Y0Z_t_2");
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_f_1");
                //CommentsNames.Add("Point3D_OfPlan3Y0Z_f_2");
                Task_Mechanism.Solve_TrueOrFalse(ref TaskSolve, SolveAsFalse, ref TotalSolve, CommentsNames, ref CommentsTrue, ref CommentsFalse, ref Object_CommentOut);
                CommentsNames.Clear();
                if (TaskSolve == false)
                { goto Out; }
            }

        Out: textBox5_TaskEvalution.Text = Object_CommentOut;

            label6_Evalution.Text = Convert.ToString(TotalSolve);

        }
    }
}

//1. Просмотреть код с начиная с первой задачи до последней.
//2. Переделать все задачи (кроме предпоследней и последней) по примеру последней.
//3. Реализовать задачи: 4. "Задайте координаты горизонтальной и фронтальной проекций 3D точки"; 5. "Задайте координаты горизонтальной и профильной проекций 3D точки"; 6. "Задайте координаты фронтальной и профильной проекций 3D точки";
//                       8. "Задайте 3D точку общего положения с помощью 3-х проекций" (см. файл "TaskAsObject_V5_1008'16.docx"). Для этого необходимо добавить TextBox-ы для трех проекций или ЛУЧШЕ реализовать задание координат в ОДНОМ TextBox-е с указанием ИМЕН проекций.
//4. По аналогии с последней задачей реализовать задачи: "Задайте координаты 3D точки, принадлежащей оси OY" и "Задайте координаты 3D точки, принадлежащей оси OZ".
//5. Выполнить указания, записанные в конце класса PointsProectionsControl.
//6. Хорошо бы сделать автоматическое отключение и включение комментирования "..._f_1..." и "..._t_1..." при установке значения SolveAsFalse.
//7. Перед каждым шагом надо сделать механизм перетусовки данных (при необходиимости) из одного словаря в другой и реализоывавть его в виде метода в классе TaskEval_Mechanism.
//8. Перед каждым шагом надо сделать механизм формирования различных экземпляров классов.
//9. Закодировать все (базовые и основные) алгоритмы для возможности формирования списков алгоритмов, требуемых для решения производных задач.
//10. Для вывода комментариев реализовать механизм вкл/отк требуемых комментариев, т.к. в различных ситуациях не всегда нужен вывод полного списка всех комментариев.
//11. Вывод комментариев реализовать на форме в виде двух списков - один для "true", второй - для "false".
//12. Выполнить механизм формирования производных задач путем формирования списков необходимых алгоритмов и их запуска в требуемом порядке на основе оператора "Case".
//13. Реализовать задачи по графическим построениям с использованием графического редактора: задачи 12-23 с заданием "Постройте..." (см. файл "TaskAsObject_V5_1008'16.docx").
//14. Выполнить рефакторинг кода алгоритмов решения задач.
//15. Реализовать невозможность проверки задачи без предварительного задания условия (выбора задачи), т.е., например, погасить кнопку "Проверить".