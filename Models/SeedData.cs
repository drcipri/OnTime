﻿using Microsoft.EntityFrameworkCore;

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
                        DateTime = new DateTime(2023, 2, 20, 12, 0, 0),
                        Reason = "I broke my front teets",
                        AdditionalInfo = "Doctor changed location to downtown",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Cut the trees in fron of the house",
                        DateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        Reason = "The police said they are dangerous for other people",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Football with the boys",
                        DateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "Bank appointment",
                        DateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        Reason = "Get credit",
                        AdditionalInfo = "Dont forget the house papers",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    },
                    new Appointment
                    {
                        Objective = "My daughter graduation",
                        DateTime = new DateTime(2023, 2, 25, 10, 0, 0),
                        Reason = "Its really important for my daughter that i will attend",
                        AdditionalInfo = "Don't forget to buy flowers and a gift.",
                        Classification = context.Classifications.First(c => c.Id == 1)
                    }); 
                context.SaveChanges();
            }

        }
    }
}