﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string JobNumber { get; set; }
        public string Password { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            this.Course = new HashSet<Course>();
            this.Student = new HashSet<Student>();
        }
    
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int DepartmentId { get; set; }
        public Nullable<int> ClassSize { get; set; }
    
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.CourseAttachment = new HashSet<CourseAttachment>();
            this.CourseExperiment = new HashSet<CourseExperiment>();
            this.CourseHomework = new HashSet<CourseHomework>();
            this.Score = new HashSet<Score>();
        }
    
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string ShortIntroduction { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public string IntroImage { get; set; }
        public Nullable<int> TheoryClassHour { get; set; }
        public Nullable<int> ExperimentClassHour { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Teacher Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseAttachment> CourseAttachment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseExperiment> CourseExperiment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseHomework> CourseHomework { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Score { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseAttachment
    {
        public int AttachmentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int CourseId { get; set; }
        public Nullable<System.DateTime> IssuedTime { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseExperiment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseExperiment()
        {
            this.Experiment = new HashSet<Experiment>();
        }
    
        public int CourseExperimentId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public string Purpose { get; set; }
        public string Steps { get; set; }
        public string References { get; set; }
        public int CourseId { get; set; }
        public Nullable<System.DateTime> IssuedTime { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experiment> Experiment { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseHomework
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseHomework()
        {
            this.Homework = new HashSet<Homework>();
        }
    
        public int CourseHomeworkId { get; set; }
        public string Name { get; set; }
        public System.DateTime IssuedTime { get; set; }
        public System.DateTime Deadline { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Homework> Homework { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            this.Class = new HashSet<Class>();
            this.Student = new HashSet<Student>();
            this.Teacher = new HashSet<Teacher>();
        }
    
        public int DepartmentId { get; set; }
        public string ChinesaeName { get; set; }
        public string EnglishName { get; set; }
        public string Introduction { get; set; }
        public string Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Experiment
    {
        public int ExperimentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int StudentId { get; set; }
        public Nullable<int> Mark { get; set; }
        public int CourseExperimentId { get; set; }
    
        public virtual CourseExperiment CourseExperiment { get; set; }
        public virtual Student Student { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Homework
    {
        public int HomeworkId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int StudentId { get; set; }
        public Nullable<int> Mark { get; set; }
        public int CourseHomeworkId { get; set; }
    
        public virtual CourseHomework CourseHomework { get; set; }
        public virtual Student Student { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Nullable<int> Mark { get; set; }
        public int ScoreId { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Experiment = new HashSet<Experiment>();
            this.Score = new HashSet<Score>();
            this.Homework = new HashSet<Homework>();
        }
    
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public int Grade { get; set; }
        public int ClassId { get; set; }
        public int DepartmentId { get; set; }
        public string Password { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experiment> Experiment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Score { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Homework> Homework { get; set; }
    }
}
namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            this.Course = new HashSet<Course>();
        }
    
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string JobNumber { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public string Introduction { get; set; }
        public bool Banned { get; set; }
        public string HeadImage { get; set; }
        public string Title { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Course { get; set; }
        public virtual Department Department { get; set; }
    }
}
