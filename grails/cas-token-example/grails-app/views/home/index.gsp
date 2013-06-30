<html>

<head>
	<meta name="layout" content="kickstart" />
</head>

<body>

	<g:form name="tokenForm" controller="token" action="generateToken">
  <fieldset>

  <!-- Form Name -->
  <legend>Auth Token Generator</legend>

  <!-- Text input-->
  <div class="control-group">
    <label class="control-label" for="serverURL">CAS server URL</label>
    <div class="controls">
      <input id="serverURL" name="serverURL" type="text" placeholder="http://localhost:8080/cas" class="input-xlarge" required="">
      
    </div>
  </div>

  <!-- Text input-->
  <div class="control-group">
    <label class="control-label" for="username">Username</label>
    <div class="controls">
      <input id="username" name="username" type="text" placeholder="username" class="input-xlarge" required="">
      
    </div>
  </div>

  <!-- Text input-->
  <div class="control-group">
    <label class="control-label" for="firstName">First Name</label>
    <div class="controls">
      <input id="firstName" name="firstName" type="text" placeholder="first name" class="input-xlarge">
    </div>
  </div>

  <!-- Text input-->
  <div class="control-group">
    <label class="control-label" for="lastName">Last Name</label>
    <div class="controls">
      <input id="lastName" name="lastName" type="text" placeholder="last name" class="input-xlarge">
    </div>
  </div>

  <!-- Text input-->
  <div class="control-group">
    <label class="control-label" for="email">Email</label>
    <div class="controls">
      <input id="email" name="email" type="text" placeholder="email" class="input-xlarge">
      
    </div>
  </div>

  <!-- Button (Double) -->
  <div class="control-group">
    <div class="controls">
      <button id="button1id" name="button1id" class="btn btn-info" type="submit">Submit</button>
      <button id="button2id" name="button2id" class="btn btn-danger" type="reset">Cancel</button>
    </div>
  </div>

  </fieldset>
</g:form>

</body>

</html>
