# DogHub Experience
Asp.Net 5.0 Project
<h3>C# Web Development Path at Software University Professional Qualification Center, Bulgaria</h3>
<hr></hr>
<h2>Project Desciption</h2>
<ul>
<li>The new world requires a new way of doing the old stuff. This encompasses also the conducting of dog competitions. The DogHub Experience Platform gives the opportunity to dog owners to register their dogs in a dog catalogue, so that they have a wide presence in the world of dog mania.</li>
<li>Every registered dog has the opportunity to participate in a dog competition, as long as it covers the competition requirements. Every dog competitor will be judged by regular voters and by eligible judges during a competition that is in progress.</li>
<li>The dog owner has the option to find a dog partner for his own dog.</li>
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
<ol>
  <li>a guest (unregistered/not logged- in user) is allowed to:</li>
  <p>View general information in the application</p>
  <li>Logged- in user is allowed to:</li>
  <p>Vote in competitions in progress</p>
  <p>Register own dog/s</p>
  <p>Apply for judge</p>
  <li>Logged- in user in an OWNER role (becomes an owner at the moment of first dog registration) is allowed to:</li>
  <p>Edit or delete own dog/s</p>
  <p>Vote in competitions in progress</p>
  <p>Add own dogs in upcoming competitions</p>
  <p>Find a partner for his own dog/s</p>
  <p>Apply for a judge</p>
  <li>Logged- in user in JUDGE role (becomes judge at the moment of judge application form approval) is allowed to:</li>
  <p>Vote in competitions in progress where his points given to a dog will be doubled</p>
  <li>Logged- in user can be in an OWNER and in a JUDGE role at the same time</li>
  <li>Logged- in user in an ADMIN role is allowed to:</li>
  <p>Approve or reject newly proposed dog breeds</p>
  <p>Approve or reject judge application forms</p>
  <p>Create dog competitions</p>
  <p>Generate a dog breeds report</p>
</ol>
