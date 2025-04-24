public class Subject{
    

    public string subject_name;
    public string teacher_name;

    //For subject information
    public int subject_units;
    public string subject_ID;
    public string subject_type;

    //For timeslot determination
    public int subject_hours_start;
    public int subject_hours_end;
    public string subject_days;



    // //Remove multi-line comment to use
    // //Subject constructor for each subject/course to be addedd
    public Subject(string subject_name, string teacher_name, 
                   int subject_units, string subject_ID, string subject_type,
                   int subject_hours_start, int subject_hours_end, string subject_timeslot_days){

        this.subject_name = subject_name;
        this.teacher_name = teacher_name;
        this.subject_units = subject_units;
        this.subject_ID = subject_ID;
        this.subject_type = subject_type;
        this.subject_hours_start = subject_hours_start;
        this.subject_hours_end = subject_hours_end;
        this.subject_days = subject_timeslot_days;

    }
    

    //Simple test for referencing subject lists for teachers
    // public Subject(string subject_name){

    //     this.subject_name = subject_name;
 
    // }

}