using Microsoft.EntityFrameworkCore;

namespace OnTime.Models
{
    public static class SeedData
    {
        //IApplicationBuilder is the interface used in program.cs to register middlaware components to handle HTTP requests.
        public static void PopulateDatabase(IApplicationBuilder app)
        {
            //get the context from app builder
            OnTimeAppointmentsDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<OnTimeAppointmentsDbContext>();
          
            //here we check if the database has any pending migrations, if it has then run the migrations 
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if the database does not have any data in Appointments, add data
            if(!context.Appointments.Any())
            {
                context.Appointments.AddRange(
                    new Appointment
                    {
                        Objective = "Dentist appointment",
                        AppointmentDateTime = new DateTime(2023, 2, 20, 12, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "I broke my front teets",
                        AdditionalInfo = "Doctor changed location to downtown",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Cut the trees in fron of the house",
                        AppointmentDateTime = new DateTime(2023, 4, 12, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "The police said they are dangerous for other people",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Football with the boys",
                        AppointmentDateTime = new DateTime(2023, 4, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Bank appointment",
                        AppointmentDateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Get credit",
                        AdditionalInfo = "Dont forget the house papers",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "My daughter graduation",
                        AppointmentDateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Its really important for my daughter that i will attend",
                        AdditionalInfo = "Don't forget to buy flowers and a gift.",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                     new Appointment
                     {
                         Objective = "Jail appointment",
                         AppointmentDateTime = new DateTime(2023, 1, 20, 12, 0, 0),
                         PostDateTime = DateTime.Now,
                         Reason = "Visit my dat",
                         AdditionalInfo = "Dont stay more than 10 min",
                         Classification = context.Classifications.First(c => c.Id == 1)
                     },
                    new Appointment
                    {
                        Objective = "Change oil to my car",
                        AppointmentDateTime = new DateTime(2023, 5, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Its over 10k km",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "My cousin come over",
                        AppointmentDateTime = new DateTime(2023, 7, 11, 11, 0, 0),
                        PostDateTime = DateTime.Now,
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Police statement",
                        AppointmentDateTime = new DateTime(2023, 8, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "I had an accident",
                        AdditionalInfo = "Dont forget the house papers",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Brain surgery",
                        AppointmentDateTime = new DateTime(2023, 10, 17, 7, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "I'am to stupid",
                        AdditionalInfo = "Bring a new brain",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                     new Appointment
                     {
                         Objective = "Funneral",
                         AppointmentDateTime = new DateTime(2023, 2, 20, 12, 0, 0),
                         PostDateTime = DateTime.Now,
                         Reason = "Grandma died",
                         AdditionalInfo = "Buy Flowers",
                         Classification = context.Classifications.First(c => c.Id == 2)
                     },
                    new Appointment
                    {
                        Objective = "Cut the pigs",
                        AppointmentDateTime = new DateTime(2023, 4, 12, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Yearly pigs day",
                        Classification = context.Classifications.First(c => c.Id == 2)
                    },
                    new Appointment
                    {
                        Objective = "Cinema Movie",
                        AppointmentDateTime = new DateTime(2023, 4, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Classification = context.Classifications.First(c => c.Id == 2)
                    },
                    new Appointment
                    {
                        Objective = "Dating with my other girlfriend",
                        AppointmentDateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "She want money",
                        AdditionalInfo = "Dump her",
                        Classification = context.Classifications.First(c => c.Id == 2)
                    },
                    new Appointment
                    {
                        Objective = "Meeting with my boss",
                        AppointmentDateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "He must give me the salary",
                        AdditionalInfo = "I have to ask for a raise",
                        Classification = context.Classifications.First(c => c.Id == 2)
                    },
                     new Appointment
                     {
                         Objective = "Mountain Hiking",
                         AppointmentDateTime = new DateTime(2023, 2, 20, 12, 0, 0),
                         PostDateTime = DateTime.Now,
                         Reason = "I have to lose weight",
                         AdditionalInfo = "Bring a mcdonald menu",
                         Classification = context.Classifications.First(c => c.Id == 3)
                     },
                    new Appointment
                    {
                        Objective = "Oil change",
                        AppointmentDateTime = new DateTime(2023, 4, 12, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "I am over 10.000km",
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                    new Appointment
                    {
                        Objective = "Playing with my daughter",
                        AppointmentDateTime = new DateTime(2023, 4, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                    new Appointment
                    {
                        Objective = "Police appointment",
                        AppointmentDateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Get caught stealing",
                        AdditionalInfo = "I have to bring my lawyer",
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                    new Appointment
                    {
                        Objective = "Plane",
                        AppointmentDateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "flying to vegas",
                        AdditionalInfo = "Dont spend all the mony",
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                     new Appointment
                     {
                         Objective = "Tinder appointment",
                         AppointmentDateTime = new DateTime(2023, 1, 20, 12, 0, 0),
                         PostDateTime = DateTime.Now,
                         Reason = "She is hot",
                         AdditionalInfo = "Bring the whole salary",
                         Classification = context.Classifications.First(c => c.Id == 3)
                     },
                    new Appointment
                    {
                        Objective = "Football game",
                        AppointmentDateTime = new DateTime(2023, 5, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "My favorite teams are playing",
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                    new Appointment
                    {
                        Objective = "Neighbours comes to my place",
                        AppointmentDateTime = new DateTime(2023, 7, 11, 11, 0, 0),
                        PostDateTime = DateTime.Now,
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                    new Appointment
                    {
                        Objective = "Burn my neighbour house",
                        AppointmentDateTime = new DateTime(2023, 8, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "He pissed me off",
                        AdditionalInfo = "Bring gasoline",
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                    new Appointment
                    {
                        Objective = "Toyota appointment",
                        AppointmentDateTime = new DateTime(2023, 10, 17, 7, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Test a car",
                        AdditionalInfo = "Bring the papers",
                        Classification = context.Classifications.First(c => c.Id == 3)
                    },
                     new Appointment
                     {
                         Objective = "take my wife in town",
                         AppointmentDateTime = new DateTime(2023, 5, 25, 10, 0, 0),
                         PostDateTime = DateTime.Now,
                         Reason = "She said i dont take her out very often",
                         Classification = context.Classifications.First(c => c.Id == 4)
                     },
                    new Appointment
                    {
                        Objective = "Learn JavaScript",
                        AppointmentDateTime = new DateTime(2023, 7, 11, 11, 0, 0),
                        PostDateTime = DateTime.Now,
                        Classification = context.Classifications.First(c => c.Id == 4)
                    },
                    new Appointment
                    {
                        Objective = "Learn React",
                        AppointmentDateTime = new DateTime(2023, 8, 25, 10, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Its to soon",
                        AdditionalInfo = "I will learn it in the future",
                        Classification = context.Classifications.First(c => c.Id == 4)
                    },
                    new Appointment
                    {
                        Objective = "Learn Blazor",
                        AppointmentDateTime = new DateTime(2023, 10, 17, 7, 0, 0),
                        PostDateTime = DateTime.Now,
                        Reason = "Its to soon",
                        AdditionalInfo = "I have to master MVC and RazorPages FIRST",
                        Classification = context.Classifications.First(c => c.Id == 4)
                    }
                    ); 
                context.SaveChanges();
            }

        }
    }
}
