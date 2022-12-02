using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_HW
{
    

    internal class Program
    {
        static void Begin()
        {
            Iniciator Chetrilla = new Iniciator("Тарас");
            Project project = new Project();
            


            Timlid tim = new Timlid("Олег");



            //Исполнители
            Executor Lesha = new Executor("Лёша");
            Executor Oleg = new Executor("Олег");
            Executor Dina = new Executor("Дина");
            Executor Daniil = new Executor("Данёк");
            Executor Vitaliy = new Executor("Виталий");
            Executor Nikita = new Executor("Никита");
            Executor Maksim = new Executor("Максим");//10
            Executor Tumakokokov = new Executor("Нудный чел");
            Executor Sidorov = new Executor("Умный чел");
            Executor Garnik = new Executor("Гарник");

            //Задачи
            Task Task1 = new Task("пробник", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task2 = new Task("Coздай дизайн", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task3 = new Task("Поработай над концепцией", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task4 = new Task("Сделай базу клиентов", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task5 = new Task("Создание кнопок", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task6 = new Task("Маркетинговые ходы", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task7 = new Task("Отслежывание желаний рынка", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task8 = new Task("Сделай вид, что работаешь", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task9 = new Task("Объясни заказчику, что мы не успеваем", new DateTime(2022, 12, 12), (Task_Status)0);
            Task Task10 = new Task("Купи все энергетики, весь кофе и кофеин из аптеки", new DateTime(2022, 12, 12), (Task_Status)0);

            List<Task> TaskList = new List<Task>();
            TaskList.Add(Task1);
            TaskList.Add(Task2);
            TaskList.Add(Task3);
            TaskList.Add(Task4);
            TaskList.Add(Task5);
            TaskList.Add(Task6);
            TaskList.Add(Task7);
            TaskList.Add(Task8);
            TaskList.Add(Task9);
            TaskList.Add(Task10);
            project.project(new DateTime(2022, 12, 30), TaskList, Chetrilla.Creat_Project(), tim, Chetrilla);

            tim.GiveTask(Lesha, Oleg, Task1);
            tim.GiveTask(Oleg, Dina, Task2);
            tim.GiveTask(Dina, Daniil, Task3);
            tim.GiveTask(Daniil, Vitaliy, Task4);
            tim.GiveTask(Vitaliy, Nikita, Task5);
            tim.GiveTask(Nikita, Maksim, Task6);
            tim.GiveTask(Maksim, Tumakokokov, Task7);
            tim.GiveTask(Tumakokokov, Sidorov, Task8);
            tim.GiveTask(Sidorov, Garnik, Task9);
            tim.GiveTask(Garnik, Lesha, Task10);
            project.End();

        }
        static void Main(string[] args)
        {
            
            
            

            Begin();
            Console.ReadKey();
        }
    }
}
