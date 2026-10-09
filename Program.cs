using System;
using System.Data;

class Program
{
    static void Main()
    {
        DataTable table = new DataTable("Students");

        table.Columns.Add("id", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Age", typeof(int));
        table.Columns.Add("GroupName", typeof(string));

        table.Rows.Add(1, "Иван", 20, "ПИ-21");
        table.Rows.Add(2, "Мария", 22, "ПИ-21");
        table.Rows.Add(3, "Алексей", 19, "ПИ-22");
        table.Rows.Add(4, "Ольга", 23, "ПИ-22");
        table.Rows.Add(5, "Дмитрий", 21, "ПИ-23");

        Console.WriteLine("id\tName\tAge\tGroupName");
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine(row["id"] + "\t" + row["Name"] + "\t" + row["Age"] + "\t" + row["GroupName"]);
        }

        DataRow oldest = table.Rows[0];
        for (int i = 1; i < table.Rows.Count; i++)
        {
            if ((int)table.Rows[i]["Age"] > (int)oldest["Age"])
            {
                oldest = table.Rows[i];
            }
        }

        Console.WriteLine();
        Console.WriteLine("Самый старший студент: " + oldest["Name"] + ", возраст: " + oldest["Age"]);
    }
}