###  DESCRIPTION
The name of the project is 'OnTime'. This is an appointment-schedule app and the main goal is to store appointments or taks and get you notified.
- [Project Images](https://drive.google.com/drive/folders/16RXc5ArKTV2vKwvBJW9kBuIuxpz5MSkl?usp=share_link)


###  IMPORTANT NOTE
  -	I am currently studying ASP.NET and this project is not finished yet. The project still need improvements and i plan to add a lot of new features.
  - The UNIT TESTS for this project can be found [HERE](https://github.com/drcipri/OnTime.Tests). However UNIT TESTS are currently incomplete. As i said before, i am currently studying
  ASP.NET , and to properly test some of the features of this project i need a deep knowledge of what is going on behind the scenes. 
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


##  DOCS

### wwwroot
#### style 
- This folder contains files that are CSS related.
##### OnTimeStyle.css
- This file contains all the CSS for this project.

### Models
- This folder contains all classes that are affiliated with the database.

#### Appointment.cs
- This class represents and appointment or task and is mapped to a table in the database.
- *Id*: an integer property that uniquely identifies the appointment. This property is decorated with the "BindNever" attribute, which means it will not be included in model binding.
- *Objective*: a string property that represents the objective or purpose of the appointment. It is required and has a default value of an empty string.
- *PostDateTime*: a DateTime property that represents the date and time when the appointment was posted or created.
- *Reason*: a nullable string property that represents the reason for the appointment.
- *AdditionalInfo*: a nullable string property that represents any additional information about the appointment.
- *Classification*: a nullable property of the "Classification",and this is a navigation property to Classification Table.
- *ClassificationId*: an integer property that represents the ID data of the classification table.
- The *Required* attributes helps to validate the data on the ServerSide using *ModelState* property. See an example in: **OnTime->Pages->AddAppointment.cshtml.cs**

#### Classification.cs
- This class represents classifications of the appointments or tasks and is mapped to a table in the database.
- *Id*: an integer property that uniquely identifies the classification.
- *Name*: a string that identifies the name of classification.

#### AppointmentsAudit.cs
- This class represents the audit trail or history for the appointments.Is used to track changes made to appointments and is mapped to a table in the database.
- ***Id***: an integer property that uniquely identifies the audit trail record.
- ***ActionDate***: a DateTime property that represents the date and time when the audit action was performed.
- ***ActionType***: a string property that represents the type of audit action performed (e.g., create, update, delete).
- ***AppointmentDateTime***: a DateTime property that represents the date and time of the appointment associated with this audit trail record.
- ***PostDateTime***: a DateTime property that represents the date and time when the appointment was posted or created.
- ***Objective***: a string property that represents the objective or purpose of the appointment associated with this audit trail record.
- ***Reason***: a string property that represents the reason for the appointment associated with this audit trail record.
- ***AdditionalInfo***: a string property that represents any additional information about the appointment associated with this audit trail record.
- ***Classification***: a string property that represents the classification of the appointment associated with this audit trail record. 
- ***AppointmentId***: an integer property that represents the ID of the appointment associated with this audit trail record.

#### SeedData.cs
- This class is used to seed the database with mock data for development purposes. It will check for any pending migrations, run them if needed.
- Then it will check if there is any data in the specified table, in this case *Appointments* table , if not it will add the data that this class holds.

#### OnTimeAppointmentsDbContext.cs
- This class inherits from DbContext class and it represents a database context for this app and allows the application to interact with a database.
- ***Appointments***: a DbSet property that represents a collection of Appointment objects in the database.
- ***Classifications***: a DbSet property that represents a collection of Classification objects in the database.
- ***AppointmentsAudit***: a DbSet property that represents a collection of AppointmentAudit objects in the database.
- The ***OnModelCreating*** method is used to configure the database schema for the entities in the context. It calls the "ApplyConfiguration" method for each entity,  passing in a configuration object that specifies the mapping between the entity and the database.

#### DatabaseConfigs
- This folder holds the configurations for each table in the database.

##### AppointmentConfigs.cs
- This class provides configuration information for the ***Appointment*** entity.
- The ***Configure*** method in this class is used to define the database schema for the **Appointment** entity, including the table name and the mapping of each property to its corresponding database column. It also configures a foreign key relationship between the **Appointment** entity and the **Classification** entity using the **"HasOne"** and **"WithMany"** methods, specifying the foreign key property and the delete behavior.
- This class allows for more control over the database schema and provides a way to separate the entity configuration from the rest of the code. It also makes it easier to make changes to the database schema without affecting the rest of the application code.

##### ClassificationConfigs.cs
- This class proivdes configuration information for the ***Classification*** entity.
- The ***Configure*** method in this class is used to define the database schema for the ***Classification*** entity, including the table name and the mapping of each property to its corresponding database column.

##### AppointmentAuditConfigs.cs
- This class provides configuration information for the ***AppointmentAudit*** entity,including the table name and the mapping of each property to its corresponding database column.

#### Migrations
- This folder contains all the migrations for the database.

##### _CreateOnTimeDatabase.cs
- This migration will create the main database.

##### _PopulateClassification.cs
- This migration will add real data to the **Classification** table.

##### _AuditAppointments.cs
- This migration will create the **AuditAppointments** table and create the triggers that will track chages to **Appointments** table.

#### Repository
- This folder contains all the classes and interfaces needed for the repository pattern.

##### IRepositoryAppointment.cs
- This is an interface for a repository that manages appointments. It defines methods for filtering appointments, adding and removing appointments, updating appointments, and marking appointments with a classification. It also provides a way to retrieve a single appointment by ID. 
- The interface includes a property that returns a queryable collection of all appointments.This property is used only for development purposes because i did not wanted to use IQueryable interface outside of the repository pattern.

##### IRepositoryClassification.cs
- This is an interface for a repository that manages classifications. It contains a method for retrieving all classifications from the database.

##### IRepositoryAppointmentsAudit.cs
- This is an interface for a repository that manages appointment audit logs. It defines methods for getting all appointment audit logs, as well as for searching and retrieving appointment audit logs asynchronously based on certain criteria. The interface includes a property that returns a queryable collection of all appointment audit logs.This property is used only for development purposes.

##### RepositoryAppointment.cs
- This is a class that implements the IRepositoryAppointment interface and provides methods for adding, updating, and removing appointments. It also includes methods for marking appointments with a specified classification and for filtering appointments based on a classification. The class uses a DbContext to access the database and retrieve appointments.

##### RepositoryClassification.cs
- This class implements the IRepositoryClassification interface. It provides a method to get all classification objects from the database, ordered by their id in ascending order. It receives an instance of the OnTimeAppointmentsDbContext class in its constructor to access the database.

##### RepositoryAppointmentsAudit.cs
- This is a class that implements the IRepositoryAppointmentsAudit interface. It provides methods to retrieve appointment audit information from the database, including getting all  audit records, searching for audit records based on search criteria, and getting all audit records asynchronously.

### ViewModels
- This folder hold classes that are used to pass information beetween Controllers and Views.

#### AppointmentsListViewModel
- This class is a model that is used to pass information between controllers and views. It contains the following properties:
- ***Appointments***: An enumerable collection of Appointment objects representing the list of appointments to display.
- ***PaginationInfo***: An object of type PaginationInfo that provides information about pagination, such as the total number of pages and the current page number.
- ***Classification***: A string property representing the classification name used to filter the list of appointments. If no classification is specified, the property is set to an empty string.
> You can see how this object is used in: ```OnTime->Controllers->HomeController.cs```

#### PaginationInfo 
- This is a class that contain information about pagination.The properties of this class provide the necessary information for implementing pagination.
- ***ItemsPerPage***: This property represents the number of items to be displayed on each page of data.
- ***CurrentPage***: This property represents the current page number being viewed.
- ***TotalItems***: This property represents the total number of items to be paginated.
- ***TotalPages***: This property is a calculated property that returns the total number of pages required to display all the items. It is calculated by dividing the *TotalItems* property by the *ItemsPerPage* property, and then rounding up the result to the nearest integer using the Math.Ceiling() method.
> You can see how this object is used in: ```OnTime->Controllers->HomeController.cs```

#### MarkAppointmentClassification.cs
- This class represents a request to mark an appointment with a new classification. It can also provide a list of available classifications to choose from and check the current classification if it has one.
- ***Classifications***: An enumerable list of strings representing the available classifications that an appointment can have.
- ***AppointmentId***: An integer representing the unique identifier of the appointment to be marked.
- ***CurrentClassification***: A nullable string representing the current classification of the appointment, if it has one.
> You can see how this object is used in: ```OnTime->Component->AppointmentClassificationViewComponent.cs```

#### AppointmentsAuditSearchCriteria.cs 
- This class represents search criteria used to query an appointment audit trail. With the help of this class, devs can create a search criteria for quering appoinments audit records.
> You can see how this object is used in: ```OnTime->Controllers->HistoryController.cs```

### Component
- This folder contains all the ViewComponents created for this project. You can find what a ViewComponent is [HERE](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-7.0).

#### AppointmentClassificationViewComponent.cs
- This class represents a view component.The repository field provides acces to the database and The *Invoke* method uses the repository to  retrieves all the appointment classifications from the repository by calling the *GetAll()* method, then it encapsulate the *appointmentId* and the *currentClassification* that is needed to change the mark on the current appointment.
- Finally it returns the view by passing this object information using **MarkAppointmentClassification** object to a partial View that allows the user to mark the appointment with a new classification. 
> The partial view can be found in: ```OnTime->Views->Shared->Components->AppointmentClassification->Default.cshtml```

#### AppointmentsNavigationViewComponent.cs
- This class represents a view component. .The repository field provides acces to the database and The *Invoke* method uses the repository to  retrieves all the appointment classifications from the repository by calling the *GetAll()* method. The difference between this and the previous View Component is that here i dont need any other information like *appointmentId* or *currentClassification* because this ViewComponent is only used to generate links. 
> You can see how the links are generated in the partial view. The partial view can be found in: ```OnTime->Views->Shared->Components->AppointmentsNavigation->Default.cshtml```

### Controllers
- This folder contains all the controllers in an Asp.Net application. You can find what a Controller is [HERE](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs)

#### HomeController.cs
- This class represents a controller.The *Index* method retrieves the appointments from the repository that match the specified classification or the default classification if none is specified, orders them in descending order by post date and then it creates an instance of the **AppointmentsListViewModel** wich encapsulate the appointments, pagination information,and classification data and passes it to the *View()* method to render the view. 
- The pagination is calculated using the **PaginationInfo** class.The *PageSize* property is a public field that sets the number of appointments to be displayed on a single page.
- In summary, this class provides the functonality to display a paginated list of appointments on the home page of the application.
> You can find the View of this controller in : ```OnTime->Views->Home->Index.cshtml```

#### HistoryController.cs
- This class represents a controller. It has Two actions, *AppointmentsHistory* and *SearchHistory* and it has a repository dependecy for *AppointmentsAudit*.
- ***AppointmentsHistory*** action retrieves all appointments audit records from the repository and returns them in descending order by action date. The *SearchHistory* action searches for a record based on the search criteria provided and returns the matchi records in descending order by action date.In no search criteria is provided, the action redirects to the *History* route wich triggers *AppointmentsHistory* action of this class.
> You can find the view of this controller in: **OnTime->Views->History->AppointmentsHistory.cshtml**

### Infrastructure
- This folder holds the classes that are not related with the main functionality of the application.

#### PageLinkTagHelper
- This class is a custom TagHelper.You can find what tag helpers are [HERE](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-7.0).
- It has an attribute ***HtmlTargetElement*** to indicate that it is inteded to target HTML div elements with a *pagination-model* attribute.
- The class impements the TagHelper base class, wich provides the **Process** method that generates the pagination links. It takes in a *PaginationInfo* object, wich contains information about pagination, and an *IUrlHelperFactory* object wich is used to generate URLs for the pagination links.
- The class also includes Properties for the *PageAction* and *PageClassification*, wich are used to create the URL for the pagination links with the Help of *IUrlHelper* object.
- There are also a few properties that can be used to style the pagination links.
- The ***Process()*** method is the core of the TagHelper, this method generates URLS for each page, create HTML *anchor* elements for each page. This *anchor* elements are added to a parent div element then is added to the **output** of the tag helper.
> You can find how this class is used in: ```OnTime->Views->Home->Index.cshtml```. Pay attention to the div element and his attributes that trigger this tag helper.

### Views
- This Folder contains all the Razor Views. You can find what a RazorView is [HERE](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/overview?view=aspnetcore-7.0)

#### History/AppointmentsHistory.cshtml
- This represents a View that displays a table of appointments audit records using a foreach loop to iterate through the collection of *AppointmentsAudit* objects passed as a Model.
- It also includes a search bar form to allow users to search for specific audit records. The table displays the properties of each *AppointmentAudit* object as Columns.

#### Home/Index.cshtml
- This represents a View that displays a list of appointments using the **AppointmentsListViewModel** as Model. If there are appointments to display, it loops through each appointment and renders a partial View called **AppointmentSummary** for each one. It also includes a pagination container to navigate between pages and attributes that trigger a tag helper to generate the link pages. If there are no appointments, it displays a message.

#### Shared/AppointmentSummary.cshtml
- This is a partial view that displays appointment/task information. It also provides options to edit, delete , and change the classification of the task/appointment. The color of the classification label is determined by the classification name.

#### Shared/Components/AppointmentsClassification/Default.cshtml
- This is a partial view that displays a list of appointment classifications, excluding the current classification. It loops through the list of classifications and creates a form for each classification with a hidden input field for the appointment *Id* and the classification *Name*. When the user clicks on a classification button, it submits the form with the new classification Name to  the server using the HTTP POST request.

#### Shared/Components/AppointmentsNavigation/Default.cshtml
- This is a partial view that displays a list of navigation links using the *IEnumerable<string>* as the Model. It loops through each item and creates an anchor tag with a link to the *Index* action of the *Home* controller with a *classification* route parameter and an *appointmentsPage* route parameter set to 1 to get you the the first page. The text of the anchor tag is set to the current item of the loop.

### Pages
- This folder contains all the RazorPages. You can find what RazorPages are [HERE](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio)

#### AddAppointment.cshtml
- This is Razor Page contains a form for adding a new task or appointment. The form has a few fields, as well as a date time picker for selecting the Date and Time.
- The form is Submited using a POST method and a Submit button. The Razor Page uses Asp.Net Core model binding feature to bind the form fields to properties of the CurrentAppointment object of its model class.
- The *asp-validation-summary* attribute display the validation errors if there are any. This validation errors are checked on the server side using the *ModelState* property. A better approach would be to validate the fields on the client side using JavaScript without sending a request to the server.

##### AddAppointment.cshtml.cs (AddAppointmentModel)
- This class hadnles the adding and removing appointments. It has a bind Property for the *CurrentAppointmentObject*. 
- The *OnPost* method is called when the form is submitted, and itssets some properties of the CurrentAppointmentsObject, checks if the *ModelState* is Valid and based on this it either add the appointment on the database and redirects to the home page or return the current page and display the validation errors.
- The **OnPostRemove** method is called when the user clicks on the **DELETE** button for a specific appointment/task.It removes the appointment an redirects to the homepage with the specific
classification.

#### EditAppointment.cshtml
- This is a razor page for edditing appointments. It contains a Form with with a few fields and a Date time picker to edit the appointment details.It also has a few hidden fields that 
cannot be edited.
- If the appointment Id is not found, it displays a message indicating that there is nothing to edit. When the form is submited the appointment is updated in the database and the user is redirected to the **Home** page.

##### EditAppointment.cshtml.cs (EditAppointmentModel)
- This Class Handles the **Edit** and **MarkAs** functionality for appointments, in a web application. The class has two ***OnPost*** methods and one ***OnGet*** method.
- The ***OnGet*** method retrieves the appointment that is going to be edited based on its ID. 
- The first ***OnPost*** method will make sure that the editing is Valid and will update the database with the new edit.
- The second ***OnPostMarkAs*** method retrieves the appointment that is going to be edited by Id and update the database with a new classification for that appointment.
