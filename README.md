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
  A <b>Guest</b> (unregistered/not logged- in user) is allowed to:
  <li>View general information in the application</li>
  <b>Logged- in user</b> is allowed to:
  <li>Vote in competitions in progress</li>
  <li>Register own dog/s</li>
  <li>Apply for judge</li>
  Logged- in user in an <b>Owner</b> role (becomes an owner at the moment of first dog registration) is allowed to:
  <li>Edit or delete own dog/s</li>
  <li>Vote in competitions in progress</li>
  <li>Add own dogs in upcoming competitions</li>
  <li>Find a partner for his own dog/s</li>
  <li>Apply for a judge</p>
  Logged- in user in <b>Judge</b> role (becomes judge at the moment of judge application form approval) is allowed to:
  <li>Vote in competitions in progress where his points given to a dog will be doubled</li>
  Logged- in user can be in an <b>Owner</b> and in a <b>Judge</b> role at the same time
  Logged- in user in an <b>Admin</b> role is allowed to:
  <li>Approve or reject newly proposed dog breeds</li>
  <li>Approve or reject judge application forms</li>
  <li>Create dog competitions</li>
  <li>Generate a dog breeds report</li>
