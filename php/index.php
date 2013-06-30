<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>Token Authentication</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    
  </head>
  <body>
    <div class="container">
      <?php
        include('security.php');

        //Key info shared with the CAS server
        $key = array('name' => 'alphabet_key', 'data' => 'abcdefghijklmnop' );

        $casURL = $_POST['serverURL'];
        $username = $_POST['username'];
        $firstName = $_POST['firstName'];
        $lastName = $_POST['lastName'];
        $email = $_POST['email'];

        if($username && $firstName && $lastName && $email && $casURL){

          // Create the JSON object
          $tokenData = array( 'generated' => time() * 1000,
                              'credentials' => array( 'username' => $username,
                                                      'firstname' => $firstName,
                                                      'lastname' => $lastName,
                                                      'email' => $email));
          $jsonData = json_encode($tokenData);

          //Encrypt the token
          $encrytedToken = Security::encrypt($jsonData, $key['data']);
          
          $finalURL = $casURL.'/login?username='.$username.'&token_service='.$key['name'].'&auth_token='.urlencode($encrytedToken);

          include('results.html');
        } else {
          include('form.html');
        }
      ?>
    </div>
  </body>
</html>