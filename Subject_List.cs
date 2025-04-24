using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Linq;

public class Subject_List{
    //private List<Contact> contacts;

    private List<Subject> subjects;
    public List<Existing_Schedule>? current_schedules;
    public List<Existing_Schedule>? open_schedules;
    public List<Existing_Schedule>? open_odd_schedules;

    public Subject_List(){
        subjects = new List<Subject>();
    }


    // Public Subject(string subject_name, string teacher_name, 
    //                int subject_units, string subject_ID, string subject_type,
    //                int subject_timeslot_hours, string subject_timeslot_days){

    public void add_subject(string name, string teacher, 
                        int units, string ID, string type,
                        int hours_start, int hours_end, string days){
                            
        subjects.Add(new Subject(name, teacher, units, ID, type, hours_start, hours_end, days));

    }
    
    public void plus_subject(string name){
    }

    public void display_subjects(){
        for(int i = 0; i < subjects.Count; i++){
            System.Console.WriteLine($"{subjects[i].subject_name} == \t\t | {subjects[i].teacher_name} | {subjects[i].subject_units} | {subjects[i].subject_ID} | {subjects[i].subject_type} | {subjects[i].subject_hours_start} -- {subjects[i].subject_hours_end} | {subjects[i].subject_days}");
        }
    }

    //Conflict Detector test
    //Checks if a subject exists in those hour slots and day slots
    public bool detect_conflict(Subject this_subject){
        foreach(Subject course in subjects){
            if(course.subject_days == this_subject.subject_days && course.subject_hours_start == this_subject.subject_hours_start 
            && course.subject_hours_end == this_subject.subject_hours_end && course.teacher_name == this_subject.teacher_name){
                Console.WriteLine($"!! Conflict Detected between {course.subject_name} and {this_subject.subject_name} !!");

                return true;
            }
        }
        return false;
    }


    //GENERATE SCHEDULE FOR SUBJECT
    public void generate_schedule(string subject_name, int units, params List<Teacher> teachers){
        current_schedules = new List<Existing_Schedule>();
        open_schedules = new List<Existing_Schedule>();
        open_odd_schedules = new List<Existing_Schedule>();
        
        //initialize open_schedules MWF;
        for(int time = 700; time < 1300; time+=100){
            open_schedules.Add(new Existing_Schedule(time, time+100, "MWF"));
        }

        //initialize open_schedules TTh;
        for(int time = 700; time < 1300; time+=150){
            int true_time = 0;
            if(time%100 != 0){
                true_time = time - 20;
                open_odd_schedules.Add(new Existing_Schedule(true_time, time+150, "TTh"));
            }else{
                true_time = time;
                open_odd_schedules.Add(new Existing_Schedule(true_time, time+130, "TTh"));
            }
            //open_schedules.Add(new Existing_Schedule(true_time, time+130, "TTh"));
        }

        //Display
        Console.WriteLine("Open");
        foreach(Existing_Schedule schedule in open_schedules){
            Console.WriteLine($"{schedule.days} | {schedule.schedule_start} -- {schedule.schedule_end}");
        }
        
        foreach(Subject course in subjects){   
            if(course.subject_days == "MWF"){
                current_schedules.Add(new Existing_Schedule(course.subject_hours_start, course.subject_hours_end, course.subject_days));
            }
        }
        foreach(Subject course in subjects){   
            if(course.subject_days == "TTh"){
                current_schedules.Add(new Existing_Schedule(course.subject_hours_start, course.subject_hours_end, course.subject_days));
            }
        }

        //Remove from open schedules the existing schedules
        foreach(Existing_Schedule schedule in current_schedules){
            foreach(Existing_Schedule open_sched in open_schedules){
                if( schedule.schedule_start == open_sched.schedule_start && schedule.schedule_end == open_sched.schedule_end){
                    //Console.Write("Test");
                    open_schedules.Remove(open_sched);
                    break; //IMPORTANT TO RESET THE ITERATOR INSIDE THE FOREACH
                }
            }
            foreach(Existing_Schedule open_sched in open_odd_schedules){
                if( schedule.schedule_start == open_sched.schedule_start && schedule.schedule_end == open_sched.schedule_end){
                    //Console.Write("Test");
                    open_odd_schedules.Remove(open_sched);
                    break; //IMPORTANT TO RESET THE ITERATOR INSIDE THE FOREACH
                }
            }
        }

    
        Console.WriteLine("Open After");
        foreach(Existing_Schedule schedule in open_schedules){
            Console.WriteLine($"{schedule.days} | {schedule.schedule_start} -- {schedule.schedule_end}");
        }
        //Now that Schedule pruning is done, and that we've determined the open slots,
        // We move on to adding the subject
        int flag = 0;
        
        foreach(Teacher teacher in teachers){
            foreach(string subject in teacher.subjects){
                if(subject == subject_name && open_schedules.Count < 3){
                    add_subject(subject_name, teacher.name, units, "CS1AAA", "A", open_schedules[0].schedule_start, open_schedules[0].schedule_end, "MWF");
                    open_schedules.RemoveAt(0);
                    flag = 1;
                    break;
                }else if(subject == subject_name){
                    add_subject(subject_name, teacher.name, units, "CS1AAA", "A", open_odd_schedules[0].schedule_start, open_odd_schedules[0].schedule_end, "TTh");
                    open_odd_schedules.RemoveAt(0);
                }
            }
            if(flag == 1){
                break;
            }
        }




        Console.WriteLine("Open After Adding");
        foreach(Existing_Schedule schedule in open_schedules){
            Console.WriteLine($"{schedule.days} | {schedule.schedule_start} -- {schedule.schedule_end}");
        }

        Console.WriteLine("Existing");
        foreach(Existing_Schedule schedule in current_schedules){
            Console.WriteLine($"{schedule.days} | {schedule.schedule_start} -- {schedule.schedule_end}");
        }
        

    }
}