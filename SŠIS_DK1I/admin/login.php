<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
include "mysqli_query.php";
$nick = $_POST["nick"];
$heslo = $_POST["pass"];
$md5heslo = MD5(SHA1("$heslo"."Adm1nistrAt10N")); 
//$cas = Date("Y-m-d H:i:s");
//$datum = Date("Y-m-d");
//$ccas = Date("H:i:s");
$ip=getenv("HTTP_X_FORWARDED_FOR");
$query = mysqli_query("SELECT * FROM users_admin WHERE nick='".$nick."'");
$result = mysqli_fetch_assoc($query);
//$activation = md5($result['telefon']).md5($login);
// Je vhodné doplnit tuto kontrolu do jiných podobných příkazů    
$dotaz = mysqli_query("select * from users_admin where nick = '$nick' and pass = '$heslo'");
/*$dotaz1 = mysqli_query("select * from users_admin where nick = '$login' and pass = '$heslo' and activation =1");
$dotaz2 = mysqli_query("select * from users_admin where nick = '$login' and pass = '$heslo' and block =1");*/
$overeni = mysqli_num_rows($dotaz);
//$overeni1 = mysqli_num_rows($dotaz1);
//$overeni2 = mysqli_num_rows($dotaz2);
$row = mysqli_fetch_array($dotaz);
//$q2 = mysql_query("INSERT INTO prihlaseni VALUES ('','$login','$md5heslo','$overeni','$cas','$ip','$overeni1','$overeni2')") or die(mysql_error());
//if(!$q2) { echo mysql_error() . ' - ' . mysql_errno(); }
//            else {
//}
//$ip=getenv("HTTP_X_FORWARDED_FOR");
if($heslo  == $row["pass"])
{
if($row["activation"]  == 1) {
} else {
    header("Location: index.php?error=act");
}
if($row["block"]  == 1) {
} else {
    header("Location: index.php?error=block");
}
}
if($overeni  == 1) {
    } else {
        header("Location: index.php?error=accesden_".$heslo."");
}
if($md5heslo  == $row["pass"])
if($row["activation"]  == 1)
if($row["block"]  == 1)
{
session_start();
    //$_SESSION['nick'] = stripslashes($login);
    $_SESSION['nick'] = $_POST["nick"];
    //$_SESSION['heslo'] = $md5heslo;
    $_SESSION['jmeno'] = $row["jmeno"];
    $_SESSION['prijmeni'] = $row["prijmeni"];
    //$_SESSION['id'] = $row["id"];
    //$_SESSION['barvap'] = $row["barvap"];
    header("Location: admin.php");
        die();
/*$query1 = mysql_query("UPDATE `uzivatele` SET `poslednidatum`='".$datum."' WHERE `login`='".$login."' and `heslo`='".$md5heslo."'");
if(!$query1) { echo mysql_error() . " - " . mysql_errno(); }
            else {
$query2 = mysql_query("UPDATE `uzivatele` SET `poslednicas`='".$ccas."' WHERE `login`='".$login."' and `heslo`='".$md5heslo."'");
if(!$query2) { echo mysql_error() . " - " . mysql_errno(); }
            else {
$query3 = mysql_query("UPDATE `uzivatele` SET `poslednidatumcas`='".$cas."' WHERE `login`='".$login."' and `heslo`='".$md5heslo."'");
if(!$query3) { echo mysql_error() . " - " . mysql_errno(); }
            else {
$query4 = mysql_query("UPDATE `uzivatele` SET `posledniip`='".$ip."' WHERE `login`='".$login."' and `heslo`='".$md5heslo."'");
if(!$query4) { echo mysql_error() . " - " . mysql_errno(); }
            else {
}

}
}
}
*/
}
?>