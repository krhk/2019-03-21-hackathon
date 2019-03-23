<?php 
    //anti-cache
    header("Cache-Control: no-cache, no-store, must-revalidate"); // HTTP 1.1.
    header("Pragma: no-cache"); // HTTP 1.0.
    header("Expires: 0"); // Proxies.

    date_default_timezone_set('Europe/Prague');
    
    //Settings
    $settingsData = file_get_contents("settings/setting.json");
    $settings = json_decode($settingsData, true);

    //Databáze
    /*include "settings/dbconnect.php";*/

    include "assets/php/functions.php";

    //Switch
    require "assets/php/Connection.php";

    $connection = new Connection();

    //Include
    include $connection->layout;
?>