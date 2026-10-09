using System;
using System.Data;

class Program
{
    static void Main()
    {
        DataSet ds = new DataSet("University");

        DataTable groups = new DataTable("Groups");
        groups.Columns.Add("GroupId", typeof(int));
        groups.Columns.Add("GroupName", typeof(string));
        groups.PrimaryKey = new DataColumn[] { groups.Columns["GroupId"] };

        DataTable students = new DataTable("Students");
        students.Columns.Add("StudentId", typeof(int));
        students.Columns.Add("Name", typeof(string));
        students.Columns.Add("Age", typeof(int));
        students.Columns.Add("GroupId", typeof(int));
        students.PrimaryKey = new DataColumn[] { students.Columns["StudentId"] };

        ds.Tables.Add(groups);
        ds.Tables.Add(students);

        groups.Rows.Add(1, "ПИ-21");
        groups.Rows.Add(2, "ПИ-22");
        groups.Rows.Add(3, "ПИ-23");

        students.Rows.Add(1, "Иван", 20, 1);
        students.Rows.Add(2, "Мария", 22, 1);
        students.Rows.Add(3, "Алексей", 19, 2);
        students.Rows.Add(4, "Ольга", 23, 2);
        students.Rows.Add(5, "Дмитрий", 21, 3);
        students.Rows.Add(6, "Анна", 20, 1);
        students.Rows.Add(7, "Сергей", 22, 2);
        students.Rows.Add(8, "Елена", 19, 3);
        students.Rows.Add(9, "Павел", 21, 3);
        students.Rows.Add(10, "Татьяна", 23, 1);

        DataRelation relation = new DataRelation("GroupStudents",
            groups.Columns["GroupId"],
            students.Columns["GroupId"]);

        ds.Relations.Add(relation);

        string selectedGroup = "ПИ-21";

        DataRow groupRow = null;
        foreach (DataRow row in groups.Rows)
        {
            if ((string)row["GroupName"] == selectedGroup)
            {
                groupRow = row;
                break;
            }
        }

        if (groupRow != null)
        {
            Console.WriteLine("Студенты группы " + selectedGroup + ":");
            foreach (DataRow student in groupRow.GetChildRows(relation))
            {
                Console.WriteLine(student["StudentId"] + "\t" + student["Name"] + "\t" + student["Age"]);
            }
        }
    }
}