<?php
    /* ----------- DEFINE START ----------- */
      define('REL_CESTA', $_SERVER['DOCUMENT_ROOT']);
      define('URL',  "http://" . $_SERVER['SERVER_NAME']);
      define('LOGOUTURL',  "http://" . $_SERVER['SERVER_NAME'] . "/admin/logout");
      define('LOGINURL',  "http://" . $_SERVER['SERVER_NAME'] . "/admin/login");
      define('ADMINURL',  "http://" . $_SERVER['SERVER_NAME'] . "/admin/admin");
      define('EDITURL',  "http://" . $_SERVER['SERVER_NAME'] . "/admin/upravit_zastavky");
      define('USERSEDITURL',  "http://" . $_SERVER['SERVER_NAME'] . "/admin/pridat_uzivatele");
      define('CHANGEPASSURL',  "http://" . $_SERVER['SERVER_NAME'] . "/admin/zmenit_heslo");
    /* ------------ DEFINE END ------------ */

    /* ---------- REQUIRE START ----------- */
      require_once (REL_CESTA . "/class/main.php");
    /* ----------- REQUIRE END ------------ */
 ?>
