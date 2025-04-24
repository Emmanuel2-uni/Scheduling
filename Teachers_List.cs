using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Linq;

public class Teacher_List{
    //private List<Contact> contacts;

    private List<Teacher> teachers;


    public Teacher_List(){
        teachers = new List<Teacher>();
    }


    public void add_name(string name, List<string> this_subjects){
        teachers.Add(new Teacher(name, this_subjects));

    }

    public void display_teachers(){
        for(int i = 0; i < teachers.Count; i++){
            System.Console.Write($"{teachers[i].name} == \t| ");
            foreach(string subject in teachers[i].subjects){
                System.Console.Write($"{subject} | ");
            }
            System.Console.WriteLine("");
        }

    }

}