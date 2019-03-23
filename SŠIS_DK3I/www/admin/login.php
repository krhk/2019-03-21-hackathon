<!-- Call for builder -->
  <?php
    require_once ($_SERVER['DOCUMENT_ROOT'] . 'constructor.php');
    get_header();
    if(is_user_logged_in()){header("location: " . ADMINURL);exit;}
    require_once (REL_CESTA . "db_conn.php");
    $username = $password = "";
    $username_err = $password_err = "";
    if($_SERVER["REQUEST_METHOD"] == "POST"){
      if(empty(trim($_POST["username"]))){
          $username_err = "Prosím zadejte uživatelské jméno.";
      } else{
          $username = trim($_POST["username"]);
      }
      if(empty(trim($_POST["password"]))){
          $password_err = "Prosím zadejte své heslo.";
      } else{
          $password = trim($_POST["password"]);
      }
      if(empty($username_err) && empty($password_err)){
          $sql = "SELECT id, username, password FROM users WHERE username = ?";
          if($stmt = mysqli_prepare($link, $sql)){
              mysqli_stmt_bind_param($stmt, "s", $param_username);
              $param_username = $username;
              if(mysqli_stmt_execute($stmt)){
                  mysqli_stmt_store_result($stmt);
                  if(mysqli_stmt_num_rows($stmt) == 1){
                      mysqli_stmt_bind_result($stmt, $id, $username, $hashed_password);
                      if(mysqli_stmt_fetch($stmt)){
                          if(password_verify($password, $hashed_password)){
                              session_start();
                              $_SESSION["loggedin"] = true;
                              $_SESSION["id"] = $id;
                              $_SESSION["username"] = $username;
                              header("location: " . ADMINURL);
                          } else{
                              $password_err = "Heslo, které jste zadali není správné";
                          }
                      }
                  } else{
                      $username_err = "Žádný uživatel pod tímto jménem neexistuje.";
                  }
              } else{
                  echo "Oops! Stala se chyba. Prosím, zkuste to znovu za chvíli.";
              }
          }
          mysqli_stmt_close($stmt);
      }
      mysqli_close($link);
  }
?>
    <div class="login_wraper">
        <h2>Přihlášení</h2>
        <form action="<?php echo str_replace(".php", "", htmlspecialchars($_SERVER["PHP_SELF"]));?>" method="post">
            <div class="form-group <?php echo (!empty($username_err)) ? 'has-error' : ''; ?>">
                <label><i class="fas fa-user"></i>  |  Přihlašovací jméno</label>
                <input type="text" name="username" class="form-control" value="<?php echo $username; ?>">
                <span class="help-block"><?php echo $username_err; ?></span>
            </div>
            <div class="form-group <?php echo (!empty($password_err)) ? 'has-error' : ''; ?>">
                <label><i class="fas fa-key"></i>  |  Heslo</label>
                <input type="password" name="password" class="form-control">
                <span class="help-block"><?php echo $password_err; ?></span>
            </div>
            <div class="form-group">
                <input type="submit" class="btn btn-primary" value="Přihlásit">
            </div>
        </form>
    </div>
    <link rel="stylesheet" href="<?php echo ( URL . "/css/admin.css");?>">
<?php get_footer(); ?>
