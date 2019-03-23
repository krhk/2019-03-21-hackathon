<?php

  /* Database credentials. Assuming you are running MySQL
  server with default setting (user 'root' with no password) */
  define('DB_SERVER', 'localhost');
  define('DB_USERNAME', 'nasweb1552759377');
  define('DB_PASSWORD', 'U4BHN1fD');
  define('DB_NAME', 'nasweb1552759377');
  /* Attempt to connect to MySQL database */
  $link = mysqli_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);
  // Check connection
  if($link === false){
      die("ERROR: Could not connect. " . mysqli_connect_error());
  }
?>
