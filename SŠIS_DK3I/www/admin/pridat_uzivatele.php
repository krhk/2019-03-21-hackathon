<?php
  require_once ($_SERVER['DOCUMENT_ROOT'] . 'constructor.php');
  get_sett_header();
  if( ! is_user_logged_in()){header("location: ". LOGINURL);exit;}
  db_construct();
?>

<?php
    $username = $password = $confirm_password = "";
    $username_err = $password_err = $confirm_password_err = "";
    if($_SERVER["REQUEST_METHOD"] == "POST"){
        if(empty(trim($_POST["username"]))){
            $username_err = "Prosím vložte uživatelské jméno.";
        } else{
            $sql = "SELECT id FROM users WHERE username = ?";
            if($stmt = mysqli_prepare($link, $sql)){
                mysqli_stmt_bind_param($stmt, "s", $param_username);
                $param_username = trim($_POST["username"]);
                if(mysqli_stmt_execute($stmt)){
                    mysqli_stmt_store_result($stmt);
                    if(mysqli_stmt_num_rows($stmt) == 1){
                        $username_err = "Toto uživatelské jméno je již zabrané.";
                    } else{
                        $username = trim($_POST["username"]);
                    }
                } else{
                    echo "Oops! Stala se chyba. Prosím, zkuste to znovu za chvíli.";
                }
            }
            mysqli_stmt_close($stmt);
        }
        if(empty(trim($_POST["password"]))){
            $password_err = "Prosím zadejte heslo.";
        } elseif(strlen(trim($_POST["password"])) < 6){
            $password_err = "Heslo musím mít minimálně šest znaků.";
        } else{
            $password = trim($_POST["password"]);
        }
        if(empty(trim($_POST["confirm_password"]))){
            $confirm_password_err = "Prosím potvrďte své heslo";
        } else{
            $confirm_password = trim($_POST["confirm_password"]);
            if(empty($password_err) && ($password != $confirm_password)){
                $confirm_password_err = "Hesla se neshodují.";
            }
        }
        if(empty($username_err) && empty($password_err) && empty($confirm_password_err)){
            $sql = "INSERT INTO users (username, password) VALUES (?, ?)";
            if($stmt = mysqli_prepare($link, $sql)){
                mysqli_stmt_bind_param($stmt, "ss", $param_username, $param_password);
                $param_username = $username;
                $param_password = password_hash($password, PASSWORD_DEFAULT);
                if(mysqli_stmt_execute($stmt)){
                    echo "<script type='text/javascript'>window.parent.location.reload()</script>";
                } else{
                    echo "Stala se chyba. Prosím, zkuste to znovu za chvíli.";
                }
            }
            mysqli_stmt_close($stmt);
        }
        mysqli_close($link);
    }
?>

  <div class="wrapper">
      <h2>Založení účtu</h2>
      <form action="<?php echo str_replace(".php", "", htmlspecialchars($_SERVER["PHP_SELF"])); ?>" method="post">
          <div class="form-group <?php echo (!empty($username_err)) ? 'has-error' : ''; ?>">
              <label>Přihlašovací jméno</label>
              <input type="text" name="username" class="form-control" value="<?php echo $username; ?>">
              <span class="help-block"><?php echo $username_err; ?></span>
          </div>
          <div class="form-group <?php echo (!empty($password_err)) ? 'has-error' : ''; ?>">
              <label>Heslo</label>
              <input type="password" name="password" class="form-control" value="<?php echo $password; ?>">
              <span class="help-block"><?php echo $password_err; ?></span>
          </div>
          <div class="form-group <?php echo (!empty($confirm_password_err)) ? 'has-error' : ''; ?>">
              <label>Heslo znovu</label>
              <input type="password" name="confirm_password" class="form-control" value="<?php echo $confirm_password; ?>">
              <span class="help-block"><?php echo $confirm_password_err; ?></span>
          </div>
          <div class="form-group">
              <input type="submit" class="btn btn-primary" value="Submit">
              <input type="reset" class="btn btn-default" value="Reset">
          </div>
      </form>
  </div>
<?php get_sett_footer();?>
