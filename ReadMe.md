###  DESCRIPTION
The name of the project is 'OnTime'. This is an appointment-schedule app and the main goal is to store appointments or taks and get you notified.
- [Project Images](https://drive.google.com/drive/folders/16RXc5ArKTV2vKwvBJW9kBuIuxpz5MSkl?usp=share_link)


###  IMPORTANT NOTE
  - The UNIT TESTS for this project can be found [HERE](https://github.com/drcipri/OnTime.Tests).
  - I am open to any feedback, bad or good because this is what will make me a better developer.
  - I will explain in detail each class and all the features i have currently added.I will not explain ASP.NET files.
 

###  Get Started
**Information**
 - The framework this app targets is **.NET 6.0**,it was developed using **VISUAL STUDIO 2022**, and contains the next packages:
     - Microsoft.EntityFrameworkCore 6.0.15
     - Microsoft.EntityFrameworkCore.Design 6.0.15
     - Microsoft.EntityFrameworkCore.Relational 6.0.15
     - Microsoft.EntityFrameworkCore.SqlServer 6.0.15

Follow the next steps to make the project work:
1. **Install SQL SERVER LocalDB**  
- To work with the database i am using the code first approach and EntityFrameworkCore(ORM). The app store the data using  **SQL SERVER LocalDB** database and you need to have LocalDB installed to make the project work. If you dont have LocalDb installed, you can find how to install it [HERE](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16)

2. **Create the Database**
- The app contains a class that will seed mock data to the database. This seed class will run automatically all migrations, and create your database when you start the project.
> You can find this file in: ```OnTime->Models->SeedData.cs```
- If you do not wish to seed mock data and you want to have an empty database, you need to delete or comment out this SeedData class call. 
> To find the *SeedData* call go to: ```OnTime->Program.cs->SeedData.PopulateDatabase(app);``` and comment out or delete this line.

> If you do this you will also need to update the database manually. To do this Entity framework requires a tools package for the command lines. If you are using VISUAL STUDIO package manager console you need to install ```Microsoft.EntityFrameworkCore.Tools 6.0.15``` and run the next command:  ```update-database``` 

> if you are using an external cmd, you need to have installed EntityFramework tools package. Run this command to install it: ```dotnet tool install --global dotnet-ef version 6.0.0```. Then navigate to the project location, and to update the database run the next command: ```dotnet ef database update``` This will create the database without any data.

> If you wish to recreate the database again , **drop** the database and run the app with the SeedData class call or update the database manually if you wish to have an empty database.

> To drop the database with the external cmd , run the next command: ```dotnet ef database drop --force```

3. **Starting the project**
- Run the project with VISUAL STUDIO;
- You can also start the project using the external cmd with the next command: ```dotnet run```. Then in your browser type: ```http://localhost:5000```
- If you can't make this project work please contact me(cipri.dragus27@gmail.com) and i will help you.


###  APP SUMMARY
- I created the project from an empty WEB template for learning purposes. I have used both **RazorPages** and **MVC** services to build this app. The web app is also **Mobile Friendly**.

**Project Classification**
  - I have classified from the start each appointment/task into four catogories and for this reason i decided to populate the Classification table in the database with real data using a migration. 
  > The migration can be found in : ```OnTime->Models->Migrations->_PopulateClassifications```
- **Awaiting** -> this is the primary classification.Every time you add a task/appointment, it will automatically be classified as awaiting.
- **Succesfull** -> this classification tells that the a/t has been reached.
- **Missed** -> tells that a/t has not been reached.
- **Canceled** -> telss that a/t has been canceled.
> In the Body/Header you will find links for each appointments/tasks category. This links are database generated!

**Appointments/Tasks**
- Each appointment/task contains an: Ojective , Reason , AdditionalInfo, AppointmentDate and PostDate. Each appointment, task, can be edited, deleted, marked at will.
- The appointment task contains a button for delete, a button for marking, and a button for editing in the right corner. I have installed **Fontawesome** package to get an icon
for editing.

**Pagination**
- Each page can contain max 4 appointments/task per page. You can change this from the code. If there are more than 4 appointments/tasks, In the bottom of the page you will find 
buttons to paginate.

**Submit new Appointment**
- Under the Body/Header you will find two buttons. The first button is ```AddAppointment```. Pressing this button will get you to a razor page where you can submit a form to add a new task/appointment.

**History**
- Under the Body/header you will find two buttons. The second button is ```History```. Pressing this button will take you to a page where you can find records for every **CRUD** operation you made for each appointment. I will explain in detail later, but to achieve this i have created a few triggers in the database through a migration. You will also find a search field , that you can use to search through the records.
> You can find the migration: ```OnTime->Models->Migrations->_AuditAppointments```





