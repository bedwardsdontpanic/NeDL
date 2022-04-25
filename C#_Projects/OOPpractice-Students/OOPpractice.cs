#pragma warning disable 8604, 8600
using System;

namespace HelloWorld {
    class Program {
        static void Main(string[] args) { 

            List<Student> StudentList = new List<Student>();
            Student Ben = createNewStudent();
            Student x = new Student("x", 54321, 50, 50, 101);
            StudentList.Add(Ben);
            StudentList.Add(x);

            StudentList = sortStudents("Exams", StudentList);
            printStudents(StudentList);
        }

        public static Student createNewStudent(){
            Student Ben = new Student("Ben", 12345, 80, 90, 100);
            return Ben;
        }

        public static List<Student> sortStudents(string sortType, List<Student> theList) {

            switch(sortType){
                
                case "Exams":
                    theList.Sort(delegate(Student x, Student y) {
                        return x.exams.CompareTo(y.exams);
                    });
                    
                    break;


                case "HW":
                    theList.Sort(delegate(Student x, Student y) {
                        return x.homework.CompareTo(y.homework);
                    });
                    
                    break;

            }


            return theList;

        }


        public static void printStudents(List<Student> theList) {
            foreach(Student theStudent in theList){
                Console.WriteLine("Name: " + theStudent.Name +" ID: " + theStudent.ID + " HW: " + theStudent.homework  + " quiz: " + theStudent.quizzes + " exam: " + theStudent.exams);
            }
        }

    }


    public class Student {
        private string name;
        private int id;
        private double hw;
        private double quiz;
        private double exam;
    
        public Student(string name, int id, double hw, double quiz, double exam) {
            this.name = name;
            this.hw = hw;
            this.quiz = quiz;
            this.id = id;
            this.exam = exam;
        }
    
        public string Name {
            get { return name;  }
            set { name = value; }
        }

        public int ID {
            get { return id;  }
            set { id = value; }
        }    

        public double homework {
            get { return hw; }
            set { hw = value; }
        }
        public double quizzes {
            get { return quiz; }
            set { quiz = value; }
        }
        public double exams {
            get { return exam; }
            set { exam = value; }
        }

    }


    public class Classroom {
            
        public Classroom(List<Student> classList) {
            this.classList = classList;
        }
    
        public List<Student> classList {
            get { return classList;  }
            set { classList = value; }
        }

    }

}
