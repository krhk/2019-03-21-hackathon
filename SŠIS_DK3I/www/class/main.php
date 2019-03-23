<?php
  /* --------- FUNCTIONS START ---------- */
    function get_header(){
      include (REL_CESTA . "pageparts/header.php");
    }
    function get_footer() {
      include (REL_CESTA . "pageparts/footer.php");
    }
    function get_nav () {
      include (REL_CESTA . "pageparts/navigation.php");
    }
    function get_sett_header () {
      include (REL_CESTA . "pageparts/settings_header.php");
    }
    function get_sett_footer () {
      include (REL_CESTA . "pageparts/settings_footer.php");
    }
    function db_construct(){
      require_once (REL_CESTA . "db_conn.php");
    }

    function is_user_logged_in() {
      if(isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === true){
         return true;
       }
      else {
        return false;
      }
    }
  /* ---------- FUNCTIONS END ----------- */

?>
