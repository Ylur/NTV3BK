using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Verkefni_5.Repositories.Interfaces;
using Verkefni_5.Repositories.Implementations;
using Verkefni_5.Services.Interfaces;
using Verkefni_5.Services.Implementations;
using Verkefni_5.Data.Models;
using Verkefni_5.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
});

// Add DB Context
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectTeacherRepository, SubjectTeacherRepository>();

// Register Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IMarkService, MarkService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ISubjectTeacherService, SubjectTeacherService>();

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SchoolContext>();
        context.Database.EnsureCreated(); // This will create the database if it doesn't exist
        
        // Seed initial data if database is empty
        if (!context.Students.Any())
        {
            // Add sample data
            var group1 = new Group { Name = "Class 1A" };
            var group2 = new Group { Name = "Class 1B" };
            context.Groups.AddRange(group1, group2);
            
            var subject1 = new Subject { Title = "Mathematics" };
            var subject2 = new Subject { Title = "Science" };
            context.Subjects.AddRange(subject1, subject2);
            
            var teacher1 = new Teacher { FirstName = "John", LastName = "Doe" };
            var teacher2 = new Teacher { FirstName = "Jane", LastName = "Smith" };
            context.Teachers.AddRange(teacher1, teacher2);
            
            context.SaveChanges();
            
            var student1 = new Student { FirstName = "Alice", LastName = "Johnson", GroupId = group1.GroupId };
            var student2 = new Student { FirstName = "Bob", LastName = "Williams", GroupId = group1.GroupId };
            context.Students.AddRange(student1, student2);
            
            context.SaveChanges();
            
            var mark1 = new Mark { StudentId = student1.StudentId, SubjectId = subject1.SubjectId, Date = DateTime.Now, Value = 85 };
            var mark2 = new Mark { StudentId = student2.StudentId, SubjectId = subject2.SubjectId, Date = DateTime.Now, Value = 90 };
            context.Marks.AddRange(mark1, mark2);
            
            var st1 = new SubjectTeacher { SubjectId = subject1.SubjectId, TeacherId = teacher1.TeacherId };
            var st2 = new SubjectTeacher { SubjectId = subject2.SubjectId, TeacherId = teacher2.TeacherId };
            context.SubjectTeachers.AddRange(st1, st2);
            
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating/seeding the database.");
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


