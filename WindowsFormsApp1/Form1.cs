using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Users> user = new List<Users>();
        List<Departament> departaments = new List<Departament>();
        List<Employ> employes = new List<Employ>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user.Add (new Users { Name = "Иванов Сергей Николаевич ", Age = 21, Ves = 64 });
            user.Add (new Users { Name = "Петров Игорь Юрьевич", Age = 45, Ves = 88 });
            user.Add (new Users { Name = "Семёнов Михаил Алексеевич", Age = 20, Ves = 70 });
            user.Add (new Users{ Name = "Пиманов Александр Дмитриевич", Age = 53, Ves = 101 });
            foreach (Users person in user)
            {
                if (person.Age < 40)
                {
                    listBox1.Items.Add(person.Name + " - " + person.Age.ToString() + " лет");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            departaments.Add(new Departament { name = "Отдел закупок", reg = "Германия" });
            departaments.Add(new Departament { name = "Отдел продаж", reg = "Испания" });
            departaments.Add(new Departament { name = "Отдел маркетинга", reg = "Испания" });
            employes.Add(new Employ { name = "Иванов", departament = "Отдел закупок" });
            employes.Add(new Employ { name = "Петров", departament = "Отдел закупок" });
            employes.Add(new Employ { name = "Сидоров", departament = "Отдел продаж" });
            employes.Add(new Employ { name = "Лямин", departament = "Отдел продаж" });
            employes.Add(new Employ { name = "Сидоренко", departament = "Отдел маркетинга" });
            employes.Add(new Employ { name = "Кривоносов", departament = "Отдел продаж" });
            var result = from dp in employes join n in departaments on dp.departament equals n.name select new { Name = dp.name, Departament = dp.departament, Reg = n.reg };
            foreach (var item in result)
            {
                listBox2.Items.Add(item.Name + " " + item.Departament + " " + item.Reg);
            }

            foreach (var t in departaments.TakeWhile(x => x.name.StartsWith("И")))
            {
                listBox3.Items.Add("Сотрудники, чей регион начинается на 'И':");
                listBox3.Items.Add(t.name + " " + t.reg);
            }

        }
    }
}
