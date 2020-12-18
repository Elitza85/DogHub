# DogHub Experience
Asp.Net 5.0 Project
<h3>C# Web Development Path at Software University Professional Qualification Center, Bulgaria</h3>
<hr></hr>
<h2>Project Desciption</h2>
<ul>
<li>The new world requires a new way of doing the old stuff. This encompasses also the conducting of dog competitions. The DogHub Experience Platform gives the opportunity to dog owners to register their dogs in a dog catalogue, so that they have a wide presence in the world of dog mania.</li>
<li>Every registered dog has the opportunity to participate in a dog competition, as long as it covers the competition requirements. Every dog competitor will be judged by regular voters and by eligible judges during a competition that is in progress.</li>
</ul>
<hr></hr>
<h2>Database</h2>
<h4>
Microsoft SQL Server and Entity Framework Core were used to create and store the entities` data and relations between entities. The following entity tables are implemented to store data:
</h4>
<ul>
<li>Users</li>
<li>Roles</li>
<li>Dogs</li>
<li>Breeds</li>
<li>Dogs</li>
<li>DogColors</li>
<li>EyesColors</li>
<li>DogImages</li>
<li>DogsCompetitions</li>
<li>MatchRequestsSent</li>
<li>MatchRequestsReceived</li>
<li>Competitions</li>
<li>CompetitionImages</li>
<li>Organisers</li>
<li>JudgeApplicationForms</li>
<li>JudgeImages</li>
<li>EvaluationForms</li>
</ul>
<hr></hr>
<h2>Backend</h2>
<h4>
The project contains the following elements:
</h4>
<ul>
  <li>1 area: Administration</li>
  <li>10+ service methods</li>
  <li>10+ controllers</li>
  <li>20+ views</li>
</ul>
<hr></hr>
<h2>Users, Roles, Permissions</h2>
  A <b>Guest</b> (unregistered/not logged- in user) is allowed to:
  <li>View general information in the application</li>
  <b>Logged- in user</b> is allowed to:
  <li>Vote in competitions in progress</li>
  <li>Register own dog/s</li>
  <li>Apply for a judge</li>
  Logged- in user in an <b>Owner</b> role (becomes an owner at the moment of first dog registration) is allowed to:
  <li>Edit or delete own dog/s</li>
  <li>Vote in competitions in progress</li>
  <li>Add own dogs in upcoming competitions</li>
  <li>Find a partner for his own dog/s</li>
  <li>Apply for a judge</p>
  Logged- in user in <b>Judge</b> role (becomes judge at the moment of judge application form approval) is allowed to:
  <li>Vote in competitions in progress where his points given to a dog will be doubled</li>
  Logged- in user can be in an <b>Owner</b> and in a <b>Judge</b> role at the same time
  </br>Logged- in user in an <b>Admin</b> role is allowed to:
  <li>Approve or reject newly proposed dog breeds</li>
  <li>Approve or reject judge application forms</li>
  <li>Create dog competitions</li>
  <li>Generate a dog breeds report</li>
<hr></hr>
<h2>Features</h2>
<b>Dogs</b>
<li>Register a dog</li>
<li>View dogs catalogue</li>
<li>View/print a dog profile</li>
<li>Search dogs by breed or by colour</li>
<b>Competitions</b>
<li>A current competition- timer to vote in competition appears (dog owner cannot vote for his own dog, single user can vote only one time for a single dog in the current competition, judge voting points given to a dog are doubled)</li>
<li>Upcoming competitions- owner can add or remove own dog/s to/from an upcoming competition. To be eligible to participate in a competition the dog should be of the competition required breed and should not be spayed or neutered</li>
<li>Past competitions- contain information about the male and female winners and their points won in the competition</li>
<b>Judges</b>
<li>Judge list- full info about judge revealed</li>
<li>Apply for a judge through filling an application form</li>
<hr></hr>
<h2>Technologies Used</h2>
<h4>
The following technologies were used for building the application:
</h4>
<li>C#</li>
<li>Asp.Net 5.0</li>
<li>Entity Framework Core 5.0</li>
<li>MS SQL Server</li>
<li>Bootstrap 4</li>
<li>JavaScript</li>
<li>AJAX</li>
<li>HTML5</li>
<li>CSS</li>
<li>MS Visual Studio 2019</li>
<li>MS SQL Server Management Studio 2017</li>
<li>Theme- Wunderkind by TemplatesHub</li>
<li>SendGrid API</li>
<li>HighCharts</li>
<hr></hr>
*This web application has been created for educational purposes
