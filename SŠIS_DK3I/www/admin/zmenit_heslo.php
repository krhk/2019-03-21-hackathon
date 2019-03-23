<?php
  require_once ($_SERVER['DOCUMENT_ROOT'] . 'constructor.php');
  get_sett_header();
  if( ! is_user_logged_in()){header("location: ". LOGINURL);exit;}
  db_construct();
?>

<?php
  $new_password = $confirm_password = "";
  $new_password_err = $confirm_password_err = "";
  if($_SERVER["REQUEST_METHOD"] == "POST"){
      if(empty(trim($_POST["new_password"]))){
          $new_password_err = "Prosím, zadejte nové heslo.";
      } elseif(strlen(trim($_POST["new_password"])) < 6){
          $new_password_err = "Heslo musím mít minimálně 6 znaků.";
      } else{
          $new_password = trim($_POST["new_password"]);
      }
      if(empty(trim($_POST["confirm_password"]))){
          $confirm_password_err = "Prosím potvrďte svoje heslo.";
      } else{
          $confirm_password = trim($_POST["confirm_password"]);
          if(empty($new_password_err) && ($new_password != $confirm_password)){
              $confirm_password_err = "Hesla se neshodují.";
          }
      }
      if(empty($new_password_err) && empty($confirm_password_err)){
          $sql = "UPDATE users SET password = ? WHERE id = ?";
          if($stmt = mysqli_prepare($link, $sql)){
              mysqli_stmt_bind_param($stmt, "si", $param_password, $param_id);
              $param_password = password_hash($new_password, PASSWORD_DEFAULT);
              $param_id = $_SESSION["id"];
              if(mysqli_stmt_execute($stmt)){
                  session_destroy();
                  echo "<script type='text/javascript'>window.parent.location.reload()</script>";
                  exit();
              } else{
                  echo "Oops! Stala se chyba. Prosím, zkuste to znovu za chvíli.";
              }
          }
          mysqli_stmt_close($stmt);
      }
      mysqli_close($link);
  }
?>
    <div class="wrapper">
        <h2>Změnit heslo</h2>
        <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">
            <div class="form-group <?php echo (!empty($new_password_err)) ? 'has-error' : ''; ?>">
                <label>Nové heslo</label>
                <input type="password" name="new_password" class="form-control" value="<?php echo $new_password; ?>">
                <span class="help-block"><?php echo $new_password_err; ?></span>
            </div>
            <div class="form-group <?php echo (!empty($confirm_password_err)) ? 'has-error' : ''; ?>">
                <label>Potvrzení hesla</label>
                <input type="password" name="confirm_password" class="form-control">
                <span class="help-block"><?php echo $confirm_password_err; ?></span>
            </div>
            <div class="form-group">
                <input type="submit" class="btn btn-primary" value="Submit">
            </div>
        </form>
    </div>
<?php get_sett_footer();?>
