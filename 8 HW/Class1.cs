using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_HW
{
    public class Rand
    {
        public int rand()
        {
            var r = new Random();
            int num = r.Next(0, 3);
            return num;
        }
    }
    public enum Project_Status
    {
        Proekt = 0,
        Execution,
        Close
    }
    public enum Task_Status
    {
        Appointed = 0,//Назначена
        In_work,
        On_the_check,
        Completed//Выполнена
    }
    class Task
    {

        public string description { get; set; }//Описание
        public DateTime terms { get; set; }
        public Task_Status status { get; set; }
        public Report report { get; set; }
        public Task(string descripnion, DateTime terms, Task_Status task_Status)// надо спросить правильно ли я работаю с перечислением
        {
            description = descripnion;
            this.terms = terms;
            this.status = task_Status;
        }
        public void Print()
        {
            Console.WriteLine($"{description}, {terms}, {status}");
        }

    }
    class Timlid
    {
        public string name { get; set; }
        public Timlid(string name)
        {
            this.name = name;
        }

        public void GiveTask(Executor executor1, Executor executor2, Task problem)
        {
            Rand rand = new Rand();
            int num = rand.rand();

            //var r = new Random();
            //int num = r.Next(0, 3);
            if (num == 0)
            {
                Console.WriteLine($"{executor1.name} берет задачу: {problem.description}");
                Report report = executor1.TaskWork(problem);
                DidTask(report, CheckReport(report));


                return;

            }
            else if (num == 1)
            {
                Console.WriteLine($"{executor1.name} НЕ берет задачу: {problem.description}");
                executor1 = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                return;

            }
            else
            {
                Console.WriteLine($"{executor1.name} делегирует задачу \"{problem.description}\" {executor2.name}");
                Report report = executor1.TaskWork(problem);
                DidTask(report, CheckReport(report));
                return;
            }
            rand = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public bool CheckReport(Report report)
        {
            report.task.status = (Task_Status)2;
            Console.WriteLine($"{report.task.description}: на проверке - {report.task.status}");
            string desc = report.text;
            Rand rand = new Rand();
            int r = rand.rand();

            Console.WriteLine(r);
            if (r == 0)
            {
                Console.WriteLine("Переделывай");
                return false;

            }
            else
            {
                Console.WriteLine("Всё чётко");
                return true;
            }
            rand = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        public bool AfterCheking(Report report)
        {
            report.task.status = (Task_Status)1;
            Console.WriteLine("Переделал");
            report.text = report.text + " переделанный";
            report.task.status = (Task_Status)2;
            return true;
        }
        public void DidTask(Report report, bool a)
        {
            if (a == true)
            {
                report.task.status = (Task_Status)3;
                Console.WriteLine($"Задание: {report.task.description}  Завершено - {report.task.status}");
            }
            else
            {

                if (AfterCheking(report) == true)
                {
                    report.task.status = (Task_Status)3;
                    Console.WriteLine($"Задание Завершено - {report.task.status}");
                }
            }
        }

    }
    class Executor//Исполнитель
    {
        public string name { get; set; }
        public Executor(string name)
        {
            this.name = name;
        }
        public Report TaskWork(Task task)
        {
            task.status = (Task_Status)1;
            Console.WriteLine($"Сделано - {task.description}, отправляю отчёт");
            Report report = new Report(task.description, task.terms, name, task);

            return report;
        }
    }
    class Report
    {
        public string text { get; set; }
        public DateTime time { get; set; }
        public string executor { get; set; }
        public Task task { get; set; }

        internal Report(string text, DateTime time, string executor, Task task)
        {
            this.executor = executor;
            this.text = text;
            this.time = time;
            this.task = task;
        }

    }
    class Project
    {
        public DateTime terms { get; set; }
        public Project_Status status { get; set; }
        public List<Task> zadacha = new List<Task>() { };// решить проблему, если задач будет много
        public string description { get; set; }//описание
        public Timlid timlid { get; set; }
        public Iniciator iniciator { get; set; }
        public Project()
        {
            status = (Project_Status)0;
        }
        public void project(DateTime time, List<Task> list, string opisanie, Timlid timlid, Iniciator iniciator)
        {
            this.terms = time;
            this.zadacha = list;
            this.iniciator = iniciator;
            this.description = opisanie;
            this.timlid = timlid;
            status = (Project_Status)1;
        }
        public void End()
        {
            byte cnt = 0;
            foreach (Task t in zadacha)
            {
                if (t.status == (Task_Status)3 || t == null)
                {
                    cnt++;
                }
            }
            if (cnt == zadacha.Count())
            {
                Console.WriteLine("\nПроект закончился, мне всё понравилось".ToUpper());
            }
        }


    }
    class Iniciator
    {
        string name;
        public Iniciator(string name)
        {
            this.name = name;
        }
        public string Creat_Project()
        {
            string opisan = "Хочу крутой сайт, чтобы рубить деньги";
            return opisan;
        }
    }
}
