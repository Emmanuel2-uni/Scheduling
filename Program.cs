using System.Collections;
using System.Collections.Generic;

// Initializers for needed objects
Subject_List subjects = new Subject_List();
//Teacher_List teachers = new Teacher_List();
List<Teacher> teachers = new List<Teacher>();

System.Console.WriteLine("Hello, Worl1112d"); //Mandatory test for every project


//Tests
subjects.add_subject("asd", "none", 0, "A", "A", 0, 0, "none");
subjects.add_subject("asd2", "none", 0, "A", "A", 0, 0, "none");


//First year 1st sem GE
subjects.add_subject("The Family", "Juan GE", 3, "CS1GE01", "A", 700, 800, "MWF");
subjects.add_subject("English 1", "Maria GE", 3, "CS1GE02", "A", 700, 830, "TTh");
subjects.add_subject("Speech", "Maria GE", 3, "CS1GE03", "A", 900, 1000, "MWF");

//First year 2nd sem GE
// subjects.add_subject("University and I", "Thomas GE", 3, "CS2GE01", "A", 700, 800, "MWF");
// subjects.add_subject("Ethics", "Bob GE", 3, "CS2GE02", "A", 1100, 1200, "MWF");
// subjects.add_subject("Understanding the Self", "Bob GE", 3, "CS2GE03", "A", 1200, 1330, "TTH");
// subjects.add_subject("Filipino", "Thomas GE", 3, "CS2GE03", "A", 800, 930, "TTH");

//// ----Display Subjects
//subjects.display_subjects();

//Teacher test
// Quick thoughts: As long as the subject belongs to a specific curriculum, no conflict should arise or be detected.
// -- Very important to check for duplicate teachers within subjects
teachers.Add(new Teacher("Juan GE", new List<string>{"The Family"}));
teachers.Add(new Teacher("Bob GE", new List<string>{"Understanding the Self", "Ethics"}));
teachers.Add(new Teacher("Maria GE", new List<string>{"English 1", "Speech"}));
teachers.Add(new Teacher("Thomas GE", new List<string>{"University and I", "Filipino"}));

teachers.Add(new Teacher("Gavin CS", new List<string>{"Computer Programming 1", "Computer Programming 2"}));
teachers.Add(new Teacher("Harry CS", new List<string>{"Introduction to Computing", "Discrete Structures 1"}));
teachers.Add(new Teacher("Cathy CS", new List<string>{"IT Era"}));


// teachers.add_name("Juan GE", new List<string>{"The Family"});
// teachers.add_name("Bob GE", new List<string>{"Understanding the Self", "Ethics"});
// teachers.add_name("Maria GE", new List<string>{"English 1", "Speech"});
// teachers.add_name("Thomas GE", new List<string>{"University and I", "Filipino"});

// teachers.add_name("Gavin CS", new List<string>{"Computer Programming 1", "Computer Programming 2"});
// teachers.add_name("Harry CS", new List<string>{"Introduction to Computing", "Discrete Structures 1"});
// teachers.add_name("Cathy CS", new List<string>{"IT Era"});
//// ----Display Teachers
//teachers.display_teachers();
foreach(Teacher teacher in teachers){
    Console.Write($"{teacher.name} ");
    foreach(string subject in teacher.subjects){
        Console.Write($"{subject} ");
    }
}



//Conflict Test
if(subjects.detect_conflict(new Subject("AAA TEST", "Juan GE", 3, "AAA", "A", 700, 800, "MWF"))){
    Console.WriteLine("Conflict!!!!!");
}

subjects.display_subjects();

subjects.generate_schedule("Computer Programming 1", 3, teachers);
subjects.generate_schedule("Introduction to Computing", 3, teachers);
//subjects.generate_schedule("IT Era", 3, teachers);

Console.WriteLine("\n\n");
subjects.display_subjects();
