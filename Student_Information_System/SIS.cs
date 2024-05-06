using Student_Information_System.Details;
using Student_Information_System.Models;
using System.Xml.Serialization;
using System.Transactions;
using Student_Information_System.Error_Handling;
using Student_Information_System.Database;
using System.Data.SqlClient; //  for SQL Server


namespace Student_Information_System
{
    internal class SIS
    {
        static void Main(string[] args)
        {
            //new
            string connectionString = "Data Source=TANYA-PERSONAL;Initial Catalog=SISDB;Integrated Security=True";

            StudentDetails studentDetail = new StudentDetails();
            CourseDetails courseDetail = new CourseDetails();
            EnrollmentDetails enrollmentDetail = new EnrollmentDetails();
            TeacherDetails teacherDetail = new TeacherDetails();
            PaymentDetails paymentDetail = new PaymentDetails();
            int choice = 0, choice1 = 0, choice2 = 0, choice3 = 0, choice4 = 0, choice5 = 0;
            do
            {
            //new
                SqlConnection sqlconnection = new SqlConnection(connectionString);

                try
                {
                    sqlconnection.Open();
                    Console.WriteLine("Database connection successful");
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // Close the connection after using it
                    if (sqlconnection.State == System.Data.ConnectionState.Open)
                        sqlconnection.Close();
                }
            //end
                //Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("--------------");
                Console.WriteLine($"1: Student\n2: Course\n3: Enrollment\n4: Teacher\n5: Payment\n6:Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //Console.Clear();
                        Student student = new Student();

                        do
                        {
                            Console.WriteLine("Student Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Student Records\n2: Update student Records\n3: Enroll Student in Course\n4: Make Payment\n5: Display Student Records\n6: Get enrolled courses\n7: Get payment history\n8: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice1 = int.Parse(Console.ReadLine());
                            switch (choice1)
                            {

                                case 1:
                                        Console.WriteLine("Enter Student id: ");
                                        int id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string lname = Console.ReadLine();
                                        Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                                        string dob = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string email = Console.ReadLine();
                                        Console.WriteLine("Enter phone number: ");
                                        string phno = Console.ReadLine();
                                        student = new Student(id, fname, lname, DateTime.Parse(dob), email, phno);
                                        InvalidStudentData.InvalidStudentDataE(student);
                                        //studentDetail.InsertRecords(student);
                                        Console.WriteLine("Record inserted successfully");
                                    StudentDB.InsertStudent(id, fname, lname, dob, email, phno, connectionString);
                                    break;

                                case 2:
                                        Console.WriteLine("Enter Student id to be updated: ");
                                        int u_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string u_fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string u_lname = Console.ReadLine();
                                        Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                                        string u_dob = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string u_email = Console.ReadLine();
                                        Console.WriteLine("Enter phone number: ");
                                        string u_phno = Console.ReadLine();
                                        Student student1 = new Student(u_id, u_fname, u_lname, DateTime.Parse(u_dob), u_email, u_phno);
                                        InvalidStudentData.InvalidStudentDataE(student1);
                                        //studentDetail.UpdateStudentInfo(student1);
                                        Console.WriteLine("Record updated successfully");
                                        StudentDB.UpdateStudent(u_id, u_fname, u_lname, u_dob, u_email, u_phno, connectionString);
                                        break;

                                case 3:
                                        Console.WriteLine("Enter Course id: ");
                                        int c_id = int.Parse(Console.ReadLine());
                                        Course courses = new Course();
                                        courses.CourseID = c_id;
                                        CourseNotFound.CourseNotFoundE(courses);
                                        Console.WriteLine("Enter student id: ");
                                        int s_id = int.Parse(Console.ReadLine());
                                        StudentNotFound.StudentNotFoundE(s_id);
                                        Console.WriteLine("Enter enrollment id: ");
                                        DuplicateEnrollment.DuplicateEnrollmentE(s_id);
                                        int e_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter enrollment date: ");
                                        string e_date = Console.ReadLine();
                                        //studentDetail.EnrollInCourse(courses, s_id, e_id, DateTime.Parse(e_date));
                                        StudentDB.Enroll(c_id, s_id, e_id, e_date, connectionString);
                                        break;

                                case 4:
                                        Console.WriteLine("Enter Payment Id: ");
                                        int p_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter student id: ");
                                        int studentid = int.Parse(Console.ReadLine());
                                        StudentNotFound.StudentNotFoundE(studentid);
                                        Console.WriteLine("Enter amount");
                                        decimal amount = decimal.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter payment date: ");
                                        string p_date = Console.ReadLine();
                                        //studentDetail.MakePayment(p_id, studentid, amount, DateTime.Parse(p_date));
                                        StudentDB.RecordPayment(p_id, studentid, amount, p_date, connectionString);
                                    break;

                                case 5:
                                    StudentDB.DisplayStudentInfo(connectionString);
                                    break;

                                case 6:
                                    Console.WriteLine("Enter student id: ");
                                    int s_id1 = int.Parse(Console.ReadLine());
                                    StudentDB.GetEnrolledCourses(s_id1, connectionString);
                                    break;

                                case 7:
                                    Console.WriteLine("Enter student id: ");
                                    int s_id2 = int.Parse(Console.ReadLine());
                                    StudentDB.GetPaymentHistory(s_id2, connectionString);
                                    break;

                                case 8:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice1 != 8);
                        break;

                    case 2:
                        //Console.Clear();
                        Course course = new Course();
                        do
                        {
                            Console.WriteLine("Course Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Course Records\n2: Update Course Records\n3: Get enrollments\n4: Get teacher\n5: Display course Records\n6: Assign Teacher\n7: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                        Console.WriteLine("Enter course id: ");
                                        int c_id = int.Parse(Console.ReadLine()); //ado input
                                        Console.WriteLine("Enter course name: ");
                                        string c_name = Console.ReadLine(); //ef input
                                        Console.WriteLine("Enter course code: ");
                                        string c_code = Console.ReadLine();
                                        Console.WriteLine("Enter instructor name: ");
                                        string instructor = Console.ReadLine();
                                        course = new Course(c_id, c_name, c_code, instructor);
                                        InvalidCourseData.InvalidCourseDataE(course);
                                       // courseDetail.InsertDetails(course);
                                    CourseDB.InsertCourse(c_id, c_name, c_code, instructor, connectionString);
                                    break;

                                case 2:
                                        Console.WriteLine("Enter course id: ");
                                        int u_cid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter course name: ");
                                        string u_cname = Console.ReadLine();
                                        Console.WriteLine("Enter course code: ");
                                        string u_ccode = Console.ReadLine();
                                        Console.WriteLine("Enter instructor name: ");
                                        string u_instructor = Console.ReadLine();
                                        Course course1 = new Course(u_cid, u_cname, u_ccode, u_instructor);
                                        InvalidCourseData.InvalidCourseDataE(course1);
                                        //courseDetail.UpdateCourseInfo(course1);
                                    CourseDB.UpdateCourse(u_cid, u_cname, u_ccode, u_instructor, connectionString);
                                   break;

                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Enter course id: ");
                                        int course_id = int.Parse(Console.ReadLine());
                                        CourseDB.GetEnrollments(course_id, connectionString);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 4:
                                    try
                                    {
                                        Console.WriteLine("Enter course name: ");
                                        string course_name = Console.ReadLine();
                                        CourseDB.GetTeacher(course_name, connectionString);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 5:
                                    try
                                    {
                                        Console.WriteLine("Course List: ");
                                        CourseDB.DisplayRecords(connectionString);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 6:
                                        Console.WriteLine("Enter teacher id: ");
                                        int t_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string t_fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string t_lname = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string t_email = Console.ReadLine();
                                        Teacher teachers = new Teacher(t_id, t_fname, t_lname, t_email);
                                        TeacherNotFound.TeacherNotFoundE(teachers);
                                        Console.WriteLine("Enter course id: ");
                                        int cid = int.Parse(Console.ReadLine());
                                        Course course2 = new Course();
                                        course2.CourseID = cid;
                                        CourseNotFound.CourseNotFoundE(course2);
                                        //courseDetail.AssignTeacher(teachers, course);
                                        CourseDB.AssignTeacher(teachers, course2, connectionString);
                                    break;

                                case 7:
                                    Console.WriteLine("Exiting..");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice2 != 7);
                        break;

                    case 3:
                        //Console.Clear();
                        Enrollment enrollment = new Enrollment();
                        do
                        {
                            Console.WriteLine("Enrollment Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Enrollment Records\n2: Get Student\n3: Get Course\n4: Display Enrollment Records\n5: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice3 = int.Parse(Console.ReadLine());
                            switch (choice3)
                            {
                                case 1:
                                        Console.WriteLine("Enter enrollment id: ");
                                        int e_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter student id: ");
                                        int s_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter course id: ");
                                        int c_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter enrollment date: ");
                                        string e_date = Console.ReadLine();
                                        enrollment = new Enrollment(e_id, s_id, c_id, DateTime.Parse(e_date));
                                        InvalidEnrollmentData.InvalidEnrollmentDataE(enrollment);
                                        //enrollmentDetail.InsertDetails(enrollment);
                                        EnrollmentDB.InsertEnrollment(e_id, s_id, c_id, DateTime.Parse(e_date), connectionString);
                                    break;

                                case 2:
                                    Console.WriteLine("Enter student id: ");
                                    int studentId = int.Parse(Console.ReadLine());
                                    EnrollmentDB.GetStudent(studentId, connectionString);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter course id: ");
                                    int courseId = int.Parse(Console.ReadLine());
                                    EnrollmentDB.GetCourse(courseId, connectionString);
                                    break;

                                case 4:
                                    Console.WriteLine("Enrollment list: ");
                                    EnrollmentDB.DisplayDetails(connectionString);
                                    break;

                                case 5:
                                    Console.WriteLine("Exiting..");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;

                            }
                        } while (choice3 != 5);
                        break;

                    case 4:
                        //Console.Clear();
                        Teacher teacher = new Teacher();
                        do
                        {
                            Console.WriteLine("Teacher Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Enrollment Records\n2: Update teacher details\n3: Get Assigned Course\n4: Display Teacher info\n5: Exit\n");
                            Console.WriteLine("Enter your choice: ");

                            choice4 = int.Parse(Console.ReadLine());
                            switch (choice4)
                            {
                                case 1:
                                        Console.WriteLine("Enter teacher id: ");
                                        int t_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string lname = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string email = Console.ReadLine();
                                        teacher = new Teacher(t_id, fname, lname, email);
                                        InvalidTeacherData.InvalidTeacherDataE(teacher);
                                        //teacherDetail.InsertDetails(teacher);
                                    TeacherDB.InsertDetails(teacher,connectionString);

                                    break;

                                case 2:
                                        Console.WriteLine("Enter teacher id: ");
                                        int u_tid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string u_fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string u_lname = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string u_email = Console.ReadLine();
                                        Teacher teacher1 = new Teacher(u_tid, u_fname, u_lname, u_email);
                                        InvalidTeacherData.InvalidTeacherDataE(teacher1);
                                        //teacherDetail.UpdateTeacherInfo(teacher1);
                                        TeacherDB.UpdateTeacherInfo(teacher1, connectionString);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter teacher name: ");
                                    string teacherName = Console.ReadLine();
                                    TeacherDB.GetAssignedCourses(teacherName, connectionString);
                                    break;

                                case 4:
                                    Console.WriteLine("Teacher details: ");
                                    TeacherDB.DisplayDetails(connectionString);
                                    break;

                                case 5:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice4 != 5);
                        break;

                    case 5:
                        //Console.Clear();
                        Payment payment = new Payment();
                        do
                        {
                            Console.WriteLine("Payment Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Payment Records\n2: Get student\n3: Get payment amount\n4. Get payment date\n5: Display Payment info\n6: Exit\n");
                            Console.WriteLine("Enter your choice: ");

                            choice5 = int.Parse(Console.ReadLine());
                            switch (choice5)
                            {
                                case 1:
                                        Console.WriteLine("Enter payment id: ");
                                        int p_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter student id: ");
                                        int s_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter amount: ");
                                        decimal amount = decimal.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter payment date: ");
                                        string p_date = Console.ReadLine();
                                        payment = new Payment(p_id, s_id, amount, DateTime.Parse(p_date));
                                        PaymentValidation.PaymentErrorE(payment);
                                        //paymentDetail.InsertDetails(payment);
                                    PaymentDB.InsertPayment(p_id, s_id, amount, DateTime.Parse(p_date), connectionString);
                                    break;

                                case 2:
                                    Console.WriteLine("Enter student id: ");
                                    int studentId = int.Parse(Console.ReadLine());
                                    PaymentDB.GetPaymentsByStudentId(studentId, connectionString);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter payment id: ");
                                    int paymentId = int.Parse(Console.ReadLine());
                                    PaymentDB.GetPaymentAmountById(paymentId, connectionString);
                                    break;

                                case 4:
                                    Console.WriteLine("Enter payment id: ");
                                    int paymentId1 = int.Parse(Console.ReadLine());
                                    PaymentDB.GetPaymentDateById(paymentId1, connectionString);
                                    break;

                                case 5:
                                    Console.WriteLine("Payment info: ");
                                    PaymentDB.DisplayDetails(connectionString);
                                    break;

                                case 6:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice5 != 5);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 6);

        }
    }
}
