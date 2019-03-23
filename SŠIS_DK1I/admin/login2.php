<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
session_start();
//include_once "mysqli_query.php";
$nick = $_POST["nick"];
$password = $_POST["pass"];
$md5heslo = MD5(SHA1("$password"."Adm1nistrAt10N"));
$link = mysqli_connect("localhost:3306", "W3b0vky", "H3sL0mAr1@DBpHp9259@!!@?", "soutez");
$vysledek = mysqli_query($link, "SELECT * FROM users_admin WHERE nick='".$nick."'");
//$vysledek2 = mysqli_fetch_assoc($vysledek);
//$vysledek3 = $vysledek2['pass'];
//$result = mysqli_query( $link, $vysledek );
$row = mysqli_fetch_array($vysledek, MYSQLI_ASSOC);
if($password  == $row['pass'])
{
    echo 'Test je funkční';
}
else {
    echo 'Test je nefunkční';
}
?>