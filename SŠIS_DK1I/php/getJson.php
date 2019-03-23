<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
  $link = mysqli_connect("localhost:3306", "W3b0vky", "H3sL0mAr1@DBpHp9259@!!@?", "soutez");
  $vysledek = mysqli_query($link, "SELECT * FROM data");
  $row = mysqli_fetch_array($vysledek, MYSQLI_ASSOC);
  echo '{ "name":"'.$row['Jmeno_lekare'].'", "street":"'.$row['Ulice'].'", "number":"'.$row['Cislo_popisne'].'", "city_name":"'.$row['Nazev_obce'].'", "phone":"'.$row['Telefon'].'", "opening":"'.$row['Ordinacni_hodiny'].'"}';
?>
