<?php
$db_server    = 'localhost:3306';
$db_login     = 'W3b0vky@localhost';
$db_password  = 'H3sL0mAr1@DBpHp9259@!!@?';
$db_name      = 'soutez';
$spojeni      = @MySQL_Connect($db_server ,$db_login, $db_password);
@MySQL_Select_DB($db_name)or die('<p style="color: red">Nastala chyba v pripojeni k databazi');
mysql_query("set names utf8");
?>

